using System.Collections.Generic;

namespace RattlerCore {
    public class RattlerStore {
        public List<RattlerTransport> transports { get; set; }
        public List<RattleStation> stations { get; set; }
        
        public List<LinkStation> links { get; set; }

        public long maxTransportId = 1;
        public long maxStationId = 1;

        public RattlerStore() {
            this.stations = new List<RattleStation>();
            this.transports = new List<RattlerTransport>();
            this.links = new List<LinkStation>();
        }
    }
}