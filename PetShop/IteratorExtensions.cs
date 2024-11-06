using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class IteratorExtensions
    {
        public static IEnumerable<Pet> OneAnimalThat(PetShop petShop, Func<Pet, bool> condition, IList<Pet> pets)
        {
            foreach (var pet in pets)
            {
                if (condition(pet))
                    yield return pet;
            }
        }
    }
}