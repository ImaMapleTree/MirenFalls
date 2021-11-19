using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Extended.Sprites;
using System.IO;
using System.Text.Json;
namespace MFPExtension.Extensions.Spritesheet {

    [ContentImporter(".sf", DefaultProcessor = "SpriteSheetProcessor", DisplayName = "SpriteSheetImporter - MFPE")]
    public class SpriteSheetImporter : ContentImporter<SpriteSheetShell> {


        public override SpriteSheetShell Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<SpriteSheetShell>(filename);
        }

    }

}