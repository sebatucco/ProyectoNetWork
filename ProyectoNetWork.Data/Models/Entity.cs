using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoNetWork.Data.Models
{
    public abstract class Entity
    {
        [Key]

        [JsonIgnore]
        public int Id { get; set; }
    }
}
