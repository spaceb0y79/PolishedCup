using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public interface ILeaderboardService
    {
        List<Golf_PlayerScoreCard> GetEventLeaderboard(int? eventID = null);
        List<Golf_PlayerScoreCard> GetGroupLeaderboard(int eventID, int eventPlayingGroupID);
        Golf_PlayerScoreCard GetPlayerScoreDetail(int eventID, int playerID);
    }
}
