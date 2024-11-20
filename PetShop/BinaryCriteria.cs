public abstract class BinaryCriteria<TItem>
{
	protected Criteria<TItem> _firstCriteria;
	protected Criteria<TItem> _secondCriteria;

	public BinaryCriteria(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
	{
		_firstCriteria = firstCriteria;
		_secondCriteria = secondCriteria;
	}

	public abstract bool IsSatisfiedBy(TItem item);
}