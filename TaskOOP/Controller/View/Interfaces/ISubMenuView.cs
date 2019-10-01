using System;
using System.Collections.Generic;
using System.Text;

namespace Controller.View.Interfaces
{
    /// <summary>
    /// Interface for sub menu that interact directly with the window
    /// </summary>
    interface ISubMenuView
    {
        /// <summary>
        /// Get the object that contains the sub menu ui element
        /// Example: Grid
        /// </summary>
        /// <returns>The object that contain the sub menu UI element.</returns>
        object GetUIMaster();
    }
}
