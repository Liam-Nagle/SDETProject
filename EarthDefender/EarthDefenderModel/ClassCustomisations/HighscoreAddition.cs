using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefenderModel
{
    public partial class Highscore
    {
        public override string ToString()
        {
            using(var db = new EarthDefenderContext())
            {
                return $"{Score} {User.Username}";
            }
        }

    }
}
