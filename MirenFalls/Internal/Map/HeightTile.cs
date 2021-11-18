using MirenFalls.Internal.Graphics;
using System.Collections.Generic;
using System.Text;
using static MirenFalls.Internal.Utils.Utils;

namespace MirenFalls.Internal.Map {
    public class HeightTile {
        public Tile tile;
        public Range heightRange;

        public HeightTile(Tile t, Range hr) {
            this.tile = t;
            this.heightRange = hr;
        }
    }
}
