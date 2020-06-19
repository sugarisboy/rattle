using System.Linq;

namespace RattlerCore {
    public class RattlerTransportType {
        public static RattlerTransportType TRAIN;
        public static RattlerTransportType METRO;
        public static RattlerTransportType TRAM;
        public static RattlerTransportType EXPRESS_TRAIN;
        public static RattlerTransportType COMPLEX;

        private static RattlerTransportType[] values;

        public string name;

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

        public static RattlerTransportType ofValue(string value) {
            foreach (RattlerTransportType type in values) {
                if (type.name.ToLower().Equals(value.ToLower())) {
                    return type;
                }
            }

            return null;
        }
    }
}