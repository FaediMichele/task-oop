using System;
using System.Collections.Generic;
using System.Text;
using Game;
using Game.Controller.Menu;

namespace Test.GameClassForTest
{
    /// <summary>
    /// This class is used for test purpose. Can be used to see a simple implementation of it.
    /// </summary>
    class SimpleSelector<T> : InputMenu 
    {
        private readonly Type _t;
        private readonly Use _changedChild;
        private readonly Use _changedFather;
        public SimpleSelector(Type type, Use changedChild, Use changedFather, Use selectChildSub, Use unselectChildSub, Use getViewSub)
        {
            _t = type;
            _changedChild = changedChild;
            _changedFather = changedFather;
            Add(new SimpleSubMenu<int>(this, getViewSub, selectChildSub, unselectChildSub));
            Add(new SimpleSubMenu<double>(this, getViewSub, selectChildSub, unselectChildSub));
        }
        public override void Input(ISet<Command> commands)
        {
            base.Input(commands);
            (GetSelected() as SubMenu)?.Input(commands);
            if (commands.Contains(Command.ENTER))
            {
                (GetFather() as IMenuSelection)?.Select(_t);
            }
            
        }
        public override void ChangedChild(object? previous, object next, object? param = null)
        {
            base.ChangedChild(previous, next, param);
            _changedChild();
        }
        public override void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null)
        {
            base.FatherChanged(previous, next, param);
            _changedFather();
            
        }
    }
}
