using Newtonsoft.Json;
using System;

namespace RechargeSharp.Utilities
{
    public class DateTimeJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {


            var dateTime = typeof(string) == reader.ValueType ? DateTime.Parse((string)reader.Value) : (DateTime)reader.Value;

            switch (dateTime.Kind)
            {
                case DateTimeKind.Local:
                    return dateTime.ToUniversalTime();
                case DateTimeKind.Unspecified:
                    return new DateTimeOffset(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time").BaseUtcOffset).UtcDateTime;
                case DateTimeKind.Utc:
                    return dateTime;
            }

            return dateTime;
        }

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString("O"));
        }
    }
}
