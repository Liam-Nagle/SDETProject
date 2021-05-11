using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersModel
{
    public partial class SpaceInvadersContext : DbContext
    {
        public static SpaceInvadersContext Instance { get; } = new SpaceInvadersContext();

        public DbSet<User> Users { get; set; }
        public DbSet<Highscore> Highscores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = SpaceInvadersDB");
            }
        }
    }
}
