using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class IterTools
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IList<TItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}