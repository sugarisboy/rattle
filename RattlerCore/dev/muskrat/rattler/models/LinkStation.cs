using System;
using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public class LinkStation {
        
        private Station A;

        private Station B;

        public float distance;

        public LinkStation(Station A, Station B, float distance) {
            if (!A.getType().Equals(B.getType())) {
                throw new ArgumentException("Соедиенение станций возможно лишь когда они одного типа!");
            }

            if (distance <= 0) {
                throw new ArgumentException("Дистанция должна быть положительной");
            }

            this.A = A;
            this.B = B;
            this.distance = distance;
        }

        public Station getA() {
            return A;
        }

        public Station getB() {
            return B;
        }
    }
}