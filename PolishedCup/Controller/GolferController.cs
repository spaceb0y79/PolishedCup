using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PolishedCup.Models;
using PolishedCup.Services;

namespace PolishedCup.Controller
{
    [GolferAuthorizeFilter]
    public class GolferController : ApiController
    {
        private IGolferService _golferService;

        public GolferController(IGolferService golferService)
        {
            _golferService = golferService;
        }

        public DataResponse<Golf_Player> Get(int id)
        {
            return new DataResponse<Golf_Player>()
            {
                Data = _golferService.GetPlayer(id),
                Success = true
            };
        }

        public DataResponse<int> Post(GolfPlayerPackage package)
        {
            var result = new DataResponse<int>();
            result.Data = _golferService.Save(package);
            result.Success = true;

            return result;
        }
	}
}