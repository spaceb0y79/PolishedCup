using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishedCup.Models;

namespace PolishedCup.Services
{
    public interface IScoreService
    {
        int Save(ScorePackage package);
        bool Save(List<ScorePackage> packages);
    }
}
