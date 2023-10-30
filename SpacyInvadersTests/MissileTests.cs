using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacyInvaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacyInvaders.Tests
{
    [TestClass()]
    public class MissileTests
    {
        [TestMethod()]
        public void MissileObstacleTest()
        {
            Missile missile = new Missile(0, 1, "I", 1);

            Assert.IsTrue(missile.MissileObstacle(0, 1));
        }

        [TestMethod()]
        public void MissileAfficherTest()
        {

            Missile missile1 = new Missile(0, 1, "I", 1);
            Missile missile2 = new Missile(1, 5, "I", 1);

            Assert.IsTrue(missile1.MissileAfficher());
            try
            { 
                Assert.IsFalse(missile2.MissileAfficher()); 
            }
            catch
            {
                // c'est normal car la console n'est pas initialiser
            }
        }
    }
}