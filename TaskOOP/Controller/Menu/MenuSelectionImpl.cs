using Controller.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Controller.Menu
{
    public class MenuSelectionImpl : IMenuSelection
    {
        private readonly Dictionary<Type, object> _children = new Dictionary<Type, object>();
        private object? _father;
        private object? _first;
        private bool _firstInserted;
        public MenuSelectionImpl()
        {
            _first = default;
            _firstInserted = true;
        }
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

        public List<object> AsStream()
        {
            return _children.Values.ToList();
        }

        public virtual void ChangedChild(object? previous, object next, object? param = null) { }

        public virtual void Close()
        {
            foreach(object c in AsStream())
            {
                if (c is IMenuSelection)
                {
                    (c as IMenuSelection)?.Close();
                }
            };
        }

        public bool Contains(Type possibleChild)
        {
            return _children.ContainsKey(possibleChild);
        }

        public virtual void FatherChanged(IMenuSelection? previous, IMenuSelection? next, object? param = null) { }

        public object? GetFather()
        {
            return _father;
        }

        public object? GetSelected()
        {
            return _first;
        }

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
            if (selected is MenuSelectionImpl)
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
