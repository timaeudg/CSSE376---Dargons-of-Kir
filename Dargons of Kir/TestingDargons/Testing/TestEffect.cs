using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargons_of_Kir;
using NUnit.Framework;

namespace TestingDargons.Testing
{
    [TestFixture]
    class TestEffect
    {

        public bool tester()
        {
            return false;
        }


        [Test]
        public void TestInit()
        {
            Effect e = new Effect(new Board.location(), new Board.direction(), new Board.direction(), 0, 0, null);
            Assert.NotNull(e);
        }

        [Test]
        public void TestCallback()
        {
            Effect e = new Effect(new Board.location(), new Board.direction(), new Board.direction(), 0, 0, null);
            Assert.True(e.activateCallback());
        }



    }
}
