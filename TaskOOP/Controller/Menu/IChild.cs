using Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller.Menu
{
    public interface IChild
    {
        IMenuSelection? GetFather();
        void SelectChild();
        void UnselectChild();
    }
}
