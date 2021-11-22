using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".sf", DefaultProcessor = "SpriteSheetProcessor", DisplayName = "SpriteSheetImporter - MFPE")]
    public class SpriteSheetImporter : ContentImporter<SpriteSheetShell> {


        public override SpriteSheetShell Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<SpriteSheetShell>(filename);
        }

    }

}