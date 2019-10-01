using System;
using System.Collections.Generic;
using System.Text;

namespace Controller.View.Interfaces
{
    /// <summary>
    /// Interface for the game intro view.
    /// </summary>
    interface IGameIntroView
    {
        /// <summary>
        /// Effect to change the father.
        /// </summary>
        /// <param name="ok">if the game intro is the next MenuSelection or the previous</param>
        void ChangedFather(bool ok);
    }
}
