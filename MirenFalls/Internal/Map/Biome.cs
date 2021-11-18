using MFPExtension.Extensions.Biome;
using System.Collections.Generic;
using MirenFalls.Internal.Utils;
using static MirenFalls.Internal.Utils.Utils;
using MirenFalls.Internal.Map.Collections;
using System.IO;

namespace MirenFalls.Internal.Map {
    public class Biome {
        public string name;
        public Range temperatureRange;
        public Range humidityRange;
        public List<Tileset> tilesets;
        public List<HeightTile> heightTiles;

        public Biome(MFPBiome mfpb) {
            name = mfpb.name;
            temperatureRange = new Range(mfpb.temperatureRange);
            humidityRange = new Range(mfpb.humidityRange);
            heightTiles = mfpb.heightTiles.ConvertAll(tile => Adapters.JsonToHeightTile(Resources.loadJson<Dictionary<string, string>>(Path.Combine("Content/Biomes/HeightTiles", tile+".json"))));
        }

        public bool IsValidTemperature(float temperature) {
            return temperatureRange.InRange(temperature);
        }

        public bool IsValidHumidity(float humidity) {
            return humidityRange.InRange(humidity);
        }

        public HeightTile GetHeightTile(float height) {
            HeightTile match = heightTiles.Find(tile => tile.heightRange.InRange(height));
            //foreach (HeightTile ht in heightTiles) {
              //  Debug.Log(name + " | " + match + " | " + height + " | " + ht.heightRange.InRange(height) + " | min: " + ht.heightRange.min + " max: " + ht.heightRange.max);
            //}
            match = match != null ? match : heightTiles[0];
            return match;
        }
    }
}
