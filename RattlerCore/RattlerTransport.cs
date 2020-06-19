using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace RattlerCore {
    public interface RattlerTransport : Numerable {

        public RattlerTransportType Type { get; }
        public string name { get; set; }
        public int capacity { get; set; }
        public double averageSpeed { get; set; }

        List<RattlerStation> getStations();

        void addStation(RattlerStation station);

        void removeStation(RattlerStation station);

        bool containsStation(RattlerStation station);

        RattlerTransportType getType();
    }
}