using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System.Text.Json;

namespace MFPExtension.Extensions.Json {
    [ContentTypeWriter]
    class JsonTypeWriter : ContentTypeWriter<Dictionary<string, dynamic>> {
        protected override void Write(ContentWriter output, Dictionary<string, dynamic> value) {
            output.Write(JsonSerializer.Serialize(value));
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform) {
            return typeof(Dictionary<string, dynamic>).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform) {
            return typeof(Dictionary<string, dynamic>).AssemblyQualifiedName;
        }
    }
}
