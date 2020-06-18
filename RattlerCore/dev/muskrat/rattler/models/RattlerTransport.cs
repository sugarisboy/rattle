using System.Collections.Generic;

namespace RattlerCore.dev.muskrat.rattler.models {
    public interface RattlerTransport {
        
        RattlerTransportType getType();

        List<RattleStation> getStations();

        void addStation(RattleStation station);

        void removeStation(RattleStation station);

        bool containsStation(RattleStation station);

        int getCapacity();

        double getAverageSpeed();
    }
}