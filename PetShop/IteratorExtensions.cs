using System.Collections.Generic;
using Training.DomainClasses;

public static class IteratorExtensions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}