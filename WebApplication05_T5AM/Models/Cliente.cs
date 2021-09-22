using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication05_T5AM.Models
{
    public class Cliente
    {
        [Required]
        public String idcliente { get; set; }
        [Required]
        public String nombrecia { get; set; }
        [Required]
        public String direccion { get; set; }
        [Required]
        public String idpais { get; set; }
        [Required]
        public String telefono { get; set; }
     

    }
}