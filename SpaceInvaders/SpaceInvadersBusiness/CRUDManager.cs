using SpaceInvadersModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersBusiness
{
    public class CRUDManager
    {
        public User SelectedUser { get; set; }
        public Highscore SelectedHighscore { get; set; }

        //CREATE

        public void CreateUser(string firstName, string lastName, string username, string password)
        {
            var newUser = new User() { FirstName = firstName, LastName = lastName, Username = username, Password = password };
            using(var db = new SpaceInvadersContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void CreateHighscore(int userID, int score)
        {
            var newHighscore = new Highscore() { UserID = userID, Score = score };
            using(var db = new SpaceInvadersContext())
            {
                db.Highscores.Add(newHighscore);
                db.SaveChanges();
            }
        }

        //READ

        public void SetSelectedUser(object selectedItem)
        {
            SelectedUser = (User)selectedItem;
        }

        public void SetSelectedUser(int userID)
        {
            using(var db = new SpaceInvadersContext())
            {
                SelectedUser = db.Users.Where(u => u.UserID == userID).FirstOrDefault();
            }
        }

        public void SetSelectedHighscore(object selectedItem)
        {
            SelectedHighscore = (Highscore)selectedItem;
        }

        public void SetSelectedHighscore(int highscoreID)
        {
            using (var db = new SpaceInvadersContext())
            {
                SelectedHighscore = db.Highscores.Where(h => h.HighscoreID == highscoreID).FirstOrDefault();
            }
        }

        //UPDATE

        public void UpdateUser(int userID, string firstName, string lastName, string username, string password)
        {
            using(var db = new SpaceInvadersContext())
            {
                SelectedUser = db.Users.Where(u => u.UserID == userID).FirstOrDefault();
                SelectedUser.FirstName = firstName;
                SelectedUser.LastName = lastName;
                SelectedUser.Username = username;
                SelectedUser.Password = password;
                db.SaveChanges();
            }
        }

        public void UpdateHighscore(int highscoreID, int score)
        {
            using(var db = new SpaceInvadersContext())
            {
                SelectedHighscore = db.Highscores.Where(h => h.HighscoreID == highscoreID).FirstOrDefault();
                SelectedHighscore.Score = score;
                db.SaveChanges();
            }
        }

        //DELETE

        public void DeleteUser(int userID)
        {
            using(var db = new SpaceInvadersContext())
            {
                var userHighscores = db.Highscores.Where(u => u.UserID == userID);

                if(userHighscores.Count() > 0)
                {
                    foreach (var highscore in userHighscores)
                    {
                        DeleteHighscore(highscore.HighscoreID);
                    }
                }

                var selectedUser = db.Users.Where(u => u.UserID == userID).FirstOrDefault();
                db.Users.RemoveRange(selectedUser);
                db.SaveChanges();
            }
        }

        public void DeleteHighscore(int highScoreID)
        {
            using(var db = new SpaceInvadersContext())
            {
                var selectedHighscore = db.Highscores.Where(h => h.HighscoreID == highScoreID).FirstOrDefault();
                db.Highscores.RemoveRange(selectedHighscore);
                db.SaveChanges();
            }
        }
    }
}
