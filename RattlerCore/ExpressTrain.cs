using System;
using System.Collections.Generic;

namespace RattlerCore {
    public class ExpressTrain : RattlerTransport {
        
        private RattleStation A;
        private RattleStation B;
        
        public int capacity { get; set; }
        public double averageSpeed { get; set; }


        public ExpressTrain() {
            this.capacity = 56;
            this.averageSpeed = 47.5;
        }

        public ExpressTrain(RattleStation A, RattleStation B) {
            this.capacity = 56;
            this.averageSpeed = 47.5;
            this.A = A;
            this.B = B;
        }

        public ExpressTrain(RattleStation A, RattleStation B, double averageSpeed, int capacity) {
            this.capacity = capacity;
            this.averageSpeed = averageSpeed;
            this.A = A;
            this.B = B;
        }

        public ExpressTrain(double averageSpeed, int capacity) {
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        
        public RattlerTransportType getType() {
            return RattlerTransportType.EXPRESS_TRAIN;
        }

        public List<RattleStation> getStations() {
            List<RattleStation> stations = new List<RattleStation>();
            if (A != null)
                stations.Add(A);
            if (B != null)
                stations.Add(B);
            return stations;
        }

        public void addStation(RattleStation station) {
            if (A == null)
                this.A = station;
            else if (B == null)
                this.B = station;
            else
                throw new ApplicationException("Данный тип может иметь лишь две остановки");
        }

        public void removeStation(RattleStation station) {
            if (station.Equals(B)) {
                this.B = null;
            } else if (station.Equals(A)) {
                this.A = null;
            }
        }

        public bool containsStation(RattleStation station) {
            return station != null && (station.Equals(A) || station.Equals(B));
        }
    }
}