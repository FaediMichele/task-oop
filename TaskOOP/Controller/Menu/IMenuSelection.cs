using System;
using System.Collections.Generic;
using System.Text;

namespace Controller.Menu
{
    /// <summary>
    /// Selection of child with the same base type.
    /// Add child and select one by his class.
    /// Child with the same class will be overrided.
    /// </summary>
    /// <typeparam name="T">The type of children</typeparam>
    public interface IMenuSelection
    {
        /// <summary>
        /// Get all children.
        /// </summary>
        /// <returns>
        /// A list of child.
        /// </returns>
        List<object> AsStream();
        /// <summary>
        /// Get the MenuSelection that contains this.
        /// If present.
        /// </summary>
        /// <returns>A nullable of IMenuSelection</returns>
        object? GetFather();
        /// <summary>
        /// Get the selected child
        /// </summary>
        /// <returns> the selected child</returns>
        object? GetSelected();
        /// <summary>
        /// Add children. they should have different class.
        /// Otherwise they will be override.
        /// </summary>
        /// <param name="children">The child to add.</param>
        void Add(object children);

        /// <summary>
        /// Know if the menu contains a child.
        /// 
        /// </summary>
        /// <param name="possibleChild">the child to search.</param>
        /// <returns>true if present.</returns>
        bool Contains(Type possibleChild);
        /// <summary>
        /// Remove child.
        /// </summary>
        /// <param name="disowned">The child to remove.</param>
        void Remove(Type disowned);
        /// <summary>
        /// Select a child.
        /// </summary>
        /// <param name="child">the child to select</param>
        /// <param name="param">generic parameter</param>
        void Select(Type child, object? param = null);
        /// <summary>
        /// Perform the operation to release all data.
        /// When the application ends.
        /// </summary>
        void Close();
        /// <summary>
        /// Operation made when the child is selected.
        /// </summary>
        /// <param name="previous">the last child.</param>
        /// <param name="next">the next child.</param>
        /// <param name="param">generic parameter</param>
        void ChangedChild(object? previous, object next, object? param = null);

        /// <summary>
        /// Operation made when the grandfather change the selected.
        /// </summary>
        /// <param name="previous">the previous father</param>
        /// <param name="next">the next father.</param>
        /// <param name="param">generic parameter</param>
        void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null);
    }
}
