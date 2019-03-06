using RestFulNetCore.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestFulNetCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "First " + i,
                LastName = "Last" + i,
                Address = "Rua ABC",
                Gender = "M"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long Id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Alexandre",
                LastName = "Previatti",
                Address = "Rua ABC",
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
