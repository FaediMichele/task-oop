using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game.Controller.Menu
{
    public class Root<T> : InputMenu
    {
        public override void Add(object child)
        {
            if (child is T)
            {
                base.Add(child);
            }
            else
            {
                throw new Exception("Parameter must be a" + typeof(T).Name);
            }
        }
    }
}
