using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Controller.Menu;
using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Game.View;
using Test.GameClassForTest;

namespace Test
{
    /// <summary>
    /// Test of the controller.
    /// For OOP: I put here all the test for the controller except for the MenuSelection that has his test class.
    /// </summary>
    [TestClass]
    public class TestController
    {
        [TestMethod]
        public void TestCreate()
        {
            EntryPoint game = new EntryPoint();
            Assert.ThrowsException<NotImplementedException>(() => game.Press(Game.Command.ENTER));
        }

        /// <summary>
        /// Test the enty point that use the root correctly.
        /// Test the input commands, the change of the MenuSelection, and if the Sub menu is passed correctly.
        /// </summary>
        [TestMethod]
        public void TestEntryPoint()
        {
            bool changedChild = false;
            int changedfather = 0;
            int getView = 0;
            int selectChild = 0;
            int unselectChild = 0;
            Use changeChild = () => changedChild = !changedChild;
            Use changeFather = () => changedfather++;
            Use getViewSub = () => getView++;
            Use select = () => selectChild++;
            Use unselect = () => unselectChild++;

            SimpleSelector<int> firstMenu = new SimpleSelector<int>(typeof(SimpleSelector<double>), changeChild, changeFather, select, unselect, getViewSub);
            SimpleSelector<double> secondMenu = new SimpleSelector<double>(typeof(SimpleSelector<int>), changeChild, changeFather, select, unselect, getViewSub);
            EntryPoint game = new EntryPoint(firstMenu, secondMenu);
            Assert.IsFalse(changedChild);
            Assert.AreEqual(changedfather,0);
            Assert.AreEqual(getView, 0);
            Assert.AreEqual(selectChild,0);
            Assert.AreEqual(unselectChild, 0);

            // Change the selection
            game.Press(Game.Command.ENTER);
            Assert.IsFalse(changedChild);
            Assert.AreEqual(changedfather, 2);
            Assert.AreEqual(getView, 0);
            Assert.AreEqual(selectChild, 0);
            Assert.AreEqual(unselectChild, 0);
            game.Release(Game.Command.ENTER);
            Assert.AreEqual(changedfather, 2);
            Assert.AreEqual(getView, 0);
            Assert.AreEqual(selectChild, 0);
            Assert.AreEqual(unselectChild, 0);

            // Change the Sub menu.
            game.Press(Game.Command.ARROW_LEFT);
            Assert.AreEqual(changedfather, 2);
            Assert.AreEqual(getView, 1);
            Assert.AreEqual(selectChild, 1);
            Assert.AreEqual(unselectChild, 1);
            game.Release(Game.Command.ARROW_LEFT);
            Assert.AreEqual(changedfather, 2);
            Assert.AreEqual(getView, 1);
            Assert.AreEqual(selectChild, 1);
            Assert.AreEqual(unselectChild, 1);

            // Back to the first Sub Menu
            game.Press(Game.Command.ARROW_RIGHT);
            Assert.AreEqual(changedfather, 2);
            Assert.AreEqual(getView, 2);
            Assert.AreEqual(selectChild, 2);
            Assert.AreEqual(unselectChild, 2);
        }
    }
}
