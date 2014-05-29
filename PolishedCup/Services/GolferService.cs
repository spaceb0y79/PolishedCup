using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public class GolferService : IGolferService
    {
        private ISessionService _session;
        public GolferService(ISessionService session)
        {
            _session = session;
        }

        public Golf_Player GetPlayer(int playerID)
        {
            Golf_Player player = null;

            using (var db = new Polished2009Entities())
            {
               var cPlayerID =  _session.GetCurrentGolfPlayerID();
                player = db.Golf_Player.Find(playerID);
            }

            return player;
        }

        public int Save(GolfPlayerPackage player)
        {
            var passwordHash = string.Empty;
            var salt = string.Empty;

            using (var db = new Polished2009Entities())
            {
                if (!string.IsNullOrEmpty(player.NewPasswordPlainText))
                {
                    var hash = Encrypt.CreateHash(player.NewPasswordPlainText);
                    passwordHash = Convert.ToBase64String(hash.HashPassword);
                    salt = Convert.ToBase64String(hash.Salt);
                }

                if (player.PlayerID > 0) //update player
                {
                    var curPlayer = db.Golf_Player.Find(player.PlayerID);

                    if (!string.IsNullOrEmpty(player.OldPasswordPlainText) && 
                        Encrypt.ValidatePassword(new EncryptPackage{ 
                            PlainTextPassword= player.OldPasswordPlainText, 
                            Salt = Convert.FromBase64String(player.Password2)
                        }))
                    {
                        curPlayer.Password = passwordHash;
                        curPlayer.Password2 = salt;
                    }

                    curPlayer.LastUpdatedBy = _session.GetCurrentGolfPlayerID();
                    curPlayer.LastUpdatedUTC = DateTime.UtcNow;
                    
                    curPlayer.FirstName = player.FirstName;
                    curPlayer.LastName = player.LastName;
                    curPlayer.NickName = player.NickName;
                    curPlayer.PhoneNumber = player.PhoneNumber;
                    curPlayer.EmailAddress = player.EmailAddress;

                    db.SaveChanges();
                }
                else
                {

                    var existingPlayer = db.Golf_Player.Where(x => x.UserName == player.UserName).FirstOrDefault();
                    if (existingPlayer != null)
                    {
                        throw new Exception("UserName is already taken");
                    }
                    var newPlayer = new Golf_Player()
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        NickName = player.NickName,
                        PhoneNumber = player.PhoneNumber,
                        EmailAddress = player.EmailAddress,
                        UserName = player.UserName,
                        Password = passwordHash,
                        Password2 = salt,
                        LastUpdatedBy = _session.GetCurrentGolfPlayerID(),
                        LastUpdatedUTC = DateTime.UtcNow,
                        CreatedBy = _session.GetCurrentGolfPlayerID(),
                        CreatedDateUTC = DateTime.UtcNow
                        
                    };

                    db.Entry(newPlayer).State = System.Data.Entity.EntityState.Added;

                    db.SaveChanges();

                    player.PlayerID = newPlayer.PlayerID;
                }
            }

            return player.PlayerID;
        }

    }
}