using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BocceBall.Models;

namespace BocceBall.Data
{
    class BocceContext : DbContext
    {
        public BocceContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Players> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
