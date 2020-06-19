using System.Collections.Generic;

namespace RattlerCore {
    public class RattlerStore {
        public List<RattlerTransport> transports { get; set; }
        public List<RattleStation> stations { get; set; }

        public RattlerStore() {
            this.stations = new List<RattleStation>();
            this.transports = new List<RattlerTransport>();
        }
    }
}