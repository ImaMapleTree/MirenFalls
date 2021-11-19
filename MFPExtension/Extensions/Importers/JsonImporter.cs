using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Importers {

    [ContentImporter(".json", DefaultProcessor = "JsonProcessor", DisplayName = "Json Processor - MFPE")]
    public class JsonImporter : ContentImporter<Dictionary<string, dynamic>> {

        public override Dictionary<string, dynamic> Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<Dictionary<string, dynamic>>(filename);
        }
    }
}