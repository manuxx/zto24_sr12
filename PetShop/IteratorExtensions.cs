using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class IteratorExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<Titem> AllThat<Titem>(this IList<Titem> items, Func<Titem, bool> condition)
    {
        foreach (var item in items)
        {
            if (condition(item))
                yield return item;
        }
    }
}