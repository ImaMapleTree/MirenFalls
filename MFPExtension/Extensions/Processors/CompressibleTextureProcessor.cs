using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Graphics;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "CompressibleTextureProcessor - MFPE")]
    public class CompressibleTextureProcessor : ContentProcessor<CompressibleTexture, CompressibleTexture> {
        public override CompressibleTexture Process(CompressibleTexture input, ContentProcessorContext context) {
            return input;
        }
    }
}