using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Biome {

    [ContentImporter(".json", DefaultProcessor = "BiomeProcessor", DisplayName = "BiomeImporter - MFPE")]
    public class BiomeImporter : ContentImporter<MFPBiome> {

        public override MFPBiome Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<MFPBiome>(filename);
        }

    }

}