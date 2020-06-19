using System;
using System.Collections.Generic;

namespace RattlerCore {
    public class SimpleRattlerStation<T> : RattlerStation where T : RattlerTransport {
        private RattlerTransportType type;
        private List<LinkStation> links;

        public SimpleRattlerStation(string name, RattlerTransportType type) {
            this.name = name;
            this.type = type;
            this.links = new List<LinkStation>();
        }

        public RattlerTransportType Type => getType();
        public string name { get; set; }

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

        public bool hasLinkAny(RattlerStation first, RattlerStation second) {
            return links.Find(
                i => i.getA().Equals(first) && i.getB().Equals(second) ||
                     i.getA().Equals(second) && i.getB().Equals(first)
            ) != null;
        }

        public bool hasLink(RattlerTransportType type, RattlerStation first, RattlerStation second) {
            return links.Find(
                i => i.getType().Equals(type) && 
                     (
                         i.getA().Equals(first) && i.getB().Equals(second) ||
                         i.getA().Equals(second) && i.getB().Equals(first)
                     )
            ) != null;
        }

        public long id { get; set; }
    }
}