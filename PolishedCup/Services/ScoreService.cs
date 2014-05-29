using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public class ScoreService : IScoreService
    {
        ISessionService _session;
        public ScoreService(ISessionService session)
        {
            _session = session;
        }

        public int Save(ScorePackage package)
        {
            var rtn = -1;
            var canSaveScore = CanSaveScore(package.PlayerID);

            if(canSaveScore)
            {
                using(var db = new Polished2009Entities())
                {   
                    var score = new Golf_PlayerHoleDetail()
                    {
                        PlayerID = package.PlayerID,
                        CourseID = package.CourseID,
                        EventID = (int)_session.GetCurrentEventID(),
                        FairWayHit = package.FairWayHit,
                        GIR = package.GIR,
                        HoleID = package.HoleID,
                        LostBall = package.LostBall,
                        Putts = package.Putts,
                        SandSave = package.SandSave,
                        Score = package.Score
                    };
                }
            }
            else
            {
                throw new Exception("Current player cannot record score for selected player.");
            }
            return rtn;
        }

        public bool Save(List<ScorePackage> packages)
        {
            throw new NotImplementedException();
        }

        private bool CanSaveScore(int playerID)
        {
            var rtn = false;

            using (var db = new Polished2009Entities())
            {
                var player = db.Golf_EventPlayingGroupPlayer.Where(x => x.PlayerID == playerID && x.EventPlayingGroupID == _session.GetCurrentEventPlayingGroupID()).FirstOrDefault();
                if (player != null)
                {
                    rtn = true;
                }
            }

            return rtn;
        }
    }
}