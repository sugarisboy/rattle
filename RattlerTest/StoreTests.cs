using System;
using NUnit.Framework;
using RattlerCore;

namespace RattlerTest {
    public class StoreTests {

        [Test]
        public void test1() {
            RattlerCore.RattlerCore core = new RattlerCore.RattlerCore();
            RattlerStore store = core.store;

            Console.WriteLine(store.stations);
            Console.WriteLine(store.transports);
            
            Assert.NotNull(store.stations);
            Assert.NotNull(store.transports);
            
            core.save();
        }
    }
}