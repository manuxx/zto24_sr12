public abstract class MultiCriteria<TItem>
{
	protected Criteria<TItem>[] _criterias;

	public MultiCriteria(params Criteria<TItem>[] criterias)
	{
		_criterias = criterias;
	}

	public abstract bool IsSatisfiedBy(TItem item);
}