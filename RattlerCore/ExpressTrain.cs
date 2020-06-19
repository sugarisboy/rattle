using System;
using System.Collections.Generic;

namespace RattlerCore {
    public class ExpressTrain : RattlerTransport {
        private RattlerStation A;
        private RattlerStation B;

        public RattlerTransportType Type => getType();

        public string name { get; set; }
        public int capacity { get; set; }
        public double averageSpeed { get; set; }


        public ExpressTrain(string name) {
            this.name = name;
            this.capacity = 56;
            this.averageSpeed = 47.5;
        }

        public ExpressTrain(string name, RattlerStation A, RattlerStation B) {
            this.name = name;
            this.capacity = 56;
            this.averageSpeed = 47.5;
            this.A = A;
            this.B = B;
        }

        public ExpressTrain(RattlerStation A, RattlerStation B, double averageSpeed, int capacity) {
            this.capacity = capacity;
            this.averageSpeed = averageSpeed;
            this.A = A;
            this.B = B;
        }

        public ExpressTrain(double averageSpeed, int capacity) {
            this.averageSpeed = averageSpeed;
            this.capacity = capacity;
        }

        public List<RattlerStation> getStations() {
            List<RattlerStation> stations = new List<RattlerStation>();
            if (A != null)
                stations.Add(A);
            if (B != null)
                stations.Add(B);
            return stations;
        }

        public void addStation(RattlerStation station) {
            if (A == null)
                this.A = station;
            else if (B == null)
                this.B = station;
            else
                throw new ApplicationException("Данный тип может иметь лишь две остановки");
        }

        public void removeStation(RattlerStation station) {
            if (station.Equals(B)) {
                this.B = null;
            } else if (station.Equals(A)) {
                this.A = null;
            }
        }

        public bool containsStation(RattlerStation station) {
            return station != null && (station.Equals(A) || station.Equals(B));
        }

        public RattlerTransportType getType() {
            return RattlerTransportType.EXPRESS_TRAIN;
        }

        public long id { get; set; }
    }
}