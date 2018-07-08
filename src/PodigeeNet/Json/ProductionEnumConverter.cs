using Newtonsoft.Json.Converters;
using PodigeeNet.Data;
using System;

namespace Newtonsoft.Json
{
    internal class ProductionEnumConverter : StringEnumConverter
    {
        #region Constructor
        public ProductionEnumConverter()
        {
        }
        #endregion

        #region Public Methods
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value == null
                ? ProductionState.Null
                : base.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((ProductionState)value == ProductionState.Null)
            {
                writer.WriteNull();
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
        #endregion
    }
}