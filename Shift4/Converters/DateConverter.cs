using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shift4.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift4.Converters
{
    public class DateConverter : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        UnixDateConverter _unixDateConverter = new UnixDateConverter();
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var rawSeconds = (long)reader.Value;
            return _unixDateConverter.FromUnixTimeStamp(rawSeconds).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTime?) value;
            if (date.HasValue)
            {
                var convertedValue = _unixDateConverter.ToUnixTimeStamp(date.Value.ToUniversalTime());
                writer.WriteValue(convertedValue);
            }
        }
    }
}
