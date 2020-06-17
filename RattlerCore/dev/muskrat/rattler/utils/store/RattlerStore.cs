using System.IO;

namespace RattlerCore.dev.muskrat.rattler {
    public class RattlerStore {
        private const string FileName = "store.json";

        public RattlerStore() { }

        public void loadData() {
            string path = @"../" + FileName;
            bool exists = File.Exists(path);

            string rawJson;
            
            if (!exists) {
                File.Create(path);
                rawJson = "{}";
            }
            else {
                rawJson = File.ReadAllText(path);
            }
        }

        public void saveData() { }
    }
}