using Game.Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.View
{
    /// <summary>
    /// This class is the controller Manager. It contains all the hierarchy of the application.
    /// Pass the input received to the selected InputMenu(if is a InputMenu).
    /// </summary>
    public class EntryPoint
    {
        private readonly Root<InputMenu> _root;
        private readonly ISet<Command> comms = new HashSet<Command>();
        /// <summary>
        /// Create a new EntryPoint of the application.
        /// If paramether is not passed it will add IntroMenuSelection and MainMenuSelection.
        /// </summary>
        /// <param name="ms">IMenuSelection to use.</param>
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

        /// <summary>
        /// Add IMenuSelection[s].
        /// </summary>
        /// <param name="ms">the IMenuSelection[s] to add</param>
        public void Add(params IMenuSelection[] ms)
        {
            if (ms.Length > 0)
            {
                foreach (IMenuSelection m in ms)
                {
                    _root.Add(m);
                }
            }
            else
            {
                throw new ArgumentException("Paramether not enough");
            }
        }

        /// <summary>
        /// Press a command.
        /// </summary>
        /// <param name="c"></param>
        public void Press(Command c)
        {
            comms.Add(c);
            SendComms();
        }

        /// <summary>
        /// Release a command.
        /// </summary>
        /// <param name="c"></param>
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
