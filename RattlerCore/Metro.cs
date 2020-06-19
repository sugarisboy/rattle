namespace RattlerCore {
    public class Metro : MultiStationTransport {

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
    }
}