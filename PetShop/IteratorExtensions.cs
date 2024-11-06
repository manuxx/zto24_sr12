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

	public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> condition)
	{
		items.AllThat(new AnonymousCriteria<TItem>(condition));
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