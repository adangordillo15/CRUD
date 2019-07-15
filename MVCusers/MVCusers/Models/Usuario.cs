using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCusers.Models
{
    public class Usuario
    {
        public int CP { get; set; }
        [Required]
        public string nombre_usu { get; set; }
        [Required]
        public string appaterno { get; set; }
        [Required]
        public string apmaterno { get; set; }
        [Required]
        public int edad { get; set; }
    }
}
