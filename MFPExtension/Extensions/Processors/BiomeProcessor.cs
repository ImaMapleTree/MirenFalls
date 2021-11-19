using MFPExtension.Extensions.Shells;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "BiomeProcessor - MFPE")]
    public class BiomeProcessor : ContentProcessor<MFPBiome, MFPBiome> {
        public override MFPBiome Process(MFPBiome input, ContentProcessorContext context) {
            return input;
        }
    }
}