using System.Collections.Generic;
using Training.DomainClasses;

public static class IteratorExtensions
{
    public static IEnumerable<TItem> OneAtTheTime<TItem>(this IEnumerable<TItem> items, IEnumerable<Pet> pets)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}