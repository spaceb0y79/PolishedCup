using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolishedCup.Services
{
    public class CourseService : ICourseService
    {
        ISessionService _session;

        public CourseService(ISessionService session)
        {
            _session = session;
        }

        public Golf_Course Get(int courseID)
        {
            using (var db = new Polished2009Entities())
            {
                return db.Golf_Course.Find(courseID);
            }
        }

        public int Save(Golf_Course course)
        {
            using (var db = new Polished2009Entities())
            {
                if (course.CourseID > 0)
                {
                    var cur = db.Golf_Course.Find(course.CourseID);
                    cur.Address = course.Address;
                    cur.City = course.City;
                    cur.Name = course.Name;
                    cur.LastUpdatedDateUTC = DateTime.UtcNow;
                    cur.LastUpdatedBy = _session.GetCurrentGolfPlayerID();
                    cur.State = course.State;
                    cur.Zip = course.Zip;
                    cur.Status = course.Status;
                    cur.Active = course.Active;
                }
                else
                {
                    course.CreatedBy = _session.GetCurrentGolfPlayerID();
                    course.CreatedDateUTC = DateTime.UtcNow;

                    db.Entry(course).State = System.Data.Entity.EntityState.Added;

                    db.SaveChanges();
                }
            }

            return course.CourseID;
        }
    }
}