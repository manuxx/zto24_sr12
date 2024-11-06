using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;


        public IEnumerable<Pet> AllOfSpecie(Func<Pet, bool> comparer)
        {
	        foreach (var pet in _petsInTheStore)
	        {
		        if (comparer(pet)) yield return pet;
	        }
        }
		public IEnumerable<Pet> AllPetsButNotMice()
        {
			return AllOfSpecie(mpet => mpet.species != Species.Mouse);
		}

		public IEnumerable<Pet> AllMice()
        {
            return AllOfSpecie(mpet => mpet.species == Species.Mouse);
        }


		public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() {
			return AllOfSpecie(mpet => mpet.species == Species.Rabbit || mpet.yearOfBirth > 2011);
        }

        public IEnumerable<Pet> AllMaleDogs() {
	        return AllOfSpecie(mpet => mpet.species == Species.Dog && mpet.sex == Sex.Male);
        }

		public IEnumerable<Pet> AllDogsBornAfter2010() {
			return AllOfSpecie(mpet => mpet.species == Species.Dog && mpet.yearOfBirth > 2010);
                }
		public IEnumerable<Pet> AllPetsBornAfter2010() {
			return AllOfSpecie(mpet => mpet.yearOfBirth > 2010);
                }

		public IEnumerable<Pet> AllFemalePets() {
			return AllOfSpecie(mpet => mpet.sex == Sex.Female);

		}
		public IEnumerable<Pet> AllCatsOrDogs()
		{
			return AllOfSpecie(mpet => mpet.species == Species.Cat || mpet.species == Species.Dog);
		}
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
    }
}