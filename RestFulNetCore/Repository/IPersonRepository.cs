using RestFulNetCore.Model;
using System.Collections.Generic;

namespace RestFulNetCore.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
        bool Exists(long? Id);
    }
}
