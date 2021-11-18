using MirenFalls.Internal.Exceptions;
using System;

namespace MirenFalls.Internal.Utils {
    public static class Utils {


        public enum RangeType { Double = 0, Float = 1, Int = 2 }


        // A simple range class that allows for inclusive or exclusive ranges based on the constructor
        // Useful for quickly comparing if a value is between two set numbers
        public class Range {
            public dynamic min;
            public dynamic max;
            private RangeType rType = RangeType.Double;
            protected bool inclusive = true;

            public Range(double minInclusive, double maxInclusive) {
                this.min = minInclusive;
                this.max = maxInclusive;
            }

            public Range(int minInclusive, int maxInclusive) {
                this.min = minInclusive;
                this.max = maxInclusive;
                this.rType = RangeType.Int;
            }

            public Range(float minInclusive, float maxInclusive) {
                this.min = minInclusive;
                this.max = maxInclusive;
                this.rType = RangeType.Float;
            }

            public Range(string rangeString) {
                if (!rangeString.Contains("..")) throw new RangeParseException();
                string[] splitString = rangeString.Split("..");
                this.min = float.Parse(splitString[0]);
                this.max = float.Parse(splitString[1]);
                this.rType = RangeType.Float;
            }

            public bool InRange(int value) {
                if (this.inclusive) return (min <= value && value <= max);
                return (min < value && max < value);
            }

            public bool InRange(float value) {
                if (this.inclusive) return (min <= value && value <= max);
                return (min < value && max < value);
            }

            public bool InRange(double value) {
                if (this.inclusive) return (min <= value && value <= max);
                return (min < value && max < value);
            }
        }

        public class RangeExclusive : Range {
            public RangeExclusive(double minExclusive, double maxExclusive) : base(minExclusive, maxExclusive) {
                this.inclusive = false;
            }

            public RangeExclusive(int minExclusive, int maxExclusive) : base(minExclusive, maxExclusive) {
                this.inclusive = false;
            }

            public RangeExclusive(float minExclusive, float maxExclusive) : base(minExclusive, maxExclusive) {
                this.inclusive = false;
            }
        }
    }
}
