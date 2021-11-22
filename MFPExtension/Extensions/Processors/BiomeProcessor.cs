using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension.Shells;
using MirenFalls.Internal.Utils;
using System.IO;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "BiomeProcessor - MFPE")]
    public class BiomeProcessor : ContentProcessor<BiomeShell, BiomeShell> {
        public override BiomeShell Process(BiomeShell input, ContentProcessorContext context) {
            return input;
        }
    }
}