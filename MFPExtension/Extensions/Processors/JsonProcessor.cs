using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MFPExtension.Extensions.Json {
    [ContentProcessor]
    public class JsonProcessor : ContentProcessor<Dictionary<string, dynamic>, Dictionary<string, dynamic>> {
        public override Dictionary<string, dynamic> Process(Dictionary<string, dynamic> input, ContentProcessorContext context) {
            return input;
        }
    }
}