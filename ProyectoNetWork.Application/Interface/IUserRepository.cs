using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Application.Interface
{
    public interface IUserRepository
    {

        public Task<IEnumerable<User>> GetAllUsers();

        public Task AddUsers(User user);

        public Task<User> GetUsersId(int id);

        public Task<User> UppdateUsers(User user, int id);

    }
}
