using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Utils;
using System.Linq;
using System.Text.Json.Serialization;

namespace MirenFalls.Internal.Graphics {

    [JsonConverter(typeof(Adapters.TextureConverter))]
    public class CompressibleTexture : Texture2D {

        private string _path = null;

        public string path {
            get { return _path; }
            set {
                Texture2D texture = Texture2D.FromFile(Pipeline.graphicsDevice, value);
                
                this._path = value;
                byte[] data = new byte[texture.Width * texture.Height * 4];
                this.CopyPropertiesTo<Texture, CompressibleTexture>(texture, this);
                texture.GetData<byte>(data);
                this.SetData(data);
            }
        }

        public CompressibleTexture() : base(Pipeline.graphicsDevice, 1, 1) {
        }

        public CompressibleTexture(string path) : this(Texture2D.FromFile(Pipeline.graphicsDevice, path), path) {
        }

        public CompressibleTexture(Texture2D texture, string path) : base(texture.GraphicsDevice, texture.Width, texture.Height) {
            this.path = path;
            byte[] data = new byte[texture.Width*texture.Height*4];
            this.CopyPropertiesTo<Texture, CompressibleTexture>(texture, this);
            texture.GetData<byte>(data);
            this.SetData(data);
        }

        public new CompressibleTexture FromFile(GraphicsDevice graphicsDevice, string path) {
            Texture2D texture = Texture2D.FromFile(graphicsDevice, path);
            return new CompressibleTexture(texture, path);
        }

        public Texture2D AsTexture() {
            return Texture2D.FromFile(this.GraphicsDevice, this.path);
        }

        public void CopyPropertiesTo<T, TU>(T source, TU dest) {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps) {
                if (destProps.Any(x => x.Name == sourceProp.Name)) {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite) { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }

        }
    }
}
