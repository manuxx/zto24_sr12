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

    public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Func<TItem, bool> condition)
    {
        foreach (TItem item in items)
        {
            if (condition(item))
                yield return item;
        }
    }
}