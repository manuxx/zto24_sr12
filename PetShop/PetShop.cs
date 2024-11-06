using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (!_petsInTheStore.Contains(newPet))
            {
                _petsInTheStore.Add(newPet);
            }
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.species == Species.Cat, _petsInTheStore)) yield return pet1;


        }

        public IEnumerable<Pet> AllMice()
        {
            foreach (var pet1 in OneAnimalThat(this, pet=>pet.species == Species.Mouse, _petsInTheStore)) yield return pet1;
        }

        private static IEnumerable<Pet> OneAnimalThat(PetShop petShop, Func<Pet, bool> condition, IList<Pet> pets)
        {
            foreach (var pet in pets)
            {
                if (condition(pet))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.sex == Sex.Female, _petsInTheStore)) yield return pet1;

        }
        public IEnumerable<Pet> AllCatsOrDogs()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.species == Species.Cat || pet.species == Species.Dog, _petsInTheStore)) yield return pet1;
        }
        public IEnumerable<Pet> AllPetsButNotMice()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.species != Species.Mouse, _petsInTheStore)) yield return pet1;
        }
        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.yearOfBirth > 2010, _petsInTheStore)) yield return pet1;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog, _petsInTheStore)) yield return pet1;
        }
        public IEnumerable<Pet> AllMaleDogs()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.species == Species.Dog && pet.sex == Sex.Male, _petsInTheStore)) yield return pet1;
        }
        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            foreach (var pet1 in OneAnimalThat(this, pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit, _petsInTheStore)) yield return pet1;
        }
        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }
    }
}