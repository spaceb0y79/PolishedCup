using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishedCup.Services;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public interface IGolferService
    {
        Golf_Player GetPlayer(int playerID);
        int Save(GolfPlayerPackage player);
    }
}
