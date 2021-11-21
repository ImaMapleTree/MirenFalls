using Microsoft.Xna.Framework.Content;
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

            heightTile.tile = input.ContentManager.Load<Tile>(input.ReadString());
            heightTile.heightRange = Range.FromString(input.ReadString());
            return heightTile;
        }
    }
}
