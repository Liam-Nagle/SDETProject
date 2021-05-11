using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersModel
{
    public partial class User
    {
        public User()
        {
            Highscores = new HashSet<Highscore>();
        }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Highscore> Highscores { get; set; }

    }
}
