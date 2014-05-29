using PolishedCup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishedCup.Services
{
    public interface ISessionService
    {
        string GetCurrentPlayerUserName();
        int GetCurrentGolfPlayerID();

        int? GetCurrentEventPlayingGroupID();

        int? GetCurrentEventID();
        string PlayerUserName { get; set; }

        bool ValidateSession(string userToken, string password);
        AuthenicationPackage AuthenicateLogin(string username, string password, string ipAddress);
    }
}
