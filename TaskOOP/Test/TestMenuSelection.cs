using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Controller.Menu;
using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Test.GameClassForTest;

namespace Test
{
    /// <summary>
    /// Test the MenuSelectionImpl.
    /// This tests is not made for the Simple~ classes: they're purpose is only for test.
    /// </summary>
    [TestClass]
    public class TestMenuSelection
    {
        private const String STRING = "AAAA";

        /// <summary>
        /// Test if the menu correctly add a child a contains it.
        /// </summary>
        [TestMethod]
        public void Test_CreateChildAndContainsChild()
        {
            IMenuSelection menu = new MenuSelectionImpl();
            new SimpleChild(menu);
            Assert.IsTrue(menu.Contains(typeof(SimpleChild)));
        }

        /// <summary>
        /// Test if the menu not contains another child.
        /// </summary>
        [TestMethod]
        public void Test_DontContainsChild()
        {
            IMenuSelection menu = new MenuSelectionImpl();
            new SimpleChild(menu);
            Assert.IsTrue(!menu.Contains(typeof(MenuSelectionImpl)));
        }

        /// <summary>
        /// Test adding simple class to the menu.
        /// </summary>
        [TestMethod]
        public void Test_Add()
        {
            IMenuSelection menu = new MenuSelectionImpl();
            menu.Add(new Double());
            menu.Add(new String(""));
            Assert.IsTrue(menu.Contains(typeof(Double)));
            Assert.IsTrue(menu.Contains(typeof(String)));
            Assert.IsTrue(!menu.Contains(typeof(Decimal)));
        }

        /// <summary>
        /// Test if a menu correctly add, contains, select, remove a child that is the same o another type of the father.
        /// </summary>
        [TestMethod]
        public void Test_Recursive()
        {
            bool changeChild = false;
            bool changeFather = false;
            IMenuSelection menu = new SimpleMenuSelection(() => changeChild = true, ()=> { });
            IMenuSelection submenu = new SimpleMenuSelection(()=> { }, () => changeFather=true);

            // test set of sub menu's father
            menu.Add(submenu);
            Assert.AreEqual(submenu.GetFather(), menu);
            
            // test of select of child
            Assert.IsFalse(changeChild);
            menu.Select(typeof(SimpleMenuSelection));
            Assert.IsTrue(changeChild);
            Assert.AreEqual(submenu, menu.GetSelected());
            
            // test add
            menu.Add(STRING);
            Assert.IsTrue(menu.Contains(typeof(String)));

            // test select the added string
            menu.Select(typeof(String));
            Assert.AreEqual(STRING, menu.GetSelected());
            Assert.AreNotEqual(STRING.Substring(0, STRING.Length / 2), menu.GetSelected());

            // test of unset the father
            Assert.IsFalse(changeFather);
            menu.Remove(typeof(SimpleMenuSelection));
            Assert.IsTrue(changeFather);
        }

        /// <summary>
        /// Test of the method ToList that return a list of child.
        /// </summary>
        [TestMethod]
        public void Test_ToList()
        {
            IMenuSelection menu = new MenuSelectionImpl();
            Double d = new Double();
            String s = new String(STRING);
            IMenuSelection sub = new MenuSelectionImpl();
            menu.Add(d);
            menu.Add(s);
            menu.Add(sub);

            // pre test
            Assert.IsTrue(menu.Contains(d.GetType()));
            Assert.IsTrue(menu.Contains(s.GetType()));
            Assert.IsTrue(menu.Contains(sub.GetType()));

            // Test List
            List<object> l = menu.ToList();
            Trace.WriteLine(l.ToString());
            Assert.IsTrue(l.Contains(d));
            Assert.IsTrue(l.Contains(s));
            Assert.IsTrue(l.Contains(sub));
            Assert.AreEqual(l.Count, 3);

            // Test removed item
            menu.Remove(typeof(MenuSelectionImpl));
            List<object> l1 = menu.ToList();
            Assert.IsTrue(l1.Contains(d));
            Assert.IsTrue(l1.Contains(s));
            Assert.IsFalse(l1.Contains(sub));
            Assert.AreEqual(l1.Count, 2);
        }

        /// <summary>
        /// Test the add function of the Root
        /// </summary>
        [TestMethod]
        public void Test_Root()
        {
            Root<Double> r = new Root<Double>();
            try
            {
                r.Add(new Double());
                Assert.IsTrue(true);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
            Assert.ThrowsException<ArgumentException>(() => r.Add(""));
        }
    }
}
