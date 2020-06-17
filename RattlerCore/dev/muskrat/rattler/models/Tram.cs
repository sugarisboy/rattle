namespace RattlerCore.dev.muskrat.rattler.models {
    public class Tram : MultiStationTransport {
        
        private int capacity;
        private double averageSpeed;

        public Tram() {
            this.capacity = 56;
            this.averageSpeed = 47.5;
        }

        public Tram(double averageSpeed, int capacity) {
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.TRAM;
        }

        public override int getCapacity() {
            return capacity;
        }

        public override double getAverageSpeed() {
            return averageSpeed;
        }
    }
}