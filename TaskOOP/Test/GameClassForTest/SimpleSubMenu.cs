using System;
using System.Collections.Generic;
using System.Text;
using Game.View.Interfaces;
using Game.Controller.Menu;
using Game;

namespace Test.GameClassForTest
{
    public class SimpleSubMenu : SimpleSubMenu<object> 
    {
        public SimpleSubMenu(IMenuSelection ms, Use getView, Use selectChild, Use unselectChild)
            : base(ms, getView, selectChild, unselectChild) { }
    }
    public class SimpleSubMenu<T> : SubMenu
    {
        private readonly Use _getView;
        private readonly Use _unselectChild;
        private readonly Use _selectChild;
        private readonly ISubMenuView view = new SimpleSubMenuViewImpl();

        public SimpleSubMenu(IMenuSelection ms, Use getView, Use selectChild, Use unselectChild)
            :base(ms)
        {
            _getView = getView;
            _unselectChild = unselectChild;
            _selectChild = selectChild;
        }
        public override void Input(ISet<Command> c)
        {
            base.Input(c);
            if(c.Contains(Command.ARROW_LEFT) && this is SimpleSubMenu<int>)
            {
                GetFather()?.Select(typeof(SimpleSubMenu<double>));
            } else if (c.Contains(Command.ARROW_RIGHT) && this is SimpleSubMenu<double>)
            {
                GetFather()?.Select(typeof(SimpleSubMenu<int>));
            }
        }

        public override ISubMenuView GetSubMenuView()
        {
            _getView();
            return view;
        }

        public override void UnselectChild()
        {
            _unselectChild();
        }
        public override void SelectChild()
        {
            base.SelectChild();
            _selectChild();
            // Here should apply visual effect.
            // For the project and test purposes I just put here without meaning.
            GetSubMenuView();
        }
    }
}
