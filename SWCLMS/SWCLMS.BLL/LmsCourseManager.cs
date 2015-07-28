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
    public class LmsCourseManager
    {
        private ILmsCourseRepository _lmsCourseRepository;

        public LmsCourseManager(ILmsCourseRepository lmsCourseRepository)
        {
            _lmsCourseRepository = lmsCourseRepository;
        }

        public DataResponse<List<TeacherCourses>> GetTeacherCourses(int userID)
        {
            var response = new DataResponse<List<TeacherCourses>>();

            try
            {
                response.Data = _lmsCourseRepository.GetTeacherCourses(userID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public DataResponse<Course> ShowCourse(int CourseID)
        {
            var response = new DataResponse<Course>();

            try
            {
                response.Data = _lmsCourseRepository.ShowTeacherCourse(CourseID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response EditCourseDetails(Course courseToEdit)
        {
            var response = new Response();

            try
            {
                _lmsCourseRepository.EditTeacherCourse(courseToEdit);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public Response AddCourse(Course courseToAdd)
        {
            var response = new Response();

            try
            {
                _lmsCourseRepository.AddCourse(courseToAdd);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}