using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{

	public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public IEnumerable<Pet> AllPetsButNotMice()
        {
	        return _petsInTheStore.AllWhich(mpet => mpet.species != Species.Mouse);
		}

        public static Predicate<Pet> IsFemale = pet => pet.sex == Sex.Female;

		public IEnumerable<Pet> AllMice()
        {
			return _petsInTheStore.AllWhich(mpet => mpet.species == Species.Mouse);
        }

		public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits() 
		{
			return _petsInTheStore.AllWhich(mpet => mpet.species == Species.Rabbit || mpet.yearOfBirth > 2011);
        }

        public IEnumerable<Pet> AllMaleDogs() 
        {
	        return _petsInTheStore.AllWhich(mpet => mpet.species == Species.Dog && mpet.sex == Sex.Male);
        }

		public IEnumerable<Pet> AllDogsBornAfter2010() 
        {
			return _petsInTheStore.AllWhich(mpet => mpet.species == Species.Dog && mpet.yearOfBirth > 2010);
        }

		public IEnumerable<Pet> AllPetsBornAfter2010() 
        {
			return _petsInTheStore.AllWhich(Pet.WasBornAfter(2010));
        }

		public IEnumerable<Pet> AllFemalePets() 
        {
			return _petsInTheStore.AllWhich(Pet.IsFemale());
		}

		public IEnumerable<Pet> AllCatsOrDogs()
		{
			return _petsInTheStore.AllWhich(mpet => mpet.species == Species.Cat || mpet.species == Species.Dog);
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