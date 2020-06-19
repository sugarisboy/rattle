using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class LinkJsonConverter : JsonConverter<LinkStation> {
        private RattlerCore core;

        public LinkJsonConverter(RattlerCore core) {
            this.core = core;
        }
        
        public override void WriteJson(JsonWriter writer, LinkStation value, JsonSerializer serializer) {
            writer.WriteStartObject();

            writer.WritePropertyName("station1");
            writer.WriteValue(value.getA().id);

            writer.WritePropertyName("station2");
            writer.WriteValue(value.getB().id);

            writer.WritePropertyName("distance");
            writer.WriteValue(value.distance);

            writer.WritePropertyName("type");
            writer.WriteValue(value.getType().name);

            writer.WriteEndObject();
        }

        public override LinkStation ReadJson(
            JsonReader reader, Type objectType, LinkStation existingValue, bool hasExistingValue,
            JsonSerializer serializer
        ) {
            if (reader.TokenType.Equals(JsonToken.StartObject)) {

                JObject obj = JObject.Load(reader);
                
                string rawType = obj["type"].Value<string>();
                RattlerTransportType type = RattlerTransportType.ofValue(rawType);
                
                int id1 = obj["station1"] != null ? obj["station1"].Value<int>() : 0;
                int id2 = obj["station2"] != null ? obj["station2"].Value<int>() : 0;
                double distance = obj["station2"] != null ? obj["distance"].Value<double>() : 0;

                RattleStation station1 = core.stationService.getById(id1);
                RattleStation station2 = core.stationService.getById(id2);

                LinkStation linkStation = new LinkStation(station1, station2, distance);

                return linkStation;
            }
            
            throw new JsonException("Неудалось прочесть");
        }
    }
}