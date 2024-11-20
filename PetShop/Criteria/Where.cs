using System;
using System.Runtime.CompilerServices;
using Training.DomainClasses;

namespace Training.Specificaton
{
	public class Where
	{
		public static CriteriaBuilder<TField> Has<TField>(Func<Pet, TField> fieldSelector)
		{
			return new CriteriaBuilder<TField>(fieldSelector);
		}

	}

	public class CriteriaBuilder<TField>
	{
		private readonly Func<Pet, TField> _fieldSelector;

		public CriteriaBuilder(Func<Pet, TField> fieldSelector)
		{
			_fieldSelector = fieldSelector;
		}

		public Criteria<Pet> EqualTo(TField value)
		{
			return new AnonymousCriteria<Pet>(p => _fieldSelector(p).Equals(value));
		}
	}
}