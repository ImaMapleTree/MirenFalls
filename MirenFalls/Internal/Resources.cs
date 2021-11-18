﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using MFPExtension.Extensions.Biome;
using Microsoft.Xna.Framework.Content;

namespace MirenFalls.Internal {

    public static class Resources {

        public static ContentManager content = null;
        public static List<MFPBiome> biomes;

        public static void Initialize(ContentManager IC) {
            content = IC;
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