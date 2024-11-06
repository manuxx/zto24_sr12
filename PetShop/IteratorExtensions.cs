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

    public static IEnumerable<TItem> AllItemsWhere<TItem>(this IEnumerable<TItem> items, Predicate<TItem> predicate)
    {
        foreach (var item in items)
        {
            if (predicate.Invoke(item))
                yield return item;
        }

    }
}