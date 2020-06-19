using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class Train : MultiStationTransport {

        public Train(string name) {
            this.name = name;
            this.capacity = 265;
            this.averageSpeed = 68.75;
        }

        public Train(string name, double averageSpeed, int capacity) {
            this.name = name;
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.TRAIN;
        }
    }
}