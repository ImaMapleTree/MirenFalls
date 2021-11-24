using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Utils {

    // Improved random class that doesn't require instancing
    // Inspired by unity's random class, but they don't make their code public so I'm just guessing at their actual methods

    static class Random {

        private static System.Random _random = new System.Random();

        /// <summary>
        /// Initalizes the random number generator state with a seed.
        /// </summary>
        /// <param name="seed"></param>
        public static void InitState(int seed) {
            _random = new System.Random(seed);
        }

        public static void InitState(string seed) {
            InitState(seed.GetDeterministicHashCode());
        }

        /// <summary>
        /// Returns a random int within [minInclusive, maxInclusive]
        /// </summary>
        public static int Range(int minInclusive, int maxInclusive) {
            return _random.Next(minInclusive, maxInclusive);
        }

        /// <summary>
        /// Returns a random float within [minInclusive, maxInclusive]
        /// </summary>
        public static float Range(float minInclusive, float maxInclusive) {
            double d = _random.NextDouble() * (maxInclusive - minInclusive);
            return (float)d - minInclusive;
        }

        /// <summary>
        /// Returns a random double within [minInclusive, maxInclusive]
        /// </summary>
        public static double Range(double minInclusive, double maxInclusive) {
            return (_random.NextDouble() * (maxInclusive - minInclusive)) - minInclusive;
        }

        public static double Range() {
            return _random.NextDouble();
        }
    }
}
