namespace RattlerCore {
    public class Metro : MultiStationTransport {

        public Metro(string name) {
            this.name = name;
            this.capacity = 400;
            this.averageSpeed = 94.35;
        }

        public Metro(string name,double averageSpeed, int capacity) {
            this.name = name;
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public override RattlerTransportType getType() {
            return RattlerTransportType.METRO;
        }
    }
}