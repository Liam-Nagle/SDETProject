using SpaceInvadersModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvadersBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDManager _crudManager = new CRUDManager();
            using(var db = new SpaceInvadersContext())
            {
                var expected = db.Highscores.Where(h => h.User.FirstName == "Liam").FirstOrDefault().HighscoreID;

                _crudManager.UpdateHighscore(expected, 11);
                var updatedHighscore = db.Highscores.Find(expected);

                Console.WriteLine(updatedHighscore.Score);
            }

        }
    }
}
