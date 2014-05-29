using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System.Web;
using System.Web.Http.Filters;
using System.Linq;
using PolishedCup.App_Start;
using System.Threading;

namespace PolishedCup.Services
{
    public class GolferAuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            bool valid = false;

            if (actionContext.Request.Headers.Contains(Constant.HttpHeader_Token))
            {
                valid = ProcessAuth(actionContext);
            }

            if (!valid)
                throw new HttpException("User not authorized");
        }

        private bool ProcessAuth(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            bool returnValue = false;

            string userToken = actionContext.Request.Headers.GetValues(Constant.HttpHeader_Token).FirstOrDefault();
            string password = null;

            if (actionContext.Request.Headers.Contains(Constant.HttpHeader_Password))
                password = actionContext.Request.Headers.GetValues(Constant.HttpHeader_Password).FirstOrDefault();

            var session = new SessionService();

            returnValue = session.ValidateSession(userToken, password);
            CreateCarAppThreadPrincipal(userToken);
            
            return returnValue;

        }

        private static void CreateCarAppThreadPrincipal(string sessionKey)
        {
            SessionService session = new SessionService();

            session.LoadSession(sessionKey);

            Thread.CurrentPrincipal = new GolfPrincipal(session);

        }

    }
}