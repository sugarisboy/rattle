using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace RattlerCore {
    public class RattlerStoreLoader {
        private static string SETTINGS_FILE_NAME = "settings.json";

        private RattlerStore store;

        public RattlerStoreLoader(RattlerStore store) {
            this.store = store;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings {
                
                Converters = new List<JsonConverter> {new TransportJsonConverter()}
            };
        }

        public void loadData() {
            string path = @"C:\Users\sugar\RiderProjects\Rattler\" + SETTINGS_FILE_NAME;
            bool exists = File.Exists(path);

            string rawJson;

            if (!exists) {
                File.Create(path).Close();
                rawJson = "{}";
                File.WriteAllText(path, rawJson);
            } else {
                rawJson = File.ReadAllText(path);
            }

            Console.WriteLine("Read from settings:\n" + rawJson);
            RattlerStore loaded = JsonConvert.DeserializeObject<RattlerStore>(rawJson);
            
            store.stations = loaded.stations;
            store.transports = loaded.transports;

            demoData();
        }

        public void saveData() {
            Console.WriteLine(JsonConvert.SerializeObject(store, Formatting.Indented));
        }

        public void demoData() {
            SimpleRattleStation<Metro> station1 = new SimpleRattleStation<Metro>(RattlerTransportType.METRO);
            SimpleRattleStation<Metro> station2 = new SimpleRattleStation<Metro>(RattlerTransportType.METRO);
            store.stations.Add(station1);
            store.stations.Add(station2);

            Metro metro = new Metro();
            store.transports.Add(metro);

            Train train = new Train();
            store.transports.Add(train);

            LinkStation link = new LinkStation(station1, station2, 10).init();

            metro.addStation(station1);
            metro.addStation(station2);
        }
    }
}