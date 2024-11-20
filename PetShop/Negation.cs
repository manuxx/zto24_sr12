namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteriaForNegation;

        public Negation(Criteria<TItem> criteriaForNegation)
        {
            _criteriaForNegation = criteriaForNegation;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteriaForNegation.IsSatisfiedBy(item);
        }
    }
}