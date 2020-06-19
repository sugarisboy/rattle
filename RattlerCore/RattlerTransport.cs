using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace RattlerCore {
    public interface RattlerTransport {
        public int capacity { get; set; }
        public double averageSpeed { get; set; }

        RattlerTransportType getType();

        List<RattleStation> getStations();

        void addStation(RattleStation station);

        void removeStation(RattleStation station);

        bool containsStation(RattleStation station);
    }
}