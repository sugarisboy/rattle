namespace RattlerCore.dev.muskrat.rattler.models {
    public class Metro : MultiStationTransport {
        
        private int capacity;
        private double averageSpeed;

        public Metro() {
            this.capacity = 400;
            this.averageSpeed = 94.35;
        }

        public Metro(double averageSpeed, int capacity) {
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.METRO;
        }

        public override int getCapacity() {
            return capacity;
        }

        public override double getAverageSpeed() {
            return averageSpeed;
        }
    }
}