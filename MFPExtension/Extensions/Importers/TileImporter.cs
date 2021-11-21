using MFPExtension.Extensions.Shells;
using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Graphics;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(new[] { ".png", ".jpg" }, DefaultProcessor = "TileProcessor", DisplayName = "TileImporter - MFPE")]
    public class TileImporter : ContentImporter<CompressibleTexture> {

        public override CompressibleTexture Import(string filename, ContentImporterContext context) {
            Pipeline.Initialize();
            return new CompressibleTexture(filename);
        }
    }
}