using NUnit.Framework;
using SpaceInvadersBusiness;
using SpaceInvadersModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;

namespace SpaceInvaderTests
{
    public class Tests
    {
        CRUDManager _crudManager;
        [SetUp]
        public void Setup()
        {
            _crudManager = new CRUDManager();
            using (var db = new SpaceInvadersContext())
            {
                var selectedUsers =
                    from u in db.Users
                    where u.FirstName == "Liam"
                    select u;
                db.Users.RemoveRange(selectedUsers);

                var selectedHighscores =
                    from h in db.Highscores
                    where h.Score == 1
                    select h;
                db.Highscores.RemoveRange(selectedHighscores);
                db.SaveChanges();
            }

        }

        //CREATE TESTS

        [Test]
        public void WhenAUserIsCreated_TheNumberOfUsersIncreasesBy1()
        {
            using(var db = new SpaceInvadersContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                _crudManager.CreateUser("Liam", "Nagle", "LiamNagle", "password");
                var numberOfUsersAfter = db.Users.Count();

                Assert.AreEqual(numberOfUsersBefore + 1, numberOfUsersAfter);
            }
        }

        [Test]
        public void WhenAHighscoreIsCreated_TheNumberOfHighscoresIncreasesBy1()
        {
            using (var db = new SpaceInvadersContext())
            {
                var newUser = new User()
                {
                    FirstName = "Liam",
                    LastName = "Nagle",
                    Username = "LiamNagle",
                    Password = "password"
                };

                db.Users.Add(newUser);

                db.SaveChanges();

                var userID = db.Users.Where(u => u.FirstName == "Liam").FirstOrDefault().UserID;
                var numberOfHighscoresBefore = db.Highscores.Count();
                _crudManager.CreateHighscore(userID, 1);
                var numberOfHighscoresAfter = db.Highscores.Count();

                Assert.AreEqual(numberOfHighscoresBefore + 1, numberOfHighscoresAfter);
            }
        }

        //DELETE TESTS

        [Test]
        public void WhenAUserIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new SpaceInvadersContext())
            {
                var newUser = new User()
                {
                    FirstName = "Liam",
                    LastName = "Nagle",
                    Username = "LiamNagle",
                    Password = "password"
                };

                db.Users.Add(newUser);

                db.SaveChanges();

                var numberOfUsersBefore = db.Users.Count();

                _crudManager.DeleteUser(db.Users.Where(u => u.FirstName == "Liam").FirstOrDefault().UserID);

                var numberOfUsersAfter = db.Users.Count();

                Assert.AreEqual(numberOfUsersBefore - 1, numberOfUsersAfter);
            }
        }

        [Test]
        public void WhenAHighscoreIsRemoved_ItIsNoLongerInTheDatabase()
        {
            using (var db = new SpaceInvadersContext())
            {
                var newUser = new User()
                {
                    FirstName = "Liam",
                    LastName = "Nagle",
                    Username = "LiamNagle",
                    Password = "password"
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                var newHighscore = new Highscore()
                {
                    UserID = newUser.UserID,
                    Score = 1
                };

                db.Highscores.Add(newHighscore);
                db.SaveChanges();

                var numberOfHighscoresBefore = db.Highscores.Count();

                _crudManager.DeleteHighscore(newHighscore.HighscoreID);

                var numberOfHighscoresAfter = db.Highscores.Count();

                Assert.AreEqual(numberOfHighscoresBefore - 1, numberOfHighscoresAfter);
            }
        }

        //UPDATE TESTS

        [Test]
        public void WhenAUserIsUpdated_TheDatabaseIsUpdated()
        {
            using (var db = new SpaceInvadersContext())
            {
                var newUser = new User()
                {
                    FirstName = "Liam",
                    LastName = "Nagle",
                    Username = "LiamNagle",
                    Password = "password"
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                //Update user

                _crudManager.UpdateUser(newUser.UserID, "Liam", "Nagle", "LNagle", "password");
            }

            using (var db = new SpaceInvadersContext())
            {
                var updatedUser = db.Users.Where(u => u.FirstName == "Liam").FirstOrDefault();

                Assert.AreEqual("LNagle", updatedUser.Username);
            }
        }

        [Test]
        public void WhenAHighscoreIsUpdated_TheDatabaseIsUpdated()
        {

            using (var db = new SpaceInvadersContext())
            {
                var newUser = new User()
                {
                    FirstName = "Liam",
                    LastName = "Nagle",
                    Username = "LiamNagle",
                    Password = "password",
                    Highscores = new List<Highscore>() { new Highscore() { Score = 1 } }
                };
                db.Users.Add(newUser);
                db.SaveChanges();

                //Get the user Highscore
                var highscore = db.Highscores.Where(h => h.User.FirstName == "Liam").FirstOrDefault();

                //Update the highscore to 10
                _crudManager.UpdateHighscore(highscore.HighscoreID, 10);
            }

            //Uses two using statements to "Refresh" the database

            using (var db = new SpaceInvadersContext())
            {
                var updatedHighscore = db.Highscores.Where(h => h.User.FirstName == "Liam").FirstOrDefault();

                Assert.AreEqual(10, updatedHighscore.Score);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using(var db = new SpaceInvadersContext())
            {

                var selectedUsers =
                    from u in db.Users
                    where u.FirstName == "Liam"
                    select u;
                db.Users.RemoveRange(selectedUsers);

                var selectedHighscores =
                    from h in db.Highscores
                    where h.Score == 1
                    select h;
                db.Highscores.RemoveRange(selectedHighscores);
                db.SaveChanges();
            }
        }
    }
}