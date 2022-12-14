using System;
using System.Collections.Generic;
using System.Text;

namespace Game.View.Interfaces
{
    /// <summary>
    /// Interface for the SubMenu for the intro.
    /// </summary>
    public interface ISubMenuIntroView : ISubMenuView
    {
        /// <summary>
        /// Play the intro.
        /// </summary>
        void Play();
        /// <summary>
        /// Release the resources.
        /// </summary>
        void Clean();
    }
}
