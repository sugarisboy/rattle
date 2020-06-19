using System;
using System.Collections.Generic;

namespace RattlerCore {
    public class ComplexRattlerStation : RattlerStation {
        private Dictionary<RattlerTransportType, List<LinkStation>> allLinks;

        public RattlerTransportType Type => getType();
        public string name { get; set; }

        public ComplexRattlerStation(string name) {
            this.name = name;
            allLinks = new Dictionary<RattlerTransportType, List<LinkStation>>();
            foreach (var type in RattlerTransportType.getValues()) {
                List<LinkStation> links = new List<LinkStation>();
                allLinks[type] = links;
            }
        }

        public RattlerTransportType getType() {
            return RattlerTransportType.COMPLEX;
        }

        public List<LinkStation> getLinks() {
            List<LinkStation> links = new List<LinkStation>();
            foreach (var list in allLinks.Values)
                links.AddRange(list);
            return links;
        }

        public void addLink(LinkStation linkStation) {
            RattlerTransportType type = linkStation.getType();
            List<LinkStation> links;

            if (allLinks.ContainsKey(type)) {
                links = allLinks[type];
            } else {
                links = new List<LinkStation>();
                allLinks[type] = links;
            }

            if (links.Contains(linkStation) || hasLink(type, linkStation.getA(), linkStation.getB()))
                throw new ApplicationException("Данная связь уже установлена");

            links.Add(linkStation);
        }

        public void removeLink(LinkStation linkStation) {
            RattlerTransportType type = linkStation.getType();

            if (!allLinks.ContainsKey(type))
                return;

            allLinks[type].Remove(linkStation);
        }

        public bool hasLinkAny(RattlerStation first, RattlerStation second) {
            return getLinks().Find(
                i => i.getA().Equals(first) && i.getB().Equals(second) ||
                     i.getA().Equals(second) && i.getB().Equals(first)
            ) != null;
        }

        public bool hasLink(RattlerTransportType type, RattlerStation first, RattlerStation second) {
            List<LinkStation> links = getLinksByType(type);
            return links.Find(
                i => i.getType().Equals(type) &&
                     (
                         i.getA().Equals(first) && i.getB().Equals(second) ||
                         i.getA().Equals(second) && i.getB().Equals(first)
                     )
            ) != null;
        }

        private List<LinkStation> getLinksByType(RattlerTransportType type) {
            return allLinks.ContainsKey(type) ? allLinks[type] : null;
        }

        public long id { get; set; }
    }
}