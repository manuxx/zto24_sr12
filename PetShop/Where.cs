using System;
using Training.DomainClasses;

namespace Training
{
	public class Where<T>
	{
		public static bool HasAn(Func<object, object> value)
		{
			throw new NotImplementedException();
		}
	}

	public class CriteriaBuilder
	{
		private readonly Func<Pet, Species> _fieldSelector;

		public CriteriaBuilder(Func<Pet, Species> fieldSelector)
		{
			_fieldSelector = fieldSelector;
		}

		public Criteria<Pet> IsEqual(Species species)
		{
			return new Pet.SpeciesCriteria(species);
		}
	}
}