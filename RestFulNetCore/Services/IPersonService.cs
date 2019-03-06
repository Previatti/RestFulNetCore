using RestFulNetCore.Model;
using System.Collections.Generic;

namespace RestFulNetCore.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);

    }
}
