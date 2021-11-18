using System.Collections.Generic;

namespace MFPExtension.Extensions.Biome {
    public class MFPBiome {
        public string name { set; get; }
        public string temperatureRange { set; get; }
        public string humidityRange { set; get; }
        public float populationDensity { set; get; }
        public List<string> tilesets { set; get; }
        public List<string> heightTiles { set; get; }

    }
}
