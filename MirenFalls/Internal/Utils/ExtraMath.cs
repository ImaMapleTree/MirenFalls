using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Utils {

    // A math utils class that aims to copy a bunch of Unity Math functions

    public static class ExtraMath {

        public static float Clamp01(float value) {
            if (value < 0F)
                return 0F;
            else if (value > 1F)
                return 1F;
            else
                return value;
        }

        /// <summary>
        /// Calculates value as a percentage of point a and b.
        /// </summary>
        /// <returns>
        /// A value between zero and one, representing where the "value" parameter falls within the range defined by a and b.
        /// </returns>
        public static float InverseLerp(float a, float b, float value) {
            if (a != b)
                return Clamp01((value - a) / (b - a));
            else
                return 0.0f;
        }

        public static int FloorToInt(float value) {
            return (int)Math.Floor((double)value);
        }

        public static int CeilToInt(float value) {
            return (int)Math.Ceiling((double)value);
        }

        public static float Floor(float value) {
            return (float)Math.Floor((float)value);
        }
    }
}
