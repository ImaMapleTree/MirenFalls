using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using Internal.Graphics;
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
