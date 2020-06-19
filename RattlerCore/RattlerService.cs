namespace RattlerCore {
    public abstract class RattleService {

        protected RattlerCore core;

        public RattleService(RattlerCore core) {
            this.core = core;
        }

        public RattlerCore getCore() {
            return core;
        }
    }
}