using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Repository
{
    public interface IRepository<T>
    {
        Task<int> Create(T t);
        Task<List<T>> Read();
        Task<int> Update(T t);
        Task<int> Delete(T t);

    }
}
