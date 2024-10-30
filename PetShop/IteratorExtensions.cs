using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class IteratorExtensions
    {
        public static IEnumerable<Pet> OneAtATime(IEnumerable<Pet> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}