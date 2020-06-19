
namespace RattlerCore {
    public class RattlerCore {
        public RattlerStore store { get; private set; }

        private RattlerStoreLoader storeLoader;

        public StationService stationService;
        public TransportService transportService;

        public RattlerCore() {
            init();
        }

        public void init() {
            RattlerTransportType.init();

            stationService = new StationService(this);
            transportService = new TransportService(this);
            
            store = new RattlerStore();
            storeLoader = new RattlerStoreLoader(this);
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