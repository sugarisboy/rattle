using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    
    public class TransportJsonConverter : JsonConverter<RattlerTransport> {

        public override void WriteJson(JsonWriter writer, RattlerTransport value, JsonSerializer serializer) {
            writer.WriteStartObject();

            writer.WritePropertyName("capacity");
            writer.WriteValue(value.capacity);
            writer.WritePropertyName("average-speed");
            writer.WriteValue(value.averageSpeed);
            writer.WritePropertyName("type");
            writer.WriteValue(value.getType().name);

            writer.WriteEndObject();  
        }

        public override RattlerTransport ReadJson(JsonReader reader, Type objectType, RattlerTransport existingValue,
            bool hasExistingValue, JsonSerializer serializer
        ) {
            Console.WriteLine(12345);

            if (reader.TokenType.Equals(JsonToken.StartObject)) {
                JObject obj = JObject.Load(reader);
                
                if (obj["type"] != null) {
                    string rawType = obj["type"].Value<string>();
                    RattlerTransportType type = RattlerTransportType.ofValue(rawType);
                    
                    
                    if (type.Equals(RattlerTransportType.METRO)) {
                        Metro metro = new Metro();
                        
                        if (obj["capacity"] != null)
                            metro.capacity = obj["capacity"].Value<int>();
                        
                        if (obj["average-speed"] != null)
                            metro.averageSpeed = obj["average-speed"].Value<double>();

                        return metro;
                    } else if (type.Equals(RattlerTransportType.TRAM)) {
                        Tram metro = new Tram();
                        
                        if (obj["capacity"] != null)
                            metro.capacity = obj["capacity"].Value<int>();
                        
                        if (obj["average-speed"] != null)
                            metro.averageSpeed = obj["average-speed"].Value<double>();
                        
                    } else if (type.Equals(RattlerTransportType.TRAIN)) {
                        Train metro = new Train();
                        
                        if (obj["capacity"] != null)
                            metro.capacity = obj["capacity"].Value<int>();
                        
                        if (obj["average-speed"] != null)
                            metro.averageSpeed = obj["average-speed"].Value<double>();
                        
                    } else if (type.Equals(RattlerTransportType.EXPRESS_TRAIN)) {
                        ExpressTrain metro = new ExpressTrain();
                        
                        if (obj["capacity"] != null)
                            metro.capacity = obj["capacity"].Value<int>();
                        
                        if (obj["average-speed"] != null)
                            metro.averageSpeed = obj["average-speed"].Value<double>();
                        
                    }
                }
            }
            
            throw new JsonException("Неудалось прочесть");
        }
    }
}