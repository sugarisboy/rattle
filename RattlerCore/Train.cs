using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RattlerCore {
    public class Train : MultiStationTransport {

        public Train() {
            this.capacity = 265;
            this.averageSpeed = 68.75;
        }

        public Train(double averageSpeed, int capacity) {
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.TRAIN;
        }
    }
}