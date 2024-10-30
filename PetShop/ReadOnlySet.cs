using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        private IEnumerable<TItem> _items { get; set; }

        public ReadOnlySet(IEnumerable<TItem> items)
        {
            this._items = items;
        }
                                                                                           
        public IEnumerator<TItem> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}