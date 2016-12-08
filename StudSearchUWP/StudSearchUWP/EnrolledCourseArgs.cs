using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudSearchUWP
{
    public class EnrolledCourseArgs
    {
        /// <summary>
        /// represents the Unique Identification of a Course
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// represents the Semester the course was taken
        /// </summary>
        public int Semester { get; set; }
        /// <summary>
        /// represents the year the course was taken
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// represents the grade earned from taking the course
        /// </summary>
        public char Grade { get; set; }

        public int CourseNumber { get; set; }
    }
}
