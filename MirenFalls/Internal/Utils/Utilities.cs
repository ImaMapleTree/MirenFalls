using Microsoft.Xna.Framework;
using MirenFalls.Internal.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Utils {
    public static class Utilities {
        public static bool IsList(object obj) {
            return obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        public static bool IsDictionary(object obj) {
            return obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }

        public static VectorInt TilePosition(Vector2 position) {
            return new VectorInt(position.X / 16, position.Y / 16);
        }
        public static int GetDeterministicHashCode(this string str) {
            unchecked {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2) {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }


    }
}
