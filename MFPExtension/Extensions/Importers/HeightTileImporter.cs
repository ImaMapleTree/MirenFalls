using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Importers {
    [ContentImporter(".json", DefaultProcessor = "HeightTileProcessor", DisplayName = "HeightTile - MFPE")]
    public class HeightTileImporter : ContentImporter<HeightTile> {

        public override HeightTile Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<HeightTile>(filename);
        }
    }
}
