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
        return items.AllItemsWhere(new AnonymousCriteria<TItem>(predicate));
    }

    public static IEnumerable<TItem> AllItemsWhere<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }

    }
}

public class AnonymousCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _predicate;

    public AnonymousCriteria(Predicate<TItem> predicate)
    {
        _predicate = predicate;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _predicate(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}
