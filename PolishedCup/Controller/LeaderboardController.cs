using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PolishedCup.Services;
using PolishedCup.Models;

namespace PolishedCup.Controller
{
    public class LeaderboardController : ApiController
    {
        private ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        public DataResponse<List<Golf_PlayerScoreCard>> Get()
        {
            return new DataResponse<List<Golf_PlayerScoreCard>>()
            {
                Data = _leaderboardService.GetEventLeaderboard(),
                Success = true
            };
        }

        public DataResponse<List<Golf_PlayerScoreCard>> Get(int eventID)
        {
            return new DataResponse<List<Golf_PlayerScoreCard>>()
            {
                Data = _leaderboardService.GetEventLeaderboard(eventID),
                Success = true
            };
        }

        public DataResponse<List<Golf_PlayerScoreCard>> Get(int eventID, int eventPlayingGroupID)
        {
            return new DataResponse<List<Golf_PlayerScoreCard>>()
            {
                Data = _leaderboardService.GetEventLeaderboard(eventID),
                Success = true
            };
        }

	}
}