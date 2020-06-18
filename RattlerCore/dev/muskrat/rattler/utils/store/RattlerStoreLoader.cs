using System;
using System.IO;

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
        }

        public void saveData() { }
    }
}