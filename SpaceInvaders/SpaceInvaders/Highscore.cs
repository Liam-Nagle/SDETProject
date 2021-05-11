using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersModel
{
    public partial class Highscore
    {
        public int HighscoreID { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }

        public virtual User User { get; set; }
    }
}
