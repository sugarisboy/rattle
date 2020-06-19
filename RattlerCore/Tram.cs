namespace RattlerCore {
    public class Tram : MultiStationTransport {

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
    }
}