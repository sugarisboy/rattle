using RattlerCore.dev.muskrat.rattler.models;

namespace RattlerCore.dev.muskrat.rattler {
    public class RattlerCore {
        public RattlerCore() {
            
        }

        public void init() {
            RattlerTransportType.init();
            
            RattlerStore store = new RattlerStore();
            store.loadData();
        }
    }
}