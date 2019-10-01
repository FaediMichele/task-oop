using System;
using System.Collections.Generic;
using System.Text;
using Controller.Menu;

namespace Test
{
    class SimpleMenuSelection : MenuSelectionImpl
    {
        public delegate void Use();
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
