using System;
using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public class ExpressTrain : RattlerTransport {
        
        private Station A;
        private Station B;
        private int capacity;
        private double averageSpeed;

        public ExpressTrain() {
            this.capacity = 56;
            this.averageSpeed = 47.5;
        }

        public ExpressTrain(Station A, Station B) {
            this.capacity = 56;
            this.averageSpeed = 47.5;
            this.A = A;
            this.B = B;
        }

        public ExpressTrain(Station A, Station B, double averageSpeed, int capacity) {
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

        public List<Station> getStations() {
            List<Station> stations = new List<Station>();
            if (A != null)
                stations.Add(A);
            if (B != null)
                stations.Add(B);
            return stations;
        }

        public void addStation(Station station) {
            if (A == null)
                this.A = station;
            else if (B == null)
                this.B = station;
            else
                throw new ApplicationException("Данный тип может иметь лишь две остановки");
        }

        public void removeStation(Station station) {
            if (station.Equals(B)) {
                this.B = null;
            } else if (station.Equals(A)) {
                this.A = null;
            }
        }

        public bool containsStation(Station station) {
            return station != null && (station.Equals(A) || station.Equals(B));
        }

        public int getCapacity() {
            return capacity;
        }

        public double getAverageSpeed() {
            return averageSpeed;
        }
    }
}