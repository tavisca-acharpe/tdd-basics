using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game gObject;
        public GameFixture()
        {
            gObject = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                gObject.Add(pins);
        }

  
        [TestMethod]
        public void TestAllOnes()
        {

            RollMany(20, 1);
            Assert.AreEqual(20, gObject.GetScore());
        }

        [TestMethod]
        public void TypicalGame()
        {
            gObject.Add(1);
            gObject.Add(4);
            gObject.Add(4);
            gObject.Add(5);
            gObject.Add(6);
            gObject.Add(4);
            gObject.Add(5);
            gObject.Add(5);
            gObject.Add(10);
            gObject.Add(0);
            gObject.Add(1);
            gObject.Add(7);
            gObject.Add(3);
            gObject.Add(6);
            gObject.Add(4);
            gObject.Add(10);
            gObject.Add(2);
            gObject.Add(8);
            gObject.Add(6);
            Assert.AreEqual(133, gObject.GetScore());
        }

        [TestMethod]
        public void testTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
            {
                gObject.Add(10);
            }
            gObject.Add(9);
            gObject.Add(1);
            gObject.Add(1);
            Assert.AreEqual(270, gObject.GetScore());
        }


        [TestMethod]
        public void TestOneSpare()
        {

            RollSpare();
            gObject.Add(3);
            RollMany(17, 0);
            Assert.AreEqual(16, gObject.GetScore());
        }

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, gObject.GetScore());

        }


        [TestMethod]
        public void TestOneStrike()
        {

            RollStrike();
            gObject.Add(3);
            gObject.Add(4);
            RollMany(16, 0);
            Assert.AreEqual(24, gObject.GetScore());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            gObject = new Game();
            RollMany(12, 10);
            Assert.AreEqual(300, gObject.GetScore());
        }

        private void RollStrike()
        {
            gObject.Add(10);
        }

        private void RollSpare()
        {
            // This is a dummy test that will always pass.
            gObject.Add(5);
            gObject.Add(5);
        }

     }
}
