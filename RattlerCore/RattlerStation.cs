using System.Collections.Generic;

namespace RattlerCore {
    public interface RattlerStation : Numerable {
        public RattlerTransportType Type { get; }
        public string name { get; set; }

        RattlerTransportType getType();

        List<LinkStation> getLinks();

        void addLink(LinkStation linkStation);

        void removeLink(LinkStation linkStation);

        bool hasLinkAny(RattlerStation first, RattlerStation second);

        bool hasLink(RattlerTransportType type, RattlerStation first, RattlerStation second);
    }
}