public class Alternative<TItem> : MultiCriteria<TItem>, Criteria<TItem>
{
	public Alternative(params Criteria<TItem>[] criterias) : base(criterias)
	{
	}

	public override bool IsSatisfiedBy(TItem item)
	{
		foreach (var criteria in _criterias)
		{
			if (criteria.IsSatisfiedBy(item))
				return true;
		}
		return false;
	}
}