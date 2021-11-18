using System;
using System.Collections.Generic;
using MFPExtension.Extensions.Biome;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Biome {
    [ContentProcessor(DisplayName = "BiomeProcessor - MFPE")]
    public class BiomeProcessor : ContentProcessor<MFPBiome, MFPBiome> {
        public override MFPBiome Process(MFPBiome input, ContentProcessorContext context) {
            return input;
        }
    }
}