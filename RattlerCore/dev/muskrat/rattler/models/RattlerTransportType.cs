namespace RattlerCore.dev.muskrat.rattler.models {
    public class RattlerTransportType {
        
        public static RattlerTransportType TRAIN;
        public static RattlerTransportType METRO;
        public static RattlerTransportType TRAM;
        public static RattlerTransportType EXPRESS_TRAIN;
        public static RattlerTransportType COMPLEX;
        
        private static RattlerTransportType[] values;

        private string name;

        private RattlerTransportType(string name) {
            this.name = name;
        }

        public static void init() {
            values = new[] {
                TRAIN = new RattlerTransportType("Train"),
                METRO = new RattlerTransportType("Metro"),
                TRAM = new RattlerTransportType("Tram"),
                EXPRESS_TRAIN = new RattlerTransportType("ExpressTrain"),
                COMPLEX = new RattlerTransportType("Complex")
            };
        }

        public static RattlerTransportType[] getValues() {
            return values.Clone() as RattlerTransportType[];
        }
    }
}