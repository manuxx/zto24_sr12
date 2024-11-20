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

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }

}

public class AnonymousCriteria<Titem> : Criteria<Titem>
{
    private readonly Predicate<Titem> _condition;

    public AnonymousCriteria(Predicate<Titem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(Titem item)
    {
        return _condition(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public static class CriteriaExtensions
{
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Conjunction<TItem>(criteria1, criteria2);
    }

    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }
}