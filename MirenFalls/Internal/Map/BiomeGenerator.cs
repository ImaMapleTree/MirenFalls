using MirenFalls.Internal.PipelineExtension.Shells;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using static Internal.Utils.NoiseGenerator;

    public class BiomeGenerator {

        List<Biome> biomes = Resources.biomes;

        PerlinNoise temperatureNoise;
        PerlinNoise humidityNoise;
        
        public BiomeGenerator(string seed) {
            temperatureNoise = new PerlinNoise(2000, 3, 0.45f, 6f, seed); // scale = 2000 lac = 4
            humidityNoise = new PerlinNoise(600, 3, 0.3f, 20f, seed + "humid"); // scale = 600
        }

        public BiomeGenerator() : this(System.DateTime.Now.ToString()) {
        }

        public Biome GetBiome(int x, int y) {
            float tempValue = temperatureNoise.GetValue(x, y) * 100;
            float humidityValue = humidityNoise.GetValue(x, y) * 100;
            Biome match = biomes.Find(biome => biome.IsValidTemperature(tempValue) && biome.IsValidHumidity(humidityValue));
            match = match != null ? match : biomes[0];
            return match;
        }
    }
}
