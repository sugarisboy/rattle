using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public interface Station {

        RattlerTransportType getType();

        List<LinkStation> getLinks();

        void addLink(LinkStation linkStation);

        void removeLink(LinkStation linkStation);

        bool hasLinkAny(Station first, Station second);
        
        bool hasLink(RattlerTransportType type, Station first, Station second);
    }
}