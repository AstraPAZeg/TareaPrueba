using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pruebaTarea.Models
{
    public class DataContext: DbContext 
    {
        public DataContext():base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<pruebaTarea.Models.aguilar> Students { get; set; }
    }
}