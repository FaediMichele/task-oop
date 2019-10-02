using Game.Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Controller.Menu
{
    /// <summary>
    /// Child of the IMenuSelection
    /// <para>Child are used for additional function like when removed from a MenuSelection</para>
    /// </summary>
    public interface IChild
    {
        /// <summary>
        /// Get the father of this child.
        /// </summary>
        /// <returns>the father</returns>
        IMenuSelection? GetFather();

        /// <summary>
        /// Called when the child is selected.
        /// </summary>
        void SelectChild();

        /// <summary>
        /// Called when the child is unselected or removed
        /// </summary>
        void UnselectChild();
    }
}
