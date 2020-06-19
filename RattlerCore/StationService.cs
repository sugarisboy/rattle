using System;
using System.Collections.Generic;
using System.Linq;

namespace RattlerCore {
    public class StationService : RattleService {

        public StationService(RattlerCore core) : base(core) {
        }

        public void addStation(RattleStation station) {
            if (station.id == 0) {
                station.id = core.store.maxStationId++;
            } else {
                if (station.id > core.store.maxStationId) {
                    core.store.maxStationId = station.id + 1;
                }
            }
            core.store.stations.Add(station);
        }

        public void removeStation(RattleStation station) {
            core.store.stations.Add(station);
        }
        
        public LinkStation addLink(LinkStation linkStation) {
            RattleStation A = linkStation.getA();
            RattleStation B = linkStation.getB();
            
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

        public RattleStation getById(long id) {
            try {
                return core.store.stations.First(i => i.id == id);
            } catch (InvalidOperationException e) {
                return null;
            }
        }
    }
}