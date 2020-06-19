namespace RattlerCore {
    public class Tram : MultiStationTransport {

        public Tram(string name) {
            this.name = name;
            this.capacity = 56;
            this.averageSpeed = 47.5;
        }

        public Tram(string name, double averageSpeed, int capacity) {
            this.name = name;
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.TRAM;
        }
    }
}