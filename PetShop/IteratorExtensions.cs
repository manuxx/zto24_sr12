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

    public static IEnumerable<Titem> AllThat<Titem>(this IList<Titem> items, Predicate<Titem> condition)
    {
         return items.AllThat(new AnonymousCriteria<Titem>(condition));
    }
    public static IEnumerable<Titem> AllThat<Titem>(this IList<Titem> items, Criteria<Titem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    public AnonymousCriteria(Predicate<T> condition)
    {
            throw new NotImplementedException();
    }

    public bool IsSatisfiedBy<Titem>(Titem item)
    {
        throw new NotImplementedException();
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy<Titem>(Titem item);
}