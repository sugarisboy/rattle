using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class StationJsonConverter : JsonConverter<RattlerStation> {
        public override void WriteJson(JsonWriter writer, RattlerStation value, JsonSerializer serializer) {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteValue(value.id);
            writer.WritePropertyName("name");
            writer.WriteValue(value.name);
            writer.WritePropertyName("type");
            writer.WriteValue(value.getType().name);
            writer.WriteEndObject();
        }

        public override RattlerStation ReadJson(
            JsonReader reader, Type objectType, RattlerStation existingValue, bool hasExistingValue,
            JsonSerializer serializer
        ) {
            if (reader.TokenType.Equals(JsonToken.StartObject)) {
                JObject obj = JObject.Load(reader);

                string rawType = obj["type"].Value<string>();
                RattlerTransportType type = RattlerTransportType.ofValue(rawType);

                int id = obj["id"] != null ? obj["id"].Value<int>() : 0;
                string name = obj["name"] != null ? obj["name"].Value<string>() : "unnamed";

                if (type.Equals(RattlerTransportType.COMPLEX)) {
                    ComplexRattlerStation station = new ComplexRattlerStation(name);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.METRO)) {
                    SimpleRattlerStation<Metro> station = new SimpleRattlerStation<Metro>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.TRAIN)) {
                    SimpleRattlerStation<Train> station = new SimpleRattlerStation<Train>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.TRAM)) {
                    SimpleRattlerStation<Tram> station = new SimpleRattlerStation<Tram>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                } else if (type.Equals(RattlerTransportType.EXPRESS_TRAIN)) {
                    SimpleRattlerStation<ExpressTrain> station = new SimpleRattlerStation<ExpressTrain>(name, type);
                    station.id = id;
                    station.name = name;
                    return station;
                }
            }

            throw new JsonException("Неудалось прочесть");
        }
    }
}