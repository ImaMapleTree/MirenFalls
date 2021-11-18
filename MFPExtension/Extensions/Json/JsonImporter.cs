using System;
using System.Collections.Generic;
using System.IO;
using MFPExtension.Extensions.Biome;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Json {

    [ContentImporter(".json", DefaultProcessor = "JsonProcessor", DisplayName = "Json Processor - MFPE")]
    public class JsonImporter : ContentImporter<Dictionary<string, dynamic>> {

        public override Dictionary<string, dynamic> Import(string filename, ContentImporterContext context) {
            return JsonLoader.loadJson<Dictionary<string, dynamic>>(filename);
        }
    }
}