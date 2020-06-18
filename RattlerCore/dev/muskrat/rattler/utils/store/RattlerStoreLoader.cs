using System;
using System.IO;
using Newtonsoft.Json;
using RattlerCore.dev.muskrat.rattler.models;

namespace RattlerCore.dev.muskrat.rattler {
    public class RattlerStoreLoader {
        private static string SETTINGS_FILE_NAME = "settings.json";

        private RattleStore store;

        public RattlerStoreLoader(RattleStore store) {
            this.store = store;
        }

        public void loadData() {
            string path = @"../" + SETTINGS_FILE_NAME;
            bool exists = File.Exists(path);

            string rawJson;

            if (!exists) {
                File.Create(path);
                rawJson = "{}";
            } else {
                rawJson = File.ReadAllText(path);
            }
            
            demoData();

            JsonConvert.DeserializeObject(rawJson);
        }

        public void saveData() {
            Console.WriteLine(JsonConvert.SerializeObject(store));
        }

        public void demoData() {
            SimpleRattleStation<Metro> station1 = new SimpleRattleStation<Metro>(RattlerTransportType.METRO);
            SimpleRattleStation<Metro> station2 = new SimpleRattleStation<Metro>(RattlerTransportType.METRO);
            store.stations.Add(station1);
            store.stations.Add(station2);
            
            Metro metro = new Metro();
            store.transports.Add(metro);

            LinkStation link = new LinkStation(station1, station2, 10).init();

            metro.addStation(station1);
            metro.addStation(station2);
        }
    }
}