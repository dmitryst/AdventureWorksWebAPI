using AdventureWorksWebAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksWebAPI.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> TestScalarFunction(int id);
    }
}