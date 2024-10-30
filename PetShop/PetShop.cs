using System;
using System.Collections;
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
            //return _petsInTheStore.OneAtATime();
            return new ReadOnlySet(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (!_petsInTheStore.Contains(newPet))
            {
                _petsInTheStore.Add(newPet);
            }
        }
    }

    public class ReadOnlySet : IEnumerable<Pet>
    {
        public IEnumerable<Pet> items { get; set; }

        public ReadOnlySet(IEnumerable<Pet> items)
        {
            this.items = items;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}