using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using Internal.Graphics;
    using MirenFalls.Internal.Utils;
    using static MirenFalls.Internal.Utils.NoiseGenerator;

    // Class incharge of initial map generator and generating new areas of the map.
    // TODO: Implement concurrent-procedural generation (Probably what I'm working on next)
    /*
     * Additionally:
     * There's 2 options as to how we're going to be saving already generated chunks
     * Option 1: Never save the procedural generation but instead save changes to the map and then re-load the changes when entering area
     * Option 2: Save both the procedural generation and states on the map
     * 
     * There's going to be a lot of logic behind how systems work while they're "unloaded" because areas should still development even after the player leaves the surroundings
     * 
     */

    public static class Procedural {

        private const float scale = 100.37f; //good viewing but bad for game
        //private const float scale = 800f;
        private const int octaves = 3;
        private const float persistence = 0.55f; //0.55
        private const float lacunarity = 2.65f; //2.65



        public static Noise noiseGenerator;
        public static BiomeGenerator biomeGenerator;
        public static CliffNoise cliffGenerator;

        private static GameMap map;

        public static void InitState(string seed = null) {
            seed = seed != null ? seed : System.DateTime.Now.ToString();
            noiseGenerator = new PerlinNoise(scale, octaves, persistence, lacunarity, seed);
            biomeGenerator = new BiomeGenerator(seed + "biome");
            cliffGenerator = new CliffNoise(100.37f, 3, 0.55f, 2.65f, seed + "cliff");
        }


        public static void InitializeMap(GameMap map) {
            Procedural.map = map;
            for (int x = 0; x < map.width; x++) {
                for (int y = 0; y < map.height; y++) {
                    Biome biome = biomeGenerator.GetBiome(x, y);
                    map.biomeArray[x, y] = biome;
                    map.tilemap.AddTile(x, y, biome.GetHeightTile(noiseGenerator.GetValue(x, y)));
                }
            }
        }

        public static void GenerateEdge(int horizontal, int vertical) {
            int indexX = 0;
            int indexY = 0;
            int noiseX = horizontal;
            int noiseY = vertical;

            if (horizontal > 0) {
                indexX = map.width - horizontal;
                noiseX = map.maxBound.x + 1 - horizontal;
            } else {
                horizontal *= -1;
                noiseX = map.minBound.x - horizontal;
            }

            if (vertical > 0) {
                indexY = map.height - vertical;
                noiseY = map.maxBound.y + 1 - vertical;
            } else {
                vertical *= -1;
                noiseY = map.minBound.y - vertical;
            }

            for (int x = 0; x < horizontal; x++) {
                for (int y = 0; y < map.height; y++) {
                    indexX += x;
                    noiseX += x;
                    int originY = map.minBound.y + y;
                    Biome biome = biomeGenerator.GetBiome(noiseX, originY);
                    map.tilemap.AddTile(indexX, y, biome.GetHeightTile(noiseGenerator.GetValue(noiseX, originY)));
                }
            }

            for (int y = 0; y < vertical; y++) {
                for (int x = 0; x < map.width; x++) {
                    indexY += y;
                    noiseY += y;
                    int originX = map.minBound.x + x;
                    Biome biome = biomeGenerator.GetBiome(originX, noiseY);
                    map.tilemap.AddTile(x, indexY, biome.GetHeightTile(noiseGenerator.GetValue(originX, noiseY)));
                }
            }
        }
    }
}
