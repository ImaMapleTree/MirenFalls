using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension.Shells;
using System.Collections.Generic;
using System.ComponentModel;
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

        public class SpriteSheetConverter : JsonConverter<SpriteSheet> {
            public override SpriteSheet Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options) {
                JsonDocument jsonDoc = JsonDocument.ParseValue(ref reader);
                Dictionary<string, JsonElement> dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonDoc.RootElement.GetRawText());


                string texturePath = dict["texture"].GetString();
                int regionWidth = dict["regionWidth"].GetInt32();
                int regionHeight = dict["regionHeight"].GetInt32();

                return new SpriteSheet(new CompressibleTexture(texturePath), regionWidth, regionHeight);
            }

            public override void Write(Utf8JsonWriter writer, SpriteSheet value, JsonSerializerOptions options) {
                writer.WritePropertyName("texture");
                writer.WriteStringValue(value.texture);
                writer.WritePropertyName("regionWidth");
                writer.WriteNumberValue(value.regionWidth);
                writer.WritePropertyName("regionHeight");
                writer.WriteNumberValue(value.regionHeight);
            }
        }

        public static IDictionary<string, object> ObjectToDictionary(object source) {
            return ObjectToDictionary<object>(source);
        }

        public static IDictionary<string, T> ObjectToDictionary<T>(object source) {
            if (source == null)
                ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                AddPropertyToDictionary<T>(property, source, dictionary);
            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, Dictionary<string, T> dictionary) {
            object value = property.GetValue(source);
            if (IsOfType<T>(value))
                dictionary.Add(property.Name, (T)value);
        }

        private static bool IsOfType<T>(object value) {
            return value is T;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull() {
            throw new System.ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");
        }
    }
}
