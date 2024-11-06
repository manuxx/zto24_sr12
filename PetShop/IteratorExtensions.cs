using System;
using System.Collections.Generic;
using System.Reflection;
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
        return AllThat(items, new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (TItem item in items)
        {
            if (criteria.isSatisfiedBy(item))
                yield return item;
        }
    }

}

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Func<T, bool> _condition;

    public AnonymousCriteria(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public bool isSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<TItem>
{
    bool isSatisfiedBy(TItem item);
}