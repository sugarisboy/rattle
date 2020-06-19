
namespace RattlerCore {
    public class RattlerCore {
        public RattlerStore store { get; private set; }

        private RattlerStoreLoader storeLoader;

        public RattlerCore() {
            init();
        }

        public void init() {
            RattlerTransportType.init();

            store = new RattlerStore();
            storeLoader = new RattlerStoreLoader(store);
            storeLoader.loadData();
        }

        public void save() {
            storeLoader.saveData();
        }

        public void disable() {
            save();
        }
    }
}