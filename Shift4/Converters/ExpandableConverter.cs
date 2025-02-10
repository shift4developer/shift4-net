using System;
using Newtonsoft.Json;
using Shift4.Response;

namespace Shift4.Converters
{
    public class ExpandableConverter<T> : BaseObjectTypeConverter where T: BaseResponse
    {
        public override bool CanConvert(Type objectType) => objectType.IsInstanceOfType(typeof(Expandable<T>));
    

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
        {
            // Case: JSON contains a string
            return new Expandable<T> { Id = reader.Value.ToString() };
        }
        else if (reader.TokenType == JsonToken.StartObject)
        {
            var (id, deserializedObject) = convertObjectType(reader, serializer);
            return new Expandable<T> { ExpandedObject = (T)deserializedObject, Id = id};
        }

        throw new JsonSerializationException("Unexpected token type");

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}