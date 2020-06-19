using System.Collections.Generic;

namespace RattlerCore {
    public class TransportService : RattleService {

        public TransportService(RattlerCore core) : base(core) {
            
        }

        public void addTransport(RattlerTransport transport) {
            if (transport.id == 0) {
                transport.id = core.store.maxTransportId++;
            } else {
                if (transport.id > core.store.maxTransportId) {
                    core.store.maxTransportId = transport.id + 1;
                }
            }
            core.store.transports.Add(transport);
        }

        public void removeTransport(RattlerTransport transport) {
            core.store.transports.Remove(transport);
        }
    }
}