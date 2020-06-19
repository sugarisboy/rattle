using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class StoreJsonConverter : JsonConverter<RattlerStore> {
        private RattlerCore core;

        private LinkJsonConverter linkConverter;
        private StationJsonConverter stationConverter;
        private TransportJsonConverter transportConverter;

        public StoreJsonConverter(RattlerCore core) {
            this.core = core;
            linkConverter = new LinkJsonConverter(core);
            stationConverter = new StationJsonConverter();
            transportConverter = new TransportJsonConverter(core);
        }

        public override void WriteJson(JsonWriter writer, RattlerStore value, JsonSerializer serializer) {
            writer.WriteStartObject();

            writer.WritePropertyName("max-transport-id");
            writer.WriteValue(core.store.maxTransportId);

            writer.WritePropertyName("max-station-id");
            writer.WriteValue(core.store.maxStationId);

            // Write stations
            writer.WritePropertyName("stations");
            writer.WriteStartArray();
            core.store.stations.ForEach(i => stationConverter.WriteJson(writer, i, serializer));
            writer.WriteEndArray();

            // Write transport
            writer.WritePropertyName("transports");
            writer.WriteStartArray();
            core.store.transports.ForEach(i => transportConverter.WriteJson(writer, i, serializer));
            writer.WriteEndArray();

            // Write stations
            writer.WritePropertyName("links");
            writer.WriteStartArray();
            core.store.links.ForEach(i => linkConverter.WriteJson(writer, i, serializer));
            writer.WriteEndArray();

            writer.WriteEndObject();
        }

        public override RattlerStore ReadJson(
            JsonReader reader, Type objectType, RattlerStore existingValue, bool hasExistingValue,
            JsonSerializer serializer
        ) {
            if (reader.TokenType.Equals(JsonToken.StartObject)) {
                JObject obj = JObject.Load(reader);

                core.store.maxTransportId = obj["max-transport-id"] != null ? obj["max-transport-id"].Value<long>() : 1;
                core.store.maxTransportId = obj["max-station-id"] != null ? obj["max-station-id"].Value<long>() : 1;
                
                // Load stations
                List<RattlerStation> stations = new List<RattlerStation>();
                if (obj["stations"] != null) {
                    foreach (JToken jToken in obj["stations"]) {
                        RattlerStation station = JsonConvert.DeserializeObject<RattlerStation>(jToken.ToString());
                        core.stationService.addStation(station);
                    }
                }
                
                // Load links
                List<LinkStation> links = new List<LinkStation>();
                if (obj["links"] != null) {
                    foreach (JToken jToken in obj["links"]) {
                        LinkStation link = JsonConvert.DeserializeObject<LinkStation>(jToken.ToString());
                        core.stationService.addLink(link);
                    }
                }

                // Load transport
                List<RattlerTransport> transports = new List<RattlerTransport>();
                if (obj["transports"] != null) {
                    foreach (JToken jToken in obj["transports"]) {
                        RattlerTransport transport = JsonConvert.DeserializeObject<RattlerTransport>(jToken.ToString());
                        core.transportService.addTransport(transport);
                    }
                }

                return core.store;
            }

            throw new JsonException("Неудалось прочесть");
        }
    }
}