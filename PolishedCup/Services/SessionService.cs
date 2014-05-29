using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Threading;
using PolishedCup.Models;
using PolishedCup.App_Start;
using System.Data.SqlClient;

namespace PolishedCup.Services
{
    public class SessionService : ISessionService
    {
        private string _playerUserName;
        private int? _golfEventID;
        private int _golfPlayerID;
        private int? _golfEventPlayingGroupID;  

        public string PlayerUserName { get; set; }
        public int? Golf_EventID { get; set; }
        public int Golf_PlayerID { get; set; }
        public int? Golf_EventPlayingGroupID { get; set; }

        
        private SessionService internalSession
        {
            get
            {
                var golfPrincipal = Thread.CurrentPrincipal as GolfPrincipal;
                
                return golfPrincipal.Session;

            }
        }
        public SessionService()
        {
            
        }

        public string GetCurrentPlayerUserName()
        {
            return internalSession.PlayerUserName;
        }

        public int GetCurrentGolfPlayerID()
        {
            return internalSession.Golf_PlayerID;
        }

        public int? GetCurrentEventPlayingGroupID()
        {
            return internalSession.Golf_EventPlayingGroupID;
        }

        public int? GetCurrentEventID()
        {
            return internalSession.Golf_EventID;
        }

        public AuthenicationPackage AuthenicateLogin(string username, string password, string ipAddress)
        {
            var guid = Guid.NewGuid().ToString();
            Golf_Player player = null;
            AuthenicationPackage rtn = null;
            if (LogIn(username, password, out player))
            {
                guid = CreateSession(player.PlayerID, username, password, ipAddress);

                rtn = new AuthenicationPackage()
                {
                    PlayerID = player.PlayerID,
                    Token = guid
                };

                return rtn;
            }
            else
            {
                throw new Exception("Invalid UserName or Password. Please try again.");
            }
        }
        
        public bool ValidateSession(string userToken, string password)
        {
            var rtn = false;

            using (var db = new Polished2009Entities())
            {
                var session = db.Golf_PlayerSession.FirstOrDefault(x => x.SessionToken == userToken);
                if (session != null && session.ExpirationDateUTC < DateTime.UtcNow)
                {
                    rtn = false;

                    if (!string.IsNullOrEmpty(password))
                    {
                        Golf_Player player = null;
                        Guid guid;
                        if (Guid.TryParse(userToken, out guid))
                        {
                            LogIn(guid, password, out player);

                            if (player != null)
                            {
                                session.ExpirationDateUTC = DateTime.UtcNow.AddHours(2);
                                db.Entry(session).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();

                                rtn = true;
                            }
                        }
                    }

                }
                else if (session != null && session.ExpirationDateUTC > DateTime.UtcNow)
                {
                    rtn = true;
                }
                else
                {
                    throw new Exception("Invalid Session");
                }
            }

            return rtn;

        }

        private bool LogIn(string username, string password, out Golf_Player player)
        {
            var rtn = false;
            using (var db = new Polished2009Entities())
            {
                player = db.Golf_Player.FirstOrDefault(x => x.UserName == username);

                if (player != null)
                {
                    var encrypt = new EncryptPackage()
                    {
                        PlainTextPassword = password,
                        Salt = Convert.FromBase64String(player.Password2),
                        HashPassword = Convert.FromBase64String(player.Password),
                        Attempts = 1
                    };

                    rtn = Encrypt.ValidatePassword(encrypt);
                }
            }

            return rtn;
        }

        private bool LogIn(Guid guid, string password, out Golf_Player player)
        {
            var rtn = false;

            using (var db = new Polished2009Entities())
            {
                var session = db.Golf_PlayerSession.Where(x => x.SessionToken == guid.ToString()).FirstOrDefault();
                if (session != null)
                {
                    rtn = LogIn(session.UserName, password, out player);
                }
                else
                {
                    player = null;
                }
            }

            return rtn;
        }

        public void LoadSession(string userToken)
        {
            //string userToken = actionContext.Request.Headers.GetValues(Constant.HttpHeader_Token).FirstOrDefault();
            using (var db = new Polished2009Entities())
            {
                var session = db.Golf_PlayerSession.FirstOrDefault(x => x.SessionToken == userToken && x.ExpirationDateUTC > DateTime.UtcNow);
                if (session != null)
                {
                    this.Golf_PlayerID = session.PlayerID;
                    this.Golf_EventID = session.EventID;
                    this.Golf_EventPlayingGroupID = session.EventPlayingGroupID;
                    this.PlayerUserName = session.UserName;
                }
            }                    
        }

        private void SaveSession(Golf_PlayerSession session)
        {
            using (var db = new Polished2009Entities())
            {
                var curSession = db.Golf_PlayerSession.Where(x => x.PlayerSessionID == session.PlayerSessionID && x.SessionToken == session.SessionToken && x.ExpirationDateUTC >= session.ExpirationDateUTC).FirstOrDefault();
                if (curSession != null)
                {
                    curSession.ExpirationDateUTC = DateTime.UtcNow.AddHours(5);
                }
            }
        }
 
        private string CreateSession(int playerID, string userName, string password, string ipAddress)
        {
            var guid = Guid.NewGuid().ToString();

            var session = new Golf_PlayerSession()
            {
                SessionToken = guid,
                IpAddress = ipAddress,
                PlayerID = playerID,
                UserName = userName,
                CreatedDateUTC = DateTime.UtcNow,
                ExpirationDateUTC = DateTime.UtcNow.AddHours(5)
            };

            using (var db = new Polished2009Entities())
            {
                var curPlayer = db.Golf_Player.Find(playerID);
                curPlayer.LastLoginLocal = DateTime.Now;
                curPlayer.LastLoginUTC = DateTime.UtcNow;

                db.Golf_PlayerSession.Add(session);
                db.SaveChanges();
            }

            return guid;

        }
    }
}