using System;

namespace RattlerCore {
    public class LinkStation {

        private RattlerStation A;
        private RattlerStation B;
        private RattlerTransportType type;

        public double distance;

        public LinkStation(RattlerStation A, RattlerStation B, double distance) {
            if (A.Equals(B))
                throw new ArgumentException("Станция A и станция B одинаковы!");

            if (!A.getType().Equals(B.getType())) {
                throw new ArgumentException("Соедиенение станций возможно лишь когда они одного типа!");
            }

            if (distance <= 0) {
                throw new ArgumentException("Дистанция должна быть положительной");
            }

            this.type = A.getType();

            this.A = A;
            this.B = B;
            this.distance = distance;
        }

        public RattlerStation getA() {
            return A;
        }

        public RattlerStation getB() {
            return B;
        }

        public RattlerTransportType getType() {
            return type;
        }
    }
}