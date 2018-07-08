using Newtonsoft.Json.Converters;
using System;

namespace Newtonsoft.Json
{
    internal class DateTimeConverter : DateTimeConverterBase
    {
        #region Constructor
        public DateTimeConverter()
        {
        }
        #endregion

        #region Public Methods
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value ?? DateTime.MinValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((DateTime)value == DateTime.MinValue)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value);
            }
        }
        #endregion
    }
}