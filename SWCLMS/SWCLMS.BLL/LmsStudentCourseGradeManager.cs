using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LmsStudentCourseGradeManager
    {
        private ILmsStudentCourseRepository _lmsStudentCourseRepository;

        public LmsStudentCourseGradeManager(ILmsStudentCourseRepository lmsStudentCourseRepository)
        {
            _lmsStudentCourseRepository = lmsStudentCourseRepository;
        }

        public DataResponse<List<StudentCourse>> GetStudentCourses(int UserID)
        {
            var response = new DataResponse<List<StudentCourse>>();

            try
            {
                response.Data = _lmsStudentCourseRepository.GetStudentCourses(UserID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }


       public DataResponse<List<RosterAssignment>> CourseAssignmentGrades(int CourseID)
        {
           var response = new DataResponse<List<RosterAssignment>>(); 

            try
            {
                response.Data = _lmsStudentCourseRepository.CourseAssignmentGrades(CourseID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "No grades available";
            }

            return response;
        }

    }
}
