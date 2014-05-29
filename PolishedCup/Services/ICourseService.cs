using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishedCup.Services
{
    public interface ICourseService
    {
        Golf_Course Get(int courseID);
        int Save(Golf_Course course);
    }
}
