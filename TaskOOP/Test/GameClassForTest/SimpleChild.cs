using Game.Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.GameClassForTest
{
    /// <summary>
    /// This class is used for test purpose. Can be used to see a simple implementation of it.
    /// </summary>
    class SimpleChild : IChild
    {
        private readonly IMenuSelection _father;
        public SimpleChild(IMenuSelection father)
        {
            _father = father;
            if (!_father.Contains(this.GetType()))
            {
                _father.Add(this);
            }
        }
        public IMenuSelection GetFather()
        {
            return _father;
        }

        public virtual void SelectChild()
        {
        }

        public virtual void UnselectChild()
        {
        }
    }
}
