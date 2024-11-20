using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
	public class Where_Pet
	{
		public static CriteriaBuilder HasAn(Func<Pet, Species> fieldSelector)
		{
			return new CriteriaBuilder(fieldSelector);
		}
	}

	public class CriteriaBuilder
	{
		private readonly Func<Pet, Species> _fieldSelector;

		public CriteriaBuilder(Func<Pet, Species> fieldSelector)
		{
			_fieldSelector = fieldSelector;
		}

		public Criteria<Pet> EqualTo(Species species)
		{
			return new AnonymousCriteria<Pet>(pet => _fieldSelector(pet) == species);
		}
	}
}
