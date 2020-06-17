using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public class Train : MultiStationTransport {
        private int capacity;
        private double averageSpeed;

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

        public override int getCapacity() {
            return capacity;
        }

        public override double getAverageSpeed() {
            return averageSpeed;
        }
    }
}