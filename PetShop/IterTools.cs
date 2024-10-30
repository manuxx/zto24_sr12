using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class IterTools
    {
        public static IEnumerable<Pet> OneAtATime(IList<Pet> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}