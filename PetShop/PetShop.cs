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
            return OneAnimalThat(pet => pet.species == Species.Cat);

        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return OneAnimalThat(pet => pet.species==Species.Dog && pet.yearOfBirth >2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return OneAnimalThat(pet => pet.sex==Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return OneAnimalThat(pet => pet.yearOfBirth >2011 || pet.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllMice()
        {
            return OneAnimalThat(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return OneAnimalThat(pet => pet.sex == Sex.Female);
        }

        private IEnumerable<Pet> OneAnimalThat(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return OneAnimalThat(pet => pet.species == Species.Cat || pet.species == Species.Dog);

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return OneAnimalThat(pet => pet.species != Species.Mouse);

        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return OneAnimalThat(pet => pet.yearOfBirth > 2010);

        }
    }
}