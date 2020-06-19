using System.Collections.Generic;

namespace RattlerCore {
    public class TransportService : RattleService {

        private List<RattlerTransport> transports;
        
        public TransportService(RattlerCore core) : base(core) {
            transports = core.store.transports;
        }

        public void addTransport(RattlerTransport transport) {
            transports.Add(transport);
        }

        public void removeTransport(RattlerTransport transport) {
            transports.Add(transport);
        }
    }
}