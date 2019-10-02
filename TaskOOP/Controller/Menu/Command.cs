using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public enum Command
    {
        /// <summary>
        /// The command for exit
        /// </summary>
        EXIT,

        /// <summary>
        /// The command for enter
        /// </summary>
        ENTER,

        /// <summary>
        /// The command for go up
        /// </summary>
        KEY_UP,

        /// <summary>
        /// The command for right
        /// </summary>
        KEY_RIGHT,

        /// <summary>
        /// The command for go down
        /// </summary>
        KEY_DOWN,

        /// <summary>
        /// The command for go left
        /// </summary>
        KEY_LEFT,

        /// <summary>
        /// The command for shoot up
        /// </summary>
        ARROW_UP,

        /// <summary>
        /// The command for shoot right
        /// </summary>
        ARROW_RIGHT,

        /// <summary>
        /// The command for shoot down
        /// </summary>
        ARROW_DOWN,

        /// <summary>
        /// The command for shoot left
        /// </summary>
        ARROW_LEFT,

        /// <summary>
        /// The command for interact
        /// </summary>
        INTERACT,

        /// <summary>
        /// The command for releasing the bomb
        /// </summary>
        BOMB,

        /// <summary>
        /// The command for show the map
        /// </summary>
        SHOWMAP,

        /// <summary>
        /// The command to make the menu option appear
        /// </summary>
        OPTIONS,

        /// <summary>
        /// The command for full screen
        /// </summary>
        FULLSCREEN
    }
}
