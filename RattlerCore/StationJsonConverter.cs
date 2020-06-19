using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class StationJsonConverter : JsonConverter<RattleStation> {
        public override void WriteJson(JsonWriter writer, RattleStation value, JsonSerializer serializer) {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteValue(value.id);
            writer.WritePropertyName("name");
            writer.WriteValue(value.name);
            writer.WritePropertyName("type");
            writer.WriteValue(value.getType().name);
            writer.WriteEndObject();
        }

        public override RattleStation ReadJson(
            JsonReader reader, Type objectType, RattleStation existingValue, bool hasExistingValue,
            JsonSerializer serializer
        ) {
            if (reader.TokenType.Equals(JsonToken.StartObject)) {
                JObject obj = JObject.Load(reader);

                string rawType = obj["type"].Value<string>();
                RattlerTransportType type = RattlerTransportType.ofValue(rawType);

                int id = obj["id"] != null ? obj["id"].Value<int>() : 0;
                string name = obj["name"] != null ? obj["name"].Value<string>() : "unnamed";

                if (type.Equals(RattlerTransportType.COMPLEX)) {
                    ComplexRattleStation station = new ComplexRattleStation(name);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.METRO)) {
                    SimpleRattleStation<Metro> station = new SimpleRattleStation<Metro>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.TRAIN)) {
                    SimpleRattleStation<Train> station = new SimpleRattleStation<Train>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.TRAM)) {
                    SimpleRattleStation<Tram> station = new SimpleRattleStation<Tram>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.EXPRESS_TRAIN)) {
                    SimpleRattleStation<ExpressTrain> station = new SimpleRattleStation<ExpressTrain>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                }
            }

            throw new JsonException("Неудалось прочесть");
        }
    }
}