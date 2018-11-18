using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrtApp.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}