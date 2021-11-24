using System.Collections.Generic;
using MirenFalls.Internal.Utils;
using MirenFalls.Internal.PipelineExtension.Shells;

namespace MirenFalls.Internal.Map {

    // Biome class - crucial part of map generation
    /* Roles:
     * Defines ground tiles
     * Defines "tile assets"
     */

    public class Biome {
        public string name { get; set; }
        public Range temperatureRange { get; set; }
        public Range humidityRange { get; set; }
        public List<string> tilesets { set; get;  }
        public List<HeightTile> heightTiles { get; set; }

        public Biome(BiomeShell shell) {
            name = shell.name;
            temperatureRange = shell.temperatureRange;
            humidityRange = shell.humidityRange;
            tilesets = shell.tilesets;
            heightTiles = shell.heightTiles.ConvertAll<HeightTile>(tile => Adapters.RefToHeightTile(tile));
        }

        public bool IsValidTemperature(float temperature) {
            return temperatureRange.InRange(temperature);
        }

        public bool IsValidHumidity(float humidity) {
            return humidityRange.InRange(humidity);
        }

        public HeightTile GetHeightTile(float height) {
            HeightTile match = heightTiles.Find(tile => tile.heightRange.InRange(height));
            match = match != null ? match : heightTiles[0];
            return match;
        }
    }
}
