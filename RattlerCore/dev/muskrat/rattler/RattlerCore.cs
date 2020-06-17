namespace RattlerCore.dev.muskrat.rattler {
    public class RattlerCore {
        public RattlerCore() {
            
        }

        public void init() {
            RattlerStore store = new RattlerStore();
            store.loadData();
        }
    }
}