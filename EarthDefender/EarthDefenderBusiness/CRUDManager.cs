using EarthDefenderModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthDefenderBusiness
{
    public class CRUDManager
    {
        public User SelectedUser { get; set; }
        public Highscore SelectedHighscore { get; set; }

        //CREATE

        public void CreateUser(string firstName, string lastName, string username, string password)
        {
            var newUser = new User() { FirstName = firstName, LastName = lastName, Username = username, Password = password };
            using(var db = new EarthDefenderContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void CreateHighscore(int userID, int score)
        {
            var newHighscore = new Highscore() { UserID = userID, Score = score };
            using(var db = new EarthDefenderContext())
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
            using(var db = new EarthDefenderContext())
            {
                SelectedUser = db.Users.Where(u => u.UserID == userID).FirstOrDefault();
            }
        }

        public void SetSelectedUser(string username)
        {
            using (var db = new EarthDefenderContext())
            {
                SelectedUser = db.Users.Where(u => u.Username == username).FirstOrDefault();
            }
        }

        public void SetSelectedHighscore(object selectedItem)
        {
            SelectedHighscore = (Highscore)selectedItem;
        }

        public void SetSelectedHighscore(int highscoreID)
        {
            using (var db = new EarthDefenderContext())
            {
                SelectedHighscore = db.Highscores.Where(h => h.HighscoreID == highscoreID).FirstOrDefault();
            }
        }

        public List<string> RetrieveAllUsernames()
        {
            using(var db = new EarthDefenderContext())
            {
                return db.Users.OrderBy(u => u.Username).Select(u => u.Username).ToList();
            }
        }

        public List<Highscore> RetrieveAllUserHighscores()
        {
            using (var db = new EarthDefenderContext())
            {
                return db.Highscores.Where(h => h.UserID == SelectedUser.UserID).OrderByDescending(h => h.Score).Include(u => u.User).ToList();
            }
        }

        public List<Highscore> RetrieveAllUserHighscores(string username)
        {
            using (var db = new EarthDefenderContext())
            {
                return db.Highscores.Where(h => h.User.Username == username).OrderByDescending(h => h.Score).Include(u => u.User).ToList();
            }
        }

        public List<Highscore> RetrieveAllHighscores()
        {
            using (var db = new EarthDefenderContext())
            {
                return db.Highscores.OrderByDescending(h => h.Score).Include(u => u.User).ToList();
            }
        }

        public List<Highscore> RetrieveTop3Highscores()
        {
            using (var db = new EarthDefenderContext())
            {
                return db.Highscores.OrderByDescending(h => h.Score).Include(u => u.User).Take(3).ToList();
            }
        }

        public List<int> RetrieveUserHighscorePositions()
        {
            using (var db = new EarthDefenderContext())
            {
                return Enumerable.Range(0, RetrieveAllHighscores().Count).Where(c => RetrieveAllHighscores()[c].UserID == SelectedUser.UserID).ToList();
            }
        }

        public List<int> RetrieveUserHighscorePositions(string username)
        {
            using (var db = new EarthDefenderContext())
            {
                return Enumerable.Range(0, RetrieveAllHighscores().Count).Where(c => RetrieveAllHighscores()[c].User.Username == username).ToList();
            }
        }

        public List<int> RetrieveAllHighscorePositions()
        {
            using (var db = new EarthDefenderContext())
            {
                return Enumerable.Range(0, RetrieveAllHighscores().Count).ToList();
            }
        }

        public bool CheckIfUsernameExists(string username)
        {
            using(var db = new EarthDefenderContext())
            {
                if(db.Users.Where(u => u.Username == username).Count() > 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        //UPDATE

        public void UpdateUser(int userID, string firstName, string lastName, string username, string password)
        {
            using(var db = new EarthDefenderContext())
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
            using(var db = new EarthDefenderContext())
            {
                SelectedHighscore = db.Highscores.Where(h => h.HighscoreID == highscoreID).FirstOrDefault();
                SelectedHighscore.Score = score;
                db.SaveChanges();
            }
        }

        //DELETE

        public void DeleteUser(int userID)
        {
            using(var db = new EarthDefenderContext())
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
            using(var db = new EarthDefenderContext())
            {
                var selectedHighscore = db.Highscores.Where(h => h.HighscoreID == highScoreID).FirstOrDefault();
                db.Highscores.RemoveRange(selectedHighscore);
                db.SaveChanges();
            }
        }

        public bool LoginDetails(string username, string password)
        {
            using(var db = new EarthDefenderContext())
            {
                var selectedUser = db.Users.Where(u => u.Username == username).FirstOrDefault();
                if(selectedUser == null)
                {
                    return false;
                } else if(selectedUser.Password == password)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}
