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

    public static IEnumerable<TItem> AllWhich<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
	    foreach (var item in items)
	    {
		    if (criteria.IsSatisfiedBy(item)) yield return item;
	    }
    }

    public static IEnumerable<TItem> AllWhich<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
	    return items.AllWhich(new AnonymousCriteria<TItem>(condition));
    }

    public class AnonymousCriteria<TItem> : Criteria<TItem>
    {
	    private Predicate<TItem> _condition;
	    public AnonymousCriteria(Predicate<TItem> conditon)
	    {
		    _condition = conditon;
	    }

	    public bool IsSatisfiedBy(TItem item)
	    {
		    return _condition(item);
	    }
    }

	public interface Criteria<TItem>
    {
	    bool IsSatisfiedBy(TItem item);
    }
}