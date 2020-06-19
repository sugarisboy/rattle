using System.Linq;

namespace RattlerCore {
    public class RattlerTransportType : Numerable {
        public static RattlerTransportType TRAIN;
        public static RattlerTransportType METRO;
        public static RattlerTransportType TRAM;
        public static RattlerTransportType EXPRESS_TRAIN;
        public static RattlerTransportType COMPLEX;

        private static RattlerTransportType[] values;

        public string name { get; }
        public long id { get; set; }


        private RattlerTransportType(long id, string name) {
            this.name = name;
            this.id = id;
        }

        public override string ToString() {
            return name;
        }

        public static void init() {
            values = new[] {
                TRAIN = new RattlerTransportType(0, "Train"),
                METRO = new RattlerTransportType(1, "Metro"),
                TRAM = new RattlerTransportType(2, "Tram"),
                EXPRESS_TRAIN = new RattlerTransportType(3, "ExpressTrain"),
                COMPLEX = new RattlerTransportType(4, "Complex")
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