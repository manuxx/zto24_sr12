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
				if (pet.species == Species.Cat)
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
			foreach (var pet1 in OneAnimalThat(pet => pet.species == Species.Mouse)) yield return pet1;
		}

		private IEnumerable<Pet> OneAnimalThat(Func<Pet, bool> condition)
		{
			foreach (var pet in _petsInTheStore)
			{
				if (condition(pet))
					yield return pet;
			}
		}

		public IEnumerable<Pet> AllFemalePets()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.sex == Sex.Female)) yield return pet1;
		}

		public IEnumerable<Pet> AllCatsOrDogs()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.species == Species.Cat || pet.species == Species.Dog)) yield return pet1;
		}

		public IEnumerable<Pet> AllPetsButNotMice()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.species != Species.Mouse)) yield return pet1;
		}

		public IEnumerable<Pet> AllPetsBornAfter2010()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.yearOfBirth > 2010)) yield return pet1;
		}

		public IEnumerable<Pet> AllDogsBornAfter2010()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010)) yield return pet1;
		}

		public IEnumerable<Pet> AllMaleDogs()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.species == Species.Dog && pet.sex == Sex.Male)) yield return pet1;
		}

		public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
		{
			foreach (var pet1 in OneAnimalThat(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit)) yield return pet1;

		}
	}
}