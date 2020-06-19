using System.Collections.Generic;

namespace RattlerCore {
    public interface RattleStation : Numerable {
        
        public string name { get; set; }

        RattlerTransportType getType();

        List<LinkStation> getLinks();

        void addLink(LinkStation linkStation);

        void removeLink(LinkStation linkStation);

        bool hasLinkAny(RattleStation first, RattleStation second);
        
        bool hasLink(RattlerTransportType type, RattleStation first, RattleStation second);
    }
}