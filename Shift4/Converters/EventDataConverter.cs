using Newtonsoft.Json;
using System;

namespace Shift4.Converters
{
    public class EventDataConverter : BaseObjectTypeConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return convertObjectType(reader, serializer).Item2;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}
