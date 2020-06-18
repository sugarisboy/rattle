using RattlerCore.dev.muskrat.rattler.models;

namespace RattlerCore.dev.muskrat.rattler {
    public class RattlerCore {
        public RattleStore store { get; private set; }

        private RattlerStoreLoader storeLoader;

        public RattlerCore() { }

        public void init() {
            RattlerTransportType.init();

            store = new RattleStore();
            storeLoader = new RattlerStoreLoader(store);
            storeLoader.loadData();
        }
    }
}