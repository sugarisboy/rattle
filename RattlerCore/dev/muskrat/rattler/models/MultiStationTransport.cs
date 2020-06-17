using System;
using System.Collections;
using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public abstract class MultiStationTransport : RattlerTransport {

        private List<Station> stations;
        
        public abstract RattlerTransportType getType();

        public List<Station> getStations() {
            List<Station> copy = new List<Station>();
            foreach (var station in stations) {
                copy.Add(station);
            }
            return copy;
        }

        public void addStation(Station station) {
            if (!station.getType().Equals(getType()))
                throw new ArgumentException("Тип станции не подходит для данного транспорта!");
            stations.Add(station);
        }

        public void removeStation(Station station) {
            stations.Remove(station);
        }

        public bool containsStation(Station station) {
            return stations.Contains(station);
        }

        public abstract int getCapacity();

        public abstract double getAverageSpeed();
    }
}