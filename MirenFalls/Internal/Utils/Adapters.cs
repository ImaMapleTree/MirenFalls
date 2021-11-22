﻿using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension.Shells;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MirenFalls.Internal.Utils {
    public static class Adapters {
        public static float DoubleToFloat(double d) {
            return (float)d;
        }

        public static double FloatToDouble(float f) {
            return (double)f;
        }

        public static HeightTile JsonToHeightTile(Dictionary<string, string> dict) {
            Tile tile = new Tile(Resources.loadContent<CompressibleTexture>(Path.Combine("Biomes/HeightTiles/Textures", dict["name"])), Collision.None);
            Range heightRange = Range.FromString(dict["heightRange"]);
            return new HeightTile(tile, heightRange);
        }

        public static HeightTile RefToHeightTile(string reference) {
            return Resources.loadContent<HeightTile>(Path.Combine("Biomes/HeightTiles/", reference));
        }

        public class RangeConverter : JsonConverter<Range> {

            public override Range Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options) {
                return Range.FromString(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, Range value, JsonSerializerOptions options) {
                writer.WritePropertyName("range");
                writer.WriteStringValue(value.ToString());
            }
        }

        public class TextureConverter : JsonConverter<CompressibleTexture> {
            public override CompressibleTexture Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options) {
                string texturePath = reader.GetString();
                return (CompressibleTexture)Texture2D.FromFile(Resources.graphicsDevice, texturePath);
            }

            public override void Write(Utf8JsonWriter writer, CompressibleTexture value, JsonSerializerOptions options) {
                writer.WritePropertyName("texture");
                writer.WriteStringValue(value.path);
            }
        }
    }
}
