using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".json", DefaultProcessor = "BiomeProcessor", DisplayName = "BiomeImporter - MFPE")]
    public class BiomeImporter : ContentImporter<BiomeShell> {

        public override BiomeShell Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<BiomeShell>(filename);
        }

    }
     
}