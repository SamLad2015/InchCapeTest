using System.Collections.Generic;
using System.Threading.Tasks;

namespace InchCapeTest.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<IList<T>> GetAll(IList<string> includes = null);
    }
}