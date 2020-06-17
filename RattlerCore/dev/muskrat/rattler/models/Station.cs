using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public interface Station {

        RattlerTransportType getType();

        List<LinkStation> getLinks();
    }
}