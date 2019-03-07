using RestFulNetCore.Model;
using RestFulNetCore.Model.Context;
using RestFulNetCore.Repository;
using RestFulNetCore.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestFulNetCore.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private volatile int count;
        private readonly IRepository<Person> _repository;

        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
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
            return _repository.FindById(Id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
