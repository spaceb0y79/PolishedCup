using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PolishedCup.Services;
using PolishedCup.Models;

namespace PolishedCup.Controller
{
    [GolferAuthorizeFilter]
    public class CourseController : ApiController
    {
        ICourseService _course;

        public CourseController(ICourseService course)
        {
            _course = course;
        }

        public DataResponse<Golf_Course> Get(int id)
        {
            return new DataResponse<Golf_Course>()
            {
                 Data = _course.Get(id),
                 Success = true
            };
        }

        
        public DataResponse<int> Post(Golf_Course course)
        {
            return new DataResponse<int>()
            {
                Data = _course.Save(course),
                Success = true
            };
        }
	}
}