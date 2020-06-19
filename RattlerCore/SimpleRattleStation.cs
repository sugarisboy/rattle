using System;
using System.Collections.Generic;

namespace RattlerCore {
    public class SimpleRattleStation<T> : RattleStation where T : RattlerTransport {
        private RattlerTransportType type;
        private List<LinkStation> links;

        public SimpleRattleStation(RattlerTransportType type) {
            this.type = type;
            this.links = new List<LinkStation>();
        }

        public RattlerTransportType getType() {
            return type;
        }

        public List<LinkStation> getLinks() {
            List<LinkStation> copy = new List<LinkStation>();
            copy.ForEach(i => copy.Add(i));
            return copy;
        }

        public void addLink(LinkStation linkStation) {
            if (links.Contains(linkStation) || hasLink(linkStation.getType(), linkStation.getA(), linkStation.getB()))
                throw new ApplicationException("Данная связь уже установлена");
            links.Add(linkStation);
        }

        public void removeLink(LinkStation linkStation) {
            links.Remove(linkStation);
        }

        public bool hasLinkAny(RattleStation first, RattleStation second) {
            return links.Find(
                i => i.getA().Equals(first) && i.getB().Equals(second) ||
                     i.getA().Equals(second) && i.getB().Equals(first)
            ) != null;
        }

        public bool hasLink(RattlerTransportType type, RattleStation first, RattleStation second) {
            return links.Find(
                i => i.getType().Equals(type) && 
                     (
                         i.getA().Equals(first) && i.getB().Equals(second) ||
                         i.getA().Equals(second) && i.getB().Equals(first)
                     )
            ) != null;
        }
    }
}