using Game.Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game.Controller.Menu
{
    /// <summary>
    /// Implementatio of <see cref="IMenuSelection" />
    /// It manage the child based on the type of them.
    /// No same type of child is allowed.
    /// Using <see cref="IChild" /> as child permit to receive information about changes in the Menu.
    /// </summary>
    public class MenuSelectionImpl : IMenuSelection
    {
        private readonly Dictionary<Type, object> _children = new Dictionary<Type, object>();
        private object? _father;
        private object? _first;
        private bool _firstInserted;
        /// <summary>
        /// Create an empty menu.
        /// </summary>
        public MenuSelectionImpl()
        {
            _first = default;
            _firstInserted = true;
        }

        /// <summary>
        /// Add a child.
        /// If there is another child with the same type is overwritten
        /// </summary>
        /// <param name="child">the child to add.</param>
        public virtual void Add(object child)
        {
            if (child is null || child == this)
            {
                return;
            }
            _children.Add(child.GetType(), child);
            if (child is MenuSelectionImpl)
            {
                (child as MenuSelectionImpl)?.SetFather(this);
            }
            if (_firstInserted && child != null)
            {
                _first = child;
                _firstInserted = false;
            }

        }

        /// <summary>
        /// Get a list of child.
        /// </summary>
        /// <returns>A list.</returns>
        public List<object> ToList()
        {
            return _children.Values.ToList();
        }

        /// <summary>
        /// Operation to do when the selected child changes.
        /// </summary>
        /// <param name="previous">The previous child selected. If Selected for the first time is null</param>
        /// <param name="next">The next child selected.</param>
        /// <param name="param">Generic paramether that can be used. Default is null</param>
        public virtual void ChangedChild(object? previous, object next, object? param = null) { }

        /// <summary>
        /// Dispose element loaded and close thread or process.
        /// </summary>
        public virtual void Close()
        {
            foreach(object c in ToList())
            {
                if (c is IMenuSelection)
                {
                    (c as IMenuSelection)?.Close();
                }
            };
        }

        /// <summary>
        /// Contains a child with a type as the paramether
        /// </summary>
        /// <param name="possibleChild">the Type of the child to search</param>
        /// <returns>True if a child with the same type of the paramether is present</returns>
        public bool Contains(Type possibleChild)
        {
            return _children.ContainsKey(possibleChild);
        }

        /// <summary>
        /// Operation made when the father change the selected child and the object is previous or next.
        /// </summary>
        /// <param name="previous">The previous brother selected. null if there is no child selected first</param>
        /// <param name="next">The brother selecte</param>
        /// <param name="param">Generic paramether.</param>
        public virtual void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null) { }

        /// <summary>
        /// Get the father of the object if is inserted in another IMenuSelection.
        /// </summary>
        /// <returns>The father. null if not inserted in any IMenuSelection</returns>
        public object? GetFather()
        {
            return _father;
        }

        /// <summary>
        /// Get the selected child.
        /// </summary>
        /// <returns></returns>
        public object? GetSelected()
        {
            return _first;
        }

        /// <summary>
        /// Remove a child
        /// </summary>
        /// <param name="disowned">The child to remove</param>
        public void Remove(Type disowned)
        {
            object nextOrphan = _children[disowned];
            _children.Remove(disowned);
            if (nextOrphan is IChild)
            {
                (nextOrphan as IChild)?.UnselectChild();
            }
            
            if(nextOrphan is IMenuSelection)
            {
                (nextOrphan as IMenuSelection)?.FatherChanged(this, null);
            }
        }

        /// <summary>
        /// Select a child and pass a param if is a IMenuSelection
        /// </summary>
        /// <param name="child">The child to select</param>
        /// <param name="param">Generic param. Default is null</param>
        public void Select(Type child, object? param = null)
        {
            if (!_children.ContainsKey(child))
            {
                return;
            }
            if (_first is IChild)
            {
                ((IChild)_first)?.UnselectChild();
            }
            object selected = _children[child];
            object? prev = _first;
            if (selected is IMenuSelection)
            {
                if (prev is IMenuSelection)
                {
                    ((IMenuSelection)prev).FatherChanged((IMenuSelection)prev, (IMenuSelection)selected, param);
                }
                ((IMenuSelection)selected).FatherChanged((IMenuSelection?)prev, (IMenuSelection)selected, param);
            }
            ChangedChild(prev, selected, param);
            _first = selected;
            (_first as IChild)?.SelectChild();
        }
        private void SetFather(object father)
        {
            _father = father;
        }
    }
}
