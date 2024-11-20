using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsBornAfter(int i)
        {
            return new BornAfterCriteria(i);
        }

        public static Criteria<Pet> IsMale()
        {
            return new SexCriteria(Sex.Male);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }
    }

    class SexCriteria : Criteria<Pet>
    {
        private Sex sex;

        public SexCriteria(Sex sex)
        {
            this.sex = sex;
        }
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == sex;
        }
    }

    internal class BornAfterCriteria : Criteria<Pet>
    {
        private int year;

        public BornAfterCriteria(int year)
        {
            this.year = year;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > year;
        }
    }

    internal class SpeciesCriteria : Criteria<Pet>
    {
        private Species species;

        public SpeciesCriteria(Species species)
        {
            this.species = species;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == species;
        }
    }
}