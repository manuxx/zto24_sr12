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

public class Negation<TItem> : Criteria<TItem>
{
	private readonly Criteria<TItem> _criteriaForNegation;
	public Negation(Criteria<TItem> condition)
	{
		_criteriaForNegation = condition;
	}

	public bool IsSatisfiedBy(TItem item)
	{
		return !_criteriaForNegation.IsSatisfiedBy(item);
	}
}

public class Alternative<TItem> : Criteria<TItem>
{
	private readonly Criteria<TItem> _firstCriteria;
	private readonly Criteria<TItem> _secondCriteria;
	public Alternative(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
	{
		_firstCriteria = firstCriteria;
		_secondCriteria = secondCriteria;
	}

	public bool IsSatisfiedBy(TItem item)
	{
		return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
	}
}

public class Conjunction<TItem> : Criteria<TItem>
{
	private readonly Criteria<TItem> _firstCriteria;
	private readonly Criteria<TItem> _secondCriteria;
	public Conjunction(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
	{
		_firstCriteria = firstCriteria;
		_secondCriteria = secondCriteria;
	}

	public bool IsSatisfiedBy(TItem item)
	{
		return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
	}
}