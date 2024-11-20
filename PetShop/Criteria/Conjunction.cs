public class Conjunction<TItem> : MultiCriteria<TItem>, Criteria<TItem>
{
	public Conjunction(params Criteria<TItem>[] criterias) : base(criterias)
	{
	}

	public override bool IsSatisfiedBy(TItem item)
	{
		foreach (var criteria in _criterias)
		{
			if (!criteria.IsSatisfiedBy(item))
				return false;
		}
		return true;
	}

}
