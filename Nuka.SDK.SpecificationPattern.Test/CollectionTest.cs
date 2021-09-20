using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Nuka.SDK.SpecificationPattern.Test
{
    public class CollectionTest
    {
        private readonly List<Person> _persons;

        public CollectionTest()
        {
            _persons = new List<Person>()
            {
                new Person() { Name = "alpha", Age = 39, IsMarried = false },
                new Person() { Name = "beta", Age = 14, IsMarried = false },
                new Person() { Name = "gamma", Age = 65, IsMarried = true },
            };
        }

        [Fact]
        public void TestCollection()
        {
            var marriedSpec = new MarriedSpecification();
            var u18Spec = new MaxAgeSpecification(18);

            var marriedPersons = _persons.Where(marriedSpec.IsSatisfiedBy).ToList();
            Assert.DoesNotContain(marriedPersons, person => person.Name == "alpha");
            Assert.DoesNotContain(marriedPersons, person => person.Name == "beta");
            Assert.Contains(marriedPersons, person => person.Name == "gamma");

            var u18Persons = _persons.Where(u18Spec.IsSatisfiedBy).ToList();
            Assert.DoesNotContain(u18Persons, person => person.Name == "alpha");
            Assert.Contains(u18Persons, person => person.Name == "beta");
            Assert.DoesNotContain(u18Persons, person => person.Name == "gamma");

            var u18AndUnmarriedPersons = _persons.Where(marriedSpec.Negate().And(u18Spec).IsSatisfiedBy).ToList();
            Assert.DoesNotContain(u18AndUnmarriedPersons, person => person.Name == "alpha");
            Assert.Contains(u18AndUnmarriedPersons, person => person.Name == "beta");
            Assert.DoesNotContain(u18AndUnmarriedPersons, person => person.Name == "gamma");

            var u18OrUnMarriedPersons = _persons.Where(marriedSpec.Negate().Or(u18Spec).IsSatisfiedBy).ToList();
            Assert.Contains(u18OrUnMarriedPersons, person => person.Name == "alpha");
            Assert.Contains(u18OrUnMarriedPersons, person => person.Name == "beta");
            Assert.DoesNotContain(u18OrUnMarriedPersons, person => person.Name == "gamma");
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsMarried { get; set; }
        }

        private class MarriedSpecification : SpecificationBase<Person>
        {
            public override Expression<Func<Person, bool>> SpecificationExpression => p => p.IsMarried == true;
        }

        private class MaxAgeSpecification : SpecificationBase<Person>
        {
            private readonly int _maxAge;

            public MaxAgeSpecification(int maxAge)
            {
                _maxAge = maxAge;
            }

            public override Expression<Func<Person, bool>> SpecificationExpression => p => p.Age <= _maxAge;
        }
    }
}