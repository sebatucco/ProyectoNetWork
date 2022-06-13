using Microsoft.EntityFrameworkCore;
using ProyectoNetWork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Data.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options)
       : base(options)
        {
        }
      
        public DbSet<User> Users { get; set; }
    }
}
