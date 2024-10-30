using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<Pet> : IEnumerable<Pet>
    {
        private readonly IList<Pet> _items;

        public ReadOnlySet(IList<Pet> items)
        {
            _items = items;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return _items.OneAtATime().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}