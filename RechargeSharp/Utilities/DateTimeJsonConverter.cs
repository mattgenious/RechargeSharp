using Newtonsoft.Json;
using System;

namespace RechargeSharp.Utilities
{
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset?>
    {
        public override DateTimeOffset? ReadJson(JsonReader reader, Type objectType, DateTimeOffset? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var dateTime = typeof(string) == reader.ValueType ? DateTime.Parse((string)reader.Value) : (DateTime)reader.Value;


            switch (dateTime.Kind)
            {
                case DateTimeKind.Local:
                    return new DateTimeOffset(dateTime);
                case DateTimeKind.Unspecified:
                    return new DateTimeOffset(dateTime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time").BaseUtcOffset);
                case DateTimeKind.Utc:
                    return new DateTimeOffset(dateTime);
            }

            return new DateTimeOffset(dateTime);
        }

        public override void WriteJson(JsonWriter writer, DateTimeOffset? value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            writer.WriteValue(value?.ToString("O"));
        }
    }
}
