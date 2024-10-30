using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet : IEnumerable<Pet>
    {
        public IEnumerable<Pet> items { get; set; }

        public ReadOnlySet(IEnumerable<Pet> items)
        {
            this.items = items;
        }
                                                                                           
        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}