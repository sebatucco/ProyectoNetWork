using ProyectoNetWork.Data.DTOs;
using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Application.Interface
{
    public interface ISecurityRepository
    {
        Task<User> LoginUser(SecurityDTO securityDTO);
    }
}
