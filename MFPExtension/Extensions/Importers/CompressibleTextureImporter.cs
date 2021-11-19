using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Utils;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(new[] { ".png", ".jpg" }, DefaultProcessor = "CompressibleTextureProcessor", DisplayName = "CompressibleTextureImporter - MFPE")]
    public class CompressibleTextureImporter : ContentImporter<CompressibleTexture> {

        public override CompressibleTexture Import(string filename, ContentImporterContext context) {
            Debug.Log("Hello darkness");
            Pipeline.Initialize();
            return new CompressibleTexture(filename);
        }

    }

}