using ProyectoNetWork.Application.Interface;
using ProyectoNetWork.Data.Context;
using ProyectoNetWork.Data.DTOs;
using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Application.Repository
{
    public class SecurityRepository : BaseRepository<User>, ISecurityRepository
    {
        public SecurityRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<User> LoginUser(SecurityDTO securityDTO)
        {
            var users = await GetUser();
            var user = users.Where(x => x.Mail == securityDTO.Mail && x.Password == securityDTO.Password).FirstOrDefault();
            return user != null ? user : null;


        }
    }
}
