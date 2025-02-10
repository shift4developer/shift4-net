
using System;
using Newtonsoft.Json;
using Shift4.Request;

namespace Shift4.Converters
{
    public class ExpandConverter : JsonConverter<Expand>
    {
        public override Expand ReadJson(JsonReader reader, Type objectType, Expand existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return null;
        }

        public override void WriteJson(JsonWriter writer, Expand value, JsonSerializer serializer)
        {
            if (value == null || value.Paths.Count == 0) {
                return;
            }
            writer.WriteStartArray();
            value.Paths.ForEach(path => {
                writer.WriteValue(path);
            });
            writer.WriteEndArray();
        }
    }
}