﻿using RestFulNetCore.Model;
using RestFulNetCore.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestFulNetCore.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private volatile int count;
        private readonly MySQLContext _context;

        public PersonRepository(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                var p = _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long Id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));

            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Person> FindAll()
        {
            //List<Person> persons = new List<Person>();
            //for (int i = 0; i < 8; i++)
            //{
            //    Person person = MockPerson(i);
            //    persons.Add(person);
            //}

            return _context.Persons.ToList();
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
            return _context.Persons.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}
