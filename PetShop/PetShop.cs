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
            foreach (var pet in _petsInTheStore)
            {
                if(pet.species==Species.Cat)
                    yield return pet;
            }

        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {

            return OnePetThat(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return OnePetThat(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return OnePetThat(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return OnePetThat(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return OnePetThat(pet => pet.yearOfBirth > 2010);
        }

        private IEnumerable<Pet> OnePetThat(Func<Pet, bool> condition)
        {
            foreach (Pet pet in _petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return OnePetThat(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return OnePetThat(pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {

            return OnePetThat(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }
}