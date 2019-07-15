using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCusers.Models
{
    public class Direccion
    {
        public int id_direccion { get; set; }
        [Required]
        public string calle { get; set; }
        [Required]
        public string colonia { get; set; }
        [Required]
        public string delegacion { get; set; }
        [Required]
        public int numero { get; set; }
        [Required]
        public int codigopostal { get; set; }
    }
}
