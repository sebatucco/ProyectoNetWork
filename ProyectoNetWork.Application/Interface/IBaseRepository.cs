using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Application.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetUser();

        public Task AddUser(T entity);

        Task<T> GetUserId(params object[] id);

        Task<T> UppdateUser(T entity);
    }
}
