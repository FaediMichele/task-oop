using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game.Controller.Menu
{
    public class InputMenu : MenuSelectionImpl
    {
        public virtual void Input(ISet<Command> commands)
        {
            foreach(InputMenu i in (from c in AsStream()
                                    where c is InputMenu
                                    select c as InputMenu))
            {
                i.Input(commands);
            }
        }
    }
}
