using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using PolishedCup.Services;
using PolishedCup.Models;

namespace PolishedCup.Controller
{
    [GolferAuthorizeFilter]
    public class ScorecardController : ApiController
    {
        IScoreService _holeDetail;

        public ScorecardController(IScoreService holeDetail)
        {
            _holeDetail = holeDetail;
        }

        public DataResponse<int> Post(ScorePackage package)
        {
            return new DataResponse<int>()
            {
                Data = _holeDetail.Save(package),
                Success = true
            };

        }

        
	}
}