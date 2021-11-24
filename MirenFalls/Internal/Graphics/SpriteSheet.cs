using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MirenFalls.Internal.Graphics {
    [JsonConverter(typeof(Adapters.SpriteSheetConverter))]
    public class SpriteSheet {

        private List<TextureRegion> _textures = new List<TextureRegion>();
        public Texture2D parentTexture;

        private int _rWidth = - 1;
        private int _rHeight = -1;

        private string _path;

        public string texture {
            get { return _path; }
            set {
                _path = value;
                parentTexture = new CompressibleTexture(_path).AsTexture();
            }
        }

        public int regionWidth {
            get { return _rWidth; }
            set {
                _rWidth = value;
                if (_rHeight != -1) {
                    CreateSubTextures();
                }
            }
        }

        public int regionHeight {
            get { return _rHeight; }
            set {
                _rHeight = value;
                if (_rWidth != -1) {
                    CreateSubTextures();
                }
            }
        }

        public List<TextureRegion> textures { get { return _textures; } }

        public SpriteSheet() { }

        public SpriteSheet(Texture2D original, int subWidth, int subHeight) {
            parentTexture = original;
            regionWidth = subWidth;
            regionHeight = subHeight;
        }

        public SpriteSheet(CompressibleTexture original, int subWidth, int subHeight) {
            _path = original.path;
            parentTexture = original;
            regionWidth = subWidth;
            regionHeight = subHeight;
        }

        public void CreateSubTextures() {
            for (int y = 0; y < parentTexture.Height; y += regionHeight) {
                for (int x = 0; x < parentTexture.Width; x += regionWidth) {
                    _textures.Add(new TextureRegion(parentTexture, x, y, regionWidth, regionHeight));
                }
            }
        }

        public TextureRegion GetSprite(int index) {
            if (index > _textures.Count - 1) return null;
            return _textures[index];
        }
    }
}
