using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RattlerCore {
    public abstract class MultiStationTransport : RattlerTransport {
        private List<RattlerStation> stations = new List<RattlerStation>();

        public abstract RattlerTransportType Type { get; }
        public string name { get; set; }
        public int capacity { get; set; }
        public double averageSpeed { get; set; }

        public List<RattlerStation> getStations() {
            List<RattlerStation> copy = new List<RattlerStation>();
            foreach (var station in stations) {
                copy.Add(station);
            }

            return copy;
        }

        public void addStation(RattlerStation station) {
            if (!station.getType().Equals(getType()))
                throw new ArgumentException("Тип станции не подходит для данного транспорта!");

            if (stations.Count > 0) {
                RattlerStation last = stations[stations.Count - 1];
                if (last.hasLink(getType(), last, station)) {
                    stations.Add(station);
                } else {
                    throw new ApplicationException("Путь между станциями не найден!");
                }
            } else {
                stations.Add(station);
            }
        }

        public void removeStation(RattlerStation station) {
            stations.Remove(station);
        }

        public bool containsStation(RattlerStation station) {
            return stations.Contains(station);
        }

        public abstract RattlerTransportType getType();

        public long id { get; set; }
    }
}