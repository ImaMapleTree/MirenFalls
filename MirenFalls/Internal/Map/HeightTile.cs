using MirenFalls.Internal.Graphics;
using System.Collections.Generic;
using System.Text;
using MirenFalls.Internal.Utils;

namespace MirenFalls.Internal.Map {
    public class HeightTile {
        public Tile tile { get; set; }
        public Range heightRange { get; set; }

        public HeightTile(Tile t, Range hr) {
            this.tile = t;
            this.heightRange = hr;
        }
    }
}
