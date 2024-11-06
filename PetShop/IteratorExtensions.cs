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

    public static IEnumerable<TItem> AllOfSpecie<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> comparer)
    {
	    foreach (var item in items)
	    {
		    if (comparer(item)) yield return item;
	    }
    }
}