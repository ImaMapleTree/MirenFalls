using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Graphics;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".sf", DefaultProcessor = "AnimationProcessor", DisplayName = "AnimationImporter - MFPE")]
    public class AnimationImporter : ContentImporter<Animation> {

        public override Animation Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<Animation>(filename);
        }
    }
}