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
            return _petsInTheStore.AllThat(new Conjunction<Pet>((Pet.IsBornAfter(2010)), Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllThat(new Conjunction<Pet>(new Negation<Pet>(Pet.IsFemale()), Pet.IsASpeciesOf(Species.Dog)));
            ;
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
<<<<<<< Updated upstream
            return _petsInTheStore.AllThat((pet => pet.species != Species.Mouse));
=======
            return _petsInTheStore.AllThat(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
>>>>>>> Stashed changes

        }

       
    }

    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem>[] _criteria;

        public Conjunction(params Criteria<TItem>[] criteria)
        {
            _criteria = criteria;
        }


        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criterion in _criteria)
            {
                if (!criterion.IsSatisfiedBy(item))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem>[] _criteria;

        public Alternative(params Criteria<TItem>[] criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            foreach (var criterion in _criteria)
            {
                if (criterion.IsSatisfiedBy(item))
                {
                    return true;
                }
            }
            return false;
        }
    }


    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _isASpeciesOf;

        public Negation(Criteria<TItem> isASpeciesOf)
        {
            _isASpeciesOf = isASpeciesOf;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_isASpeciesOf.IsSatisfiedBy(item);
        }
    }
}