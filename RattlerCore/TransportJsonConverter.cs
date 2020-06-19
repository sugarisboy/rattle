using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class TransportJsonConverter : JsonConverter<RattlerTransport> {

        private RattlerCore core;

        public TransportJsonConverter(RattlerCore core) {
            this.core = core;
        }
        
        public override void WriteJson(JsonWriter writer, RattlerTransport value, JsonSerializer serializer) {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteValue(value.id);
            writer.WritePropertyName("capacity");
            writer.WriteValue(value.capacity);
            writer.WritePropertyName("average-speed");
            writer.WriteValue(value.averageSpeed);
            writer.WritePropertyName("type");
            writer.WriteValue(value.getType().name);
            writer.WritePropertyName("name");
            writer.WriteValue(value.name);

            List<RattleStation> stations = value.getStations();
            int count = stations.Count;
            long[] stationsId = new long[count];
            for (var i = 0; i < stations.Count; i++)
                stationsId[i] = stations[i].id;

            writer.WritePropertyName("stations");
            writer.WriteStartArray();
            foreach (long item in stationsId)
            {
                serializer.Serialize(writer, item);
            }
            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        public override RattlerTransport ReadJson(JsonReader reader, Type objectType, RattlerTransport existingValue,
            bool hasExistingValue, JsonSerializer serializer
        ) {
            if (reader.TokenType.Equals(JsonToken.StartObject)) {
                JObject obj = JObject.Load(reader);

                if (obj["type"] != null) {
                    string rawType = obj["type"].Value<string>();
                    RattlerTransportType type = RattlerTransportType.ofValue(rawType);

                    int id = obj["id"] != null ? obj["id"].Value<int>() : 0;
                    string name = obj["name"] != null ? obj["name"].Value<string>() : "unnamed";
                    int capacity = obj["capacity"] != null ? obj["capacity"].Value<int>() : 1;
                    double averageSpeed = obj["average-speed"] != null ? obj["average-speed"].Value<double>() : 1;
                    long[] stationsId = obj["stations"] != null ? JsonConvert.DeserializeObject<long[]>(obj["stations"].ToString()) : new long[]{};

                    RattlerTransport transport = null;
                    
                    if (type.Equals(RattlerTransportType.METRO)) {
                        transport = new Metro(name);
                    } else if (type.Equals(RattlerTransportType.TRAM)) {
                        transport = new Tram(name);
                    } else if (type.Equals(RattlerTransportType.TRAIN)) {
                        transport = new Train(name);
                    } else if (type.Equals(RattlerTransportType.EXPRESS_TRAIN)) {
                        transport = new ExpressTrain(name);
                    }

                    if (transport != null) {
                        transport.id = id;
                        transport.capacity = capacity;
                        transport.averageSpeed = averageSpeed;
                        
                        addStations(stationsId, transport);
                    }

                    return transport;
                }
            }

            throw new JsonException("Неудалось прочесть");
        }

        private void addStations(long[] stationsId, RattlerTransport transport) {
            foreach (long id in stationsId) {
                RattleStation station = core.stationService.getById(id);
                transport.addStation(station);
            }
        }
    }
}