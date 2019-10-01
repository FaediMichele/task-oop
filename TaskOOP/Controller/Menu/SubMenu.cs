using Controller.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller.Menu
{
    /// <summary>
    /// The SubMenu have different behavior based on their implementation.
    /// Is used in the UI.
    /// The behavior of the method may change a lot base on the implementation.
    /// Represent a controller for a page of the menu.
    /// </summary>
    abstract class SubMenu : IChild
    {
        private readonly IMenuSelection _ms;
        /// <summary>
        /// Set the selector that controls every sub menu.
        /// </summary>
        /// <param name="ms">the MenuSelection</param>
        public SubMenu(IMenuSelection ms)
        {
            _ms = ms;
        }
        public IMenuSelection? GetFather()
        {
            return _ms;
        }
        /// <summary>
        /// Pass the command clicked
        /// </summary>
        /// <param name="c">a set of commad clicked</param>
        public virtual void Input(ISet<Command> c) { }

        public virtual void SelectChild() { }
        /// <summary>
        /// Operation to do to dispose all stuff.
        /// </summary>
        public virtual void Close() { }

        public abstract void UnselectChild();
        /// <summary>
        /// Get the { @link SubMenuView }
        /// that the sub menu use.
        /// /// </summary>
        /// <returns>@return the SubMenuView used</returns>
        public abstract ISubMenuView GetSubMenuView();
    }
}
