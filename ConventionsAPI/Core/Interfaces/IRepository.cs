using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        T Create(T item);
        T Update(T item);

        T Delete(T item);
    }
}
