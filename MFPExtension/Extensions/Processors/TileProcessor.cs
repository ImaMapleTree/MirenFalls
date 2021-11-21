using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Graphics;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "TileProcessor - MFPE")]
    public class TileProcessor : ContentProcessor<CompressibleTexture, Tile> {
        public override Tile Process(CompressibleTexture input, ContentProcessorContext context) {

            Tile tile = new Tile(input, Collision.None);

            return tile;
        }
    }
}