using MirenFalls.Internal.Map;
using MirenFalls.Internal.Utils;
using System.Collections.Generic;

namespace MirenFalls.Internal.PipelineExtension.Shells {
    public class BiomeShell {
        public string name { get; set; }
        public Range temperatureRange { get; set; }
        public Range humidityRange { get; set; }
        public float populationDensity { get; set; }
        public List<string> tilesets { get; set; }
        public List<string> heightTiles { get; set; }

    }
}
