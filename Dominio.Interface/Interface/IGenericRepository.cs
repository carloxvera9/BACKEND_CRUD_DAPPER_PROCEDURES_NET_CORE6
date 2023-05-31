using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Interface
{
    public interface IGenericRepository<T> where T: class
    {

        Task<IReadOnlyList<T>> ListaByIdAsycn(int id);
        Task<IReadOnlyList<T>> ListTodoAsync();

        Task<int> NewLibroAsync(T entity);

        Task<int> DeleteLibroAsycn(int id);

        Task<int> ActualizarLibroAsycn(T entity);

    }
}
