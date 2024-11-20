using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            return _petsInTheStore.AllThat((pet => pet.species==Species.Dog && pet.yearOfBirth >2010));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllThat((pet => pet.sex==Sex.Male && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllThat((pet => pet.yearOfBirth >2011 || pet.species == Species.Rabbit));
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

       
    }

    class Negation<T> : Criteria<T>
    {
        private Predicate<T> _predicate;
        public Negation(Predicate<T> predicate)
        {
            _predicate = predicate;
        }
        public bool IsSatisfiedBy(T item)
        {
            return !_predicate(item);  
        }
    }
}