using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudSearchUWP
{
    public class EnrolledCourse
    {
        #region Members
        /// <summary>
        /// represents the <see cref="string"/> "Info"
        /// </summary>
        public static string Info = "Info";
        private Course m_Info;
        /// <summary>
        /// represents the <see cref="Course"/> data
        /// </summary>
        public Course info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Course ID"
        /// </summary>
        public static string CourseID = "Course ID";
        private int m_courseID;
        /// <summary>
        /// represents the course
        /// </summary>
        public int courseID
        {
            get { return m_courseID; }
            set { m_courseID = value; }
        }


        public static string CourseNumber = "Course Number";
        private int m_courseNumber;
        public int courseNumber
        {
            get { return m_courseNumber; }
            set { m_courseNumber = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Semester"
        /// </summary>
        public static string Semester = "Semester";
        private SemesterType m_semester;
        /// <summary>
        /// represents a <see cref="semester"/> of the course the student has taken.
        /// </summary>
        /// <see cref="SemesterType"/> 
        public SemesterType semester
        {
            get { return m_semester; }
            set { m_semester = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Year"
        /// </summary>
        public static string Year = "Year";
        private int m_year;
        /// <summary>
        /// represents the <see cref="year"/> the student took the course. 
        /// </summary>
        public int year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Grade"
        /// </summary>
        public static string Grade = "Grade";
        private LetterGrade m_grade;
        /// <summary>
        /// represents the <see cref="LetterGrade"/> earned
        /// </summary>
        public LetterGrade grade
        {
            get { return m_grade; }
            set { m_grade = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the <see cref="EnrolledCourseArgs"/> data into the <see cref="EnrolledCourse"/> object 
        /// </summary>
        /// <param name="args"></param>
        public EnrolledCourse(EnrolledCourseArgs args)
        {
            var cArgs = ObjectCache.CourseRootList.FirstOrDefault(c => c.CourseID == args.CourseID);
            if (cArgs == null)
                return;
            info = new Course(cArgs);
            courseID = args.CourseID;
            courseNumber = args.CourseNumber;
            semester = (SemesterType)args.Semester;
            year = args.Year;
            grade = (LetterGrade)args.Grade;

        }


        #endregion
    }

    #region Enumerations
    /// <summary>
    /// Represents the different types of semesters
    /// </summary>
    public enum SemesterType
    {
        /// <summary>
        /// represents fall semester
        /// </summary>
        [Display(Description ="Fall")]
        FALL,
        /// <summary>
        /// represents spring(winter) semester
        /// </summary>
        [Display(Description = "Spring")]
        SPRING,
        /// <summary>
        /// represents summer semester
        /// </summary>
        [Display(Description = "Summer")]
        SUMMER
    }

    /// <summary>
    /// Represents different grades that can be earned for a course
    /// </summary>
    public enum LetterGrade
    {
        /// <summary>
        /// represents letter grade A
        /// </summary>
        [Display(Description = "A")]
        A = 65,
        /// <summary>
        /// represents letter grade B
        /// </summary>
        [Display(Description = "B")]
        B = 66,
        /// <summary>
        /// represents letter grade C
        /// </summary>
        [Display(Description = "C")]
        C = 67,
        /// <summary>
        /// represents letter grade D
        /// </summary>
        [Display(Description = "D")]
        D = 68,
        /// <summary>
        /// represents letter grade F
        /// </summary>
        [Display(Description = "F")]
        F = 70,
        /// <summary>
        /// represents incomplete
        /// </summary>
        [Display(Description = "Incomplete")]
        I = 73,
        /// <summary>
        /// represents withdrown
        /// </summary>
        [Display(Description = "Withdraw")]
        W = 87
    }
    #endregion
}
