using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game.Controller.Menu
{
    /// <summary>
    /// A menu Selection that manage input commands.
    /// It pass the input to all the direct child that is input menu.
    /// </summary>
    public class InputMenu : MenuSelectionImpl
    {
        /// <summary>
        /// Receive the input
        /// It pass to the direct child that is input menu.
        /// </summary>
        /// <param name="commands"></param>
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
