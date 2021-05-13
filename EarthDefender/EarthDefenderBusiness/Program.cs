using EarthDefenderModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EarthDefenderBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDManager _crudManager = new CRUDManager();
            using(var db = new EarthDefenderContext())
            {
                var expected = db.Highscores.Where(h => h.User.FirstName == "Liam").FirstOrDefault().HighscoreID;

                _crudManager.UpdateHighscore(expected, 11);
                var updatedHighscore = db.Highscores.Find(expected);

                Console.WriteLine(updatedHighscore.Score);
            }

        }
    }
}
