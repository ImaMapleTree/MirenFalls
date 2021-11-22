using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MirenFalls.Internal {

    // Static resource manager and my solution to passing the default ContentManager in a static way.
    // Some niche functions such as loading from JSON, will also contain static references to loaded content initialized from the main game body. (Main.cs)

    public static class Resources {

        public static ContentManager content = null;
        public static GraphicsDevice graphicsDevice;
        public static List<Biome> biomes;

        public static void Initialize(ContentManager IC, GraphicsDevice device) {
            content = IC;
            graphicsDevice = device;
            biomes = loadAllContent<BiomeShell>("Biomes").ConvertAll<Biome>(shell => new Biome(shell));
        }

        public static void loadStatic() {
            
        }

        public static T loadContent<T>(string filename) {
            return content.Load<T>(filename);
        }

        public static List<T> loadAllContent<T>(string path) {
            path = Path.Combine("Content", path);
            List<T> objectList = new List<T>();
            foreach (string file in Directory.GetFiles(path, "*.xnb")) { // All files found are formatted as Content/[DIRECTORY]/[name].xnb
                objectList.Add(content.Load<T>(file.Replace("Content\\", "").Replace(".xnb", ""))); // Replace "Content\" & ".xnb" because loading from CM auto includes "Content\" & ".xnb"
            }
            return objectList;
        }

        public static List<T> loadAllJson<T>(string path) {
            List<T> objectList = new List<T>();
            foreach (string file in Directory.GetFiles(path, "*.json")) {
                objectList.Add(loadJson<T>(file));
            }
            return objectList;
        }

        public static T loadJson<T>(string filename) {
            string jsonString = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
