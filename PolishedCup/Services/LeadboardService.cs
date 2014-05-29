using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public class LeadboardService : ILeaderboardService
    {
        public LeadboardService()
        {

        }

        public List<Golf_PlayerScoreCard> GetEventLeaderboard(int? eventID = null)
        {
            List<Golf_PlayerScoreCard> leaderboard = null;
            using (var db = new Polished2009Entities())
            {
                if (!eventID.HasValue || eventID <= 0)
                {
                    eventID = db.Golf_PlayerScoreCard.Max(x => x.EventID);
                }

                leaderboard = db.Golf_PlayerScoreCard.Where(x => x.EventID == eventID).ToList();
            }
            return leaderboard;
        }

        public List<Golf_PlayerScoreCard> GetGroupLeaderboard(int eventID, int eventPlayingGroupID)
        {
            List<Golf_PlayerScoreCard> leaderboard = null;
            using (var db = new Polished2009Entities())
            {
                leaderboard = db.Golf_PlayerScoreCard.Where(x => x.EventID == eventID).ToList();
            }
            return leaderboard;
        }

        public Golf_PlayerScoreCard GetPlayerScoreDetail(int eventID, int playerID)
        {
            throw new NotImplementedException();
        }
    }
}