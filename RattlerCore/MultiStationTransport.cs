using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RattlerCore {
    public abstract class MultiStationTransport : RattlerTransport {
        private List<RattleStation> stations = new List<RattleStation>();

        public string name { get; set; }
        public int capacity { get; set; }
        public double averageSpeed { get; set; }
        public abstract RattlerTransportType getType();

        public List<RattleStation> getStations() {
            List<RattleStation> copy = new List<RattleStation>();
            foreach (var station in stations) {
                copy.Add(station);
            }

            return copy;
        }

        public void addStation(RattleStation station) {
            if (!station.getType().Equals(getType()))
                throw new ArgumentException("Тип станции не подходит для данного транспорта!");

            if (stations.Count > 0) {
                RattleStation last = stations[stations.Count - 1];
                if (last.hasLink(getType(), last, station)) {
                    stations.Add(station);
                } else {
                    throw new ApplicationException("Путь между станциями не найден!");
                }
            } else {
                stations.Add(station);
            }
        }

        public void removeStation(RattleStation station) {
            stations.Remove(station);
        }

        public bool containsStation(RattleStation station) {
            return stations.Contains(station);
        }

        public long id { get; set; }
    }
}