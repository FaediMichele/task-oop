using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game.Controller.Menu
{
    /// <summary>
    /// Root for the IMenuSelection tree.
    /// Admin only child with the same base type.
    /// <see cref="IMenuSelection"/>
    /// </summary>
    /// <typeparam name="T">The type of child</typeparam>
    public class Root<T> : InputMenu
    {
        /// <summary>
        /// Add a child.
        /// If the child is not T then s thrown <see cref="ArgumentException"/>
        /// <para>
        /// <see cref="MenuSelectionImpl.Add(object)"/>
        /// </para>
        /// </summary>
        /// <param name="child">The child to add</param>
        public override void Add(object child)
        {
            if (child is T)
            {
                base.Add(child);
            }
            else
            {
                throw new ArgumentException("Parameter must be a" + typeof(T).Name);
            }
        }
    }
}
