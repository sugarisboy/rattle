using System;

namespace RattlerCore {
    public class LinkStation {

        private RattleStation A;
        private RattleStation B;
        private RattlerTransportType type;

        public float distance;

        public LinkStation(RattleStation A, RattleStation B, float distance) {
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

        public RattleStation getA() {
            return A;
        }

        public RattleStation getB() {
            return B;
        }

        public RattlerTransportType getType() {
            return type;
        }

        public LinkStation init() {
            A.addLink(this);

            try {
                B.addLink(this);
            } catch (Exception ex) {
                A.removeLink(this);
                throw;
            }

            return this;
        }
    }
}