using System.Collections.Generic;

namespace RattlerCore {
    public class StationService : RattleService {
        private List<RattleStation> stations;

        public StationService(RattlerCore core) : base(core) {
            stations = core.store.stations;
        }

        public void addTransport(RattleStation station) {
            stations.Add(station);
        }

        public void removeTransport(RattleStation station) {
            stations.Add(station);
        }
    }
}