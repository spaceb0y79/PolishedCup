using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public interface IEventService
    {
        Golf_Event Get(int id);
        int Save(Golf_Event golfEvent);
    }
}
