using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
			return _petsInTheStore.AllThat(Pet.IsASpeciesOf(Species.Cat));

		}

		public IEnumerable<Pet> AllPetsSortedByName()
		{
			var result = new List<Pet>(_petsInTheStore);
			result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
			return result;
		}

		public IEnumerable<Pet> AllDogsBornAfter2010()
		{
			return _petsInTheStore.AllThat(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
		}

		public IEnumerable<Pet> AllMaleDogs()
		{
			return _petsInTheStore.AllThat((pet => pet.sex == Sex.Male && pet.species == Species.Dog));
		}

		public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
		{
			return _petsInTheStore.AllThat(new Alternative<Pet>(Pet.IsBornAfter(2011), Pet.IsASpeciesOf(Species.Rabbit)));
		}

		public IEnumerable<Pet> AllMice()
		{
			return _petsInTheStore.AllThat(Pet.IsASpeciesOf(Species.Mouse));
		}

		public IEnumerable<Pet> AllPetsBornAfter2010()
		{
			return _petsInTheStore.AllThat(Pet.IsBornAfter(2010));

		}

		public IEnumerable<Pet> AllFemalePets()
		{
			return _petsInTheStore.AllThat(Pet.IsFemale());
		}

		public IEnumerable<Pet> AllCatsOrDogs()
		{
			return _petsInTheStore.AllThat((pet => pet.species == Species.Cat || pet.species == Species.Dog));

		}

		public IEnumerable<Pet> AllPetsButNotMice()
		{
			return _petsInTheStore.AllThat(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));

		}

		public class Negation<TItem> : Criteria<TItem>
		{
			private readonly Criteria<TItem> _criteria;

			public Negation(Criteria<TItem> criteria)
			{
				_criteria = criteria;
			}

			public bool IsSatisfiedBy(TItem item)
			{
				return !_criteria.IsSatisfiedBy(item);
			}
		}

		public class Alternative<TItem> : Criteria<TItem>
		{
			private readonly Criteria<TItem> _criteria1, _criteria2;

			public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
			{
				_criteria1 = criteria1;
				_criteria2 = criteria2;
			}

			public bool IsSatisfiedBy(TItem item)
			{
				return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
			}
		}

		public class Conjunction<TItem> : Criteria<TItem>
		{
			private readonly Criteria<TItem> _criteria1, _criteria2;

			public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
			{
				_criteria1 = criteria1;
				_criteria2 = criteria2;
			}

			public bool IsSatisfiedBy(TItem item)
			{
				return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
			}
		}
	}
}