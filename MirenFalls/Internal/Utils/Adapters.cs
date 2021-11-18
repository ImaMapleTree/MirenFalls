using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Map;
using System.Collections.Generic;
using System.IO;
using static MirenFalls.Internal.Utils.Utils;

namespace MirenFalls.Internal.Utils {
    static class Adapters {
        public static float DoubleToFloat(double d) {
            return (float)d;
        }

        public static double FloatToDouble(float f) {
            return (double)f;
        }

        public static HeightTile JsonToHeightTile(Dictionary<string, string> dict) {
            Tile tile = new Tile(Resources.loadContent<Texture2D>(Path.Combine("Biomes/HeightTiles/Textures", dict["name"])), Collision.None);
            Range heightRange = new Range(dict["heightRange"]);
            return new HeightTile(tile, heightRange);
        }
    }
}
