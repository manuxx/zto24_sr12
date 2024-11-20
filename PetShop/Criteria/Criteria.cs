using System.Linq;

public interface Criteria<TItem>
{
	bool IsSatisfiedBy(TItem item);
}

