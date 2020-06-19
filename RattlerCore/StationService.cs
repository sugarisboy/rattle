using System;
using System.Collections.Generic;
using System.Linq;

namespace RattlerCore {
    public class StationService : RattleService {

        public StationService(RattlerCore core) : base(core) {
        }

        public void addStation(RattlerStation station) {
            if (station.id == 0) {
                station.id = core.store.maxStationId++;
            } else {
                if (station.id > core.store.maxStationId) {
                    core.store.maxStationId = station.id + 1;
                }
            }
            core.store.stations.Add(station);
        }

        public void removeStation(RattlerStation station) {
            if (core.store.transports.Count(i => i.getStations().Contains(station)) != 0) {
                throw new ApplicationException("Нельзя удалить станцию, так как ее используют некоторые маршруты!");
            }

            core.store.stations.Remove(station);

            List<LinkStation> forDelete = new List<LinkStation>();
            
            foreach (var link in core.store.links) {
                if (link.getA().Equals(station) || link.getB().Equals(station)) {
                    forDelete.Add(link);
                }
            }
            
            forDelete.ForEach(i => core.stationService.removeLink(i));
        }
        
        public LinkStation addLink(LinkStation linkStation) {
            RattlerStation A = linkStation.getA();
            RattlerStation B = linkStation.getB();
            
            A.addLink(linkStation);

            try {
                B.addLink(linkStation);
            } catch (Exception ex) {
                A.removeLink(linkStation);
                throw;
            }

            core.store.links.Add(linkStation);
            
            return linkStation;
        }

        public void removeLink(LinkStation linkStation) {
            linkStation.getA().removeLink(linkStation);
            linkStation.getB().removeLink(linkStation);
            core.store.links.Remove(linkStation);
        }

        public RattlerStation getById(long id) {
            try {
                return core.store.stations.First(i => i.id == id);
            } catch (InvalidOperationException e) {
                return null;
            }
        }
    }
}