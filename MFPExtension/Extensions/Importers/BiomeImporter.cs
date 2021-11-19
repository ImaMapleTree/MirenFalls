using MFPExtension.Extensions.Shells;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".json", DefaultProcessor = "BiomeProcessor", DisplayName = "BiomeImporter - MFPE")]
    public class BiomeImporter : ContentImporter<MFPBiome> {

        public override MFPBiome Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<MFPBiome>(filename);
        }

    }

}