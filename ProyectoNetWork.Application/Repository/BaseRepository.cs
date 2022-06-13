using Microsoft.EntityFrameworkCore;
using ProyectoNetWork.Application.Interface;
using ProyectoNetWork.Data.Context;
using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Application.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        private readonly DataContext _dataContext;
        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddUser(T entity)
        {
            await Task.FromResult(_dataContext.Set<T>().Add(entity).State = EntityState.Added);
                _dataContext.SaveChanges();
            
        }

        public async Task<IEnumerable<T>> GetUser()
        {
                return await Task.FromResult(_dataContext.Set<T>().ToList());
           
        }

        public async Task<T> GetUserId(params object[] id)
        {

                var entity = await Task.FromResult(_dataContext.Set<T>().Find(id));
                return entity;
            
        }

        public async Task<T> UppdateUser(T entity)
        {
            await Task.FromResult(_dataContext.Set<T>().Update(entity).State = EntityState.Modified);
            _dataContext.SaveChanges();
            return entity;
        }
    }

}
