using System;
using NUnit.Framework;
using Dargons_of_Kir;

namespace TestingDargons.Testing
{
    [TestFixture]
    public class TestImpactTile
    {
        [Test]
        public void TestInit()
        {
            ImpactTile tile = new ImpactTile();
            Assert.NotNull(tile);
        }
    }
}
