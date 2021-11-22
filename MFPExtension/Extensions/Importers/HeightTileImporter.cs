using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Importers {
    [ContentImporter(".path", DefaultProcessor = "HeightTileProcessor", DisplayName = "HeightTile - MFPE")]
    public class HeightTileImporter : ContentImporter<Dictionary<string, string>> {

        public override Dictionary<string, string> Import(string filename, ContentImporterContext context) {
            Dictionary<string, string> input = JsonLoader.loadJson<Dictionary<string, string>>(filename);
            input.Add("filename", filename);
            return input;
        }
    }
}
