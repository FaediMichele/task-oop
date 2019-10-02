using System;
using System.Collections.Generic;
using System.Text;
using Game.Controller.Menu;

namespace Test.GameClassForTest
{
    class SimpleMenuSelection : MenuSelectionImpl
    {
        
        private readonly Use _changeChild;
        private readonly Use _fatherChanged;
        public SimpleMenuSelection(Use changeChild, Use fatherChanged)
        {
            _changeChild = changeChild;
            _fatherChanged = fatherChanged;
        }
        public override void ChangedChild(object? previous, object next, object? param = null)
        {
            base.ChangedChild(previous, next, param);
            _changeChild();
        }
        public override void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null)
        {
            base.FatherChanged(previous, next, param);
            if (next != this)
            {
                _fatherChanged();
            }
        }
    }
}
