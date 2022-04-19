using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieDb.DataAccess.Model;

namespace MovieDb.DataAccess.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MovieDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
