using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using Internal.Graphics;
    using static MirenFalls.Internal.Utils.NoiseGenerator;

    public static class Procedural {

        private const float scale = 100.37f; //good viewing but bad for game
        //private const float scale = 800f;
        private const int octaves = 3;
        private const float persistence = 0.55f;
        private const float lacunarity = 2.65f;


        public static PerlinNoise noiseGenerator = new PerlinNoise(scale, octaves, persistence, lacunarity);
        public static BiomeGenerator biomeGenerator = new BiomeGenerator();

        public static void InitState(string seed = null) {
            seed = seed != null ? seed : System.DateTime.Now.ToString();
            noiseGenerator = new PerlinNoise(scale, octaves, persistence, lacunarity, seed);
            biomeGenerator = new BiomeGenerator(seed);
        }


        public static void InitializeMap(GameMap map) {
            for (int x = 0; x < map.width; x++) {
                for (int y = 0; y < map.height; y++) {
                    Biome biome = biomeGenerator.GetBiome(x, y);
                    map.biomeArray[x, y] = biome;
                    map.tilemap.AddTile(x, y, biome.GetHeightTile(noiseGenerator.GetValue(x, y)));
                }
            }
        }
    }
}
