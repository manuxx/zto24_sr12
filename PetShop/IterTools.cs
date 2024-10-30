using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class IterTools
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IList<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}