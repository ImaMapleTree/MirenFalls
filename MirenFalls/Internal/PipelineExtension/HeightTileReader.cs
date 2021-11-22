using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.Utils;

namespace MirenFalls.Internal.PipelineExtension {
    public class HeightTileReader : ContentTypeReader<HeightTile> {
        protected override HeightTile Read(ContentReader input, HeightTile existingInstance) {
            HeightTile heightTile = existingInstance;

            if (heightTile == null) {
                heightTile = new HeightTile();
            }
            Debug.Log(input.AssetName);

            string texturePath = input.ReadString();

            heightTile.tile = new Tile(new CompressibleTexture(texturePath), Collision.None);
            heightTile.heightRange = Range.FromString(input.ReadString());
            return heightTile;
        }
    }
}
