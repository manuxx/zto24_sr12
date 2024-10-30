using System.Collections.Generic;
using Training.DomainClasses;

public static class IteratorExtensions
{
    public static IEnumerable<IItem> OneAtATime<IItem>(this IEnumerable<IItem> Items)
    {
        foreach (var item in Items)
        {
            yield return item;
        }
    }
}