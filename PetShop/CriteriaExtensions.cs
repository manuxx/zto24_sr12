using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction<Pet> And(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Conjunction<Pet>(criteria1,criteria2);
    }
}