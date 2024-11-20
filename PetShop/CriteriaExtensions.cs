using Training.DomainClasses;

public static class CriteriaExtensions
{
	public static Criteria<TItem> And<TItem>(this Criteria<TItem> item1, Criteria<TItem> item2)
	{
		return new Conjunction<TItem>(item1, item2);
	}

	private static Criteria<Pet> Or<Pet>(Criteria<Pet> criteria1, Criteria<Pet> criteria2)
	{
		return new Alternative<Pet>(criteria1, criteria2);
	}

	public static Criteria<TItem> Not<TItem>(this Criteria<TItem> item)
	{
		return new Negation<TItem>(item);
	}
}