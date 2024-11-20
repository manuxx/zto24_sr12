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

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
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

public class Negation<Titem> : Criteria<Titem>
{
	private readonly Criteria<Titem> _condition;
	public Negation(Criteria<Titem> condition)
	{
		_condition = condition;
	}

	public bool IsSatisfiedBy(Titem item)
	{
		return !_condition.IsSatisfiedBy(item);
	}
}