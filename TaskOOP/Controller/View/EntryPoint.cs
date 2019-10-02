using Game.Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.View
{
    public class EntryPoint
    {
        private readonly Root<InputMenu> _root;
        private readonly ISet<Command> comms = new HashSet<Command>();
        public EntryPoint(params IMenuSelection[] ms)
        {
            _root = new Root<InputMenu>();
            if (ms.Length == 0)
            {
                _root.Add(new IntroMenuSelection());
                _root.Add(new MainMenuSelection());
            }
            else
            {
                foreach(IMenuSelection m in ms)
                {
                    _root.Add(m);
                }
            }
        }
        public void Press(Command c)
        {
            comms.Add(c);
            SendComms();
        }
        public void Release(Command c)
        {
            comms.Remove(c);
            SendComms();
        }
        private void SendComms()
        {
            (_root.GetSelected() as InputMenu)?.Input(comms);
        }
    }
}
