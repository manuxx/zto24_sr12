using System;

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