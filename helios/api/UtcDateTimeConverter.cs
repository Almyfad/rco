using System.Text.Json;
using System.Text.Json.Serialization;

namespace Helios
{
    /// <summary>
    /// Convertisseur JSON pour s'assurer que les DateTime sont toujours sérialisés en UTC
    /// </summary>
    public class UtcDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetDateTime();
            // Convertir en UTC si ce n'est pas déjà le cas
            return value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // S'assurer que la date est en UTC avant de la sérialiser
            var utcValue = value.Kind == DateTimeKind.Utc ? value : value.ToUniversalTime();
            // Écrire avec le format ISO 8601 incluant le 'Z' pour UTC
            writer.WriteStringValue(utcValue);
        }
    }
}
