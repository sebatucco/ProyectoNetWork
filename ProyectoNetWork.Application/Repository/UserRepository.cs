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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task AddUsers(User user)
        {
            try
            {
                await AddUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"error al insertar entitdad: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await GetUser();
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"error al obtener entidad: {ex.Message}");
            }
        }

        public async Task<User> GetUsersId(int id)
        {
            try
            {
                var user = await GetUserId(id);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"error al obtener entidad: {ex.Message}");
            }
        }

        public async Task<User> UppdateUsers(User user, int id)
        {
            try
            {
                var uppdateUser = await GetUsersId(id);

                uppdateUser.LastName = user.LastName;
                uppdateUser.FirstName = user.FirstName;
                uppdateUser.Password = user.Password;
                uppdateUser.BirthDate = user.BirthDate;
                uppdateUser.Sex = user.Sex;

                var userResponse = await UppdateUser(user);
                return userResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(message: $"error al actualizar entitdad: {ex.Message}");
            }
        }
    }
}
