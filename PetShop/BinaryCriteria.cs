namespace Training.DomainClasses
{
    public class Alternative : Criteria<Pet>
    {
        private readonly Criteria<Pet> _criteria1;
        private readonly Criteria<Pet> _criteria2;
        public Alternative(Criteria<Pet> criteria1, Criteria<Pet> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }
        public bool IsSatisfiedBy(Pet item) {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }

    public class Conjunction : Criteria<Pet>
    {
        private readonly Criteria<Pet> _criteria1;
        private readonly Criteria<Pet> _criteria2;

        public Conjunction(Criteria<Pet> criteria1, Criteria<Pet> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(Pet item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }
}