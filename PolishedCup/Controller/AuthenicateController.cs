using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PolishedCup.Services;
using PolishedCup.Models;

namespace PolishedCup.Controller
{
    public class AuthenicateController : ApiController
    {
        private ISessionService _session;

        public AuthenicateController(ISessionService session)
        {
            _session = session;
        }
        //
        // GET: /Authenicate/
        [HttpPost]
        public DataResponse<AuthenicationPackage> Post(CredentialPackage package)
        {
            var result = new DataResponse<AuthenicationPackage>();
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(2).ToString();
            result.Data = _session.AuthenicateLogin(package.UserName, package.Password, clientIPAddress);
            result.Success = true;

            return result;

        }

        [HttpGet]
        public DataResponse<string> Get()
        {
            var result = new DataResponse<string>();
            result.Data = "Hello Trung";
            result.Success = true;

            return result;
        }
	}
}