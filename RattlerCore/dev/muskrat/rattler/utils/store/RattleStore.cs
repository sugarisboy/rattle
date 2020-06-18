using System.Collections.Generic;
using RattlerCore.dev.muskrat.rattler.models;

namespace RattlerCore.dev.muskrat.rattler {
    public class RattleStore {
        public List<RattlerTransport> transports { get; private set; }
        public List<RattleStation> stations { get; private set; }

        public RattleStore() {
            this.stations = new List<RattleStation>();
            this.transports = new List<RattlerTransport>();
        }
    }
}