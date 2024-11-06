using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
         return AllThat(items, new AnonymousCriteria<Titem>(condition));
    }
    public static IEnumerable<Titem> AllThat<Titem>(this IList<Titem> items, Criteria<Titem> criteria)
    {
        foreach (Titem item in items)
        {
            if (criteria.IsSatisfiedBy(item))
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


    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<Titem>
{
    bool IsSatisfiedBy(Titem item);
}