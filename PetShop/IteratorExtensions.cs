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

    public static IEnumerable<TItem> AllThat<TItem>(IEnumerable<TItem> items, Func<TItem, bool> condition)
    {
        return items.AllThat(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T>: Criteria<T>
{
    private Func<T, bool> _condition;

    public AnonymousCriteria(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}