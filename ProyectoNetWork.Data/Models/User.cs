using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetWork.Data.Models
{
    public class User : Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Sex { get; set; }
    }
}
