using System.Collections.Generic;
using MirenFalls.Internal.Utils;
using MirenFalls.Internal.Map.Collections;
using System.IO;

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
        public List<Tileset> tilesets { set; get;  }
        public List<HeightTile> heightTiles { get; set; }

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
