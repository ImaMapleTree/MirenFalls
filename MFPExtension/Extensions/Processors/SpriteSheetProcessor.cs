using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "SpriteSheetProcessor - MFPE")]
    public class SpriteSheetProcessor : ContentProcessor<SpriteSheetShell, SpriteSheetShell> {
        public override SpriteSheetShell Process(SpriteSheetShell input, ContentProcessorContext context) {
            return input;
        }
    }
}