using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RattlerCore {
    public class RattlerStoreLoader : RattleService {

        private static string ABSOLUTHE_PATH = @"C:\Users\sugar\RiderProjects\Rattler\";
        private static string SETTINGS_FILE_NAME = "settings.json";

        private RattlerStore store;

        public RattlerStoreLoader(RattlerCore core) : base(core) {
            this.store = core.store;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings {
                
                Converters = new List<JsonConverter> {
                    new TransportJsonConverter(core),
                    new StationJsonConverter(),
                    new LinkJsonConverter(core),
                    new StoreJsonConverter(core)
                }
            };
        }

        public void loadData() {
            string path = ABSOLUTHE_PATH + SETTINGS_FILE_NAME;
            bool exists = File.Exists(path);

            string rawJson;

            if (!exists) {
                File.Create(path).Close();
                rawJson = "{}";
                File.WriteAllText(path, rawJson);
            } else {
                rawJson = File.ReadAllText(path);
            }

            RattlerStore loaded = JsonConvert.DeserializeObject<RattlerStore>(rawJson);

            //demoData();
        }

        public void saveData() {
            string path = ABSOLUTHE_PATH + SETTINGS_FILE_NAME;
            string json = JsonConvert.SerializeObject(store, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public void demoData() {
            SimpleRattlerStation<Metro> station1 = new SimpleRattlerStation<Metro>("Yaroslavl", RattlerTransportType.METRO);
            SimpleRattlerStation<Metro> station2 = new SimpleRattlerStation<Metro>("Rybinsk", RattlerTransportType.METRO);
            
            core.stationService.addStation(station1);
            core.stationService.addStation(station2);

            Metro metro = new Metro("red way");
            core.transportService.addTransport(metro);

            Train train = new Train("11c");
            core.transportService.addTransport(train);

            
            LinkStation link = new LinkStation(station1, station2, 10);
            core.stationService.addLink(link);

            metro.addStation(station1);
            metro.addStation(station2);
        }
    }
}