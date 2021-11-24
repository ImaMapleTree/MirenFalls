using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".sf", DefaultProcessor = "SpriteSheetProcessor", DisplayName = "SpriteSheetImporter - MFPE")]
    public class SpriteSheetImporter : ContentImporter<SpriteSheet> {


        public override SpriteSheet Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<SpriteSheet>(filename);
        }

    }

}