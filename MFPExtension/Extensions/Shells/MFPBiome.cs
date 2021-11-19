using System.Collections.Generic;

namespace MFPExtension.Extensions.Shells {
    public class MFPBiome {
        public string name { get; set; }
        public string temperatureRange { get; set; }
        public string humidityRange { get; set; }
        public float populationDensity { get; set; }
        public List<string> tilesets { get; set; }
        public List<string> heightTiles { get; set; }

    }
}
