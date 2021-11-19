using MirenFalls.Internal.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MirenFalls.Internal.Utils {

    // Range class used for simplification of JSON through a simple format (3..1)
    [JsonConverter(typeof(Adapters.RangeConverter))]
    public class Range {

        public dynamic min;
        public dynamic max;
        public bool minInclusive;
        public bool maxInclusive;
        
        public Range(dynamic min, dynamic max, bool minInclusive=true, bool maxInclusive=true) {
            this.min = min;
            this.max = max;
            this.minInclusive = minInclusive;
            this.maxInclusive = maxInclusive;
        }

        public static Range FromString(string rangeString) {
            if (!rangeString.Contains(",")) throw new RangeParseException();
            rangeString = rangeString.Replace(", ", ",").Replace(",", ", "); // Converts ", " -> "," -> ", " to ensure uniformity
            string[] split = rangeString.Split(", ");
            if (!split[0].Contains("[") || !split[0].Contains("(") || !split[1].Contains("]") || !split[1].Contains(")")) throw new RangeParseException();
            return new Range(float.Parse(split[0][1..]), float.Parse(split[1][0..^2]), split[0][0].Equals("["), split[1][^1].Equals("]"));
        }

        public override string ToString() {
            string start = minInclusive ? "[" : "(";
            string end = maxInclusive ? "]" : ")";
            return start + min + ", " + max + end;
        }

        public bool InRange(dynamic value) {
            bool lesserTruth = minInclusive ? min <= value : min < value;
            bool greaterTruth = maxInclusive ? value <= max : value < max;
            return (minInclusive && maxInclusive);
        }
    }
}
