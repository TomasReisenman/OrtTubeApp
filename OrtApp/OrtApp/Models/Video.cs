using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrtApp.Models
{
    public class Video
    {

        public int ID { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public int UsuarioID { get; set; }
  
        public virtual Usuario Usuario { get; set; }
    }

    /*
     *  public class VideoDB : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Usuario> Usuarios { get; set;}
    }
     * 
     */

}