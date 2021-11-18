using System;
using System.IO;
using System.Text.Json;

namespace MFPExtension {
    public static class JsonLoader {
        public static T loadJson<T>(string path) {
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
