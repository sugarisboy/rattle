﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public abstract class MultiStationTransport : RattlerTransport {
        private List<RattleStation> stations;

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

            RattleStation last = stations[stations.Count - 1];
            if (last.hasLink(getType(), last, station)) {
                stations.Add(station);
            } else {
                throw new ApplicationException("Путь между станциями не найден!");
            }
        }

        public void removeStation(RattleStation station) {
            stations.Remove(station);
        }

        public bool containsStation(RattleStation station) {
            return stations.Contains(station);
        }

        public abstract int getCapacity();

        public abstract double getAverageSpeed();
    }
}