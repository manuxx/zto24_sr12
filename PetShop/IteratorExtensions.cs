using System.Collections.Generic;
using Training.DomainClasses;

namespace Training.DomainClasses
{
public static class IteratorExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}
}