using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "SpriteSheetProcessor - MFPE")]
    public class SpriteSheetProcessor : ContentProcessor<SpriteSheet, SpriteSheet> {
        public override SpriteSheet Process(SpriteSheet input, ContentProcessorContext context) {
            return input;
        }
    }
}