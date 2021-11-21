using MFPExtension.Extensions.Shells;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "SpriteSheetProcessor - MFPE")]
    public class SpriteSheetProcessor : ContentProcessor<SpriteSheetShell, SpriteSheetShell> {
        public override SpriteSheetShell Process(SpriteSheetShell input, ContentProcessorContext context) {
            return input;
        }
    }
}