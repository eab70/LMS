using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SWCLMS.Models.Tables
{
    public class Course
    {
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public byte GradeLevel { get; set; }
        public bool IsArchived { get; set; }  //bit??
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SelectListItem> GradeLevels { get; set; }
        public List<SelectListItem> Subjects { get; set; }

        public void CreateGradeLevel(List<GradeLevel> gradeLevels)
        {
            GradeLevels = new List<SelectListItem>();

            foreach (var g in gradeLevels)
            {
                GradeLevels.Add(
                    new SelectListItem() { Text = g.GradeLevelName, Value = g.GradeLevelID.ToString() }
                    );
            }
        }

        public void CreateSubjectList(List<Subject> subjects)
        {
            Subjects = new List<SelectListItem>();

            foreach (var s in subjects)
            {
                Subjects.Add(
                    new SelectListItem() { Text = s.SubjectName, Value = s.SubjectID.ToString() }
                    );
            }
        }
    }
}
