using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public interface RattlerTransport {
        
        RattlerTransportType getType();

        List<Station> getStations();

        void addStation(Station station);

        void removeStation(Station station);

        bool containsStation(Station station);
    }
}