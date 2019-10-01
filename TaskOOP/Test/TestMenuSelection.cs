using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Menu;
using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class TestMenuSelection
    {
        private const String STRING = "AAAA";
        [TestMethod]
        public void Test_CreateChildAndContainsChild()
        {
            MenuSelectionImpl menu = new MenuSelectionImpl();
            new SimpleChild(menu);
            Assert.IsTrue(menu.Contains(typeof(SimpleChild)));
        }
        [TestMethod]
        public void Test_DontContainsChild()
        {
            MenuSelectionImpl menu = new MenuSelectionImpl();
            new SimpleChild(menu);
            Assert.IsTrue(!menu.Contains(typeof(MenuSelectionImpl)));
        }
        public void Test_Add()
        {
            MenuSelectionImpl menu = new MenuSelectionImpl();
            menu.Add(new Double());
            menu.Add(new String(""));
            Assert.IsTrue(menu.Contains(typeof(Double)));
            Assert.IsTrue(menu.Contains(typeof(String)));
            Assert.IsTrue(!menu.Contains(typeof(Decimal)));
        }
        [TestMethod]
        public void Test_Recursive()
        {
            bool changeChild = false;
            bool changeFather = false;
            SimpleMenuSelection menu = new SimpleMenuSelection(() => changeChild = true, ()=> { });
            SimpleMenuSelection submenu = new SimpleMenuSelection(()=> { }, () => changeFather=true);

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

        [TestMethod]
        public void Test_AsStream()
        {
            MenuSelectionImpl menu = new MenuSelectionImpl();
            Double d = new Double();
            String s = new String(STRING);
            MenuSelectionImpl sub = new MenuSelectionImpl();
            menu.Add(d);
            menu.Add(s);
            menu.Add(sub);

            // pre test
            Assert.IsTrue(menu.Contains(d.GetType()));
            Assert.IsTrue(menu.Contains(s.GetType()));
            Assert.IsTrue(menu.Contains(sub.GetType()));

            // Test List
            List<object> l = menu.AsStream();
            Trace.WriteLine(l.ToString());
            Assert.IsTrue(l.Contains(d));
            Assert.IsTrue(l.Contains(s));
            Assert.IsTrue(l.Contains(sub));
            Assert.AreEqual(l.Count, 3);

            // Test removed item
            menu.Remove(typeof(MenuSelectionImpl));
            List<object> l1 = menu.AsStream();
            Assert.IsTrue(l1.Contains(d));
            Assert.IsTrue(l1.Contains(s));
            Assert.IsFalse(l1.Contains(sub));
            Assert.AreEqual(l1.Count, 2);
        }
    }
}
