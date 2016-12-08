using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudSearchUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            lbStudents.Items.Clear(); //Clear our student list box every time the search button is clicked.
            lbCourses.Items.Clear();  //Clears courses list box upon making a new search

            List<Student> students = Students.SearchStudentsGeneral(tbSearch.Text);
            foreach (Student student in students)
            {
                string fullName = student.lastName + ", " + student.firstName + " ID: " + student.id;
                lbStudents.Items.Add(fullName);
            }

            if (students.Count == 0)
            {
                lbStudents.Items.Add("***No Students Records Found***");
            }

            ClearAllLabels();

        }

        private void lbStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearAllLabels();
            string selection;

            //Workaround for a crash that occured when the ctrl key was being held while selecting a student.
            try
            {
                selection = lbStudents.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                lbCourses.Items.Clear();
                return;
            }

            string[] substrings = selection.Split(' ');
            string ID = substrings[3];
            Student student = Student.GetStudentById(ID);
            if (student == null)
            {
                return;
            }

            lblFname.Text = student.firstName;
            lblLname.Text = student.lastName;
            lblID.Text = student.id;

            lbCourses.Items.Clear(); //Clear the course list box each time a student is selected


            List<EnrolledCourse> courses = student.courses;
            ComputeCompletion(courses); //Computes and sets completion % for each course type

            foreach (EnrolledCourse course in courses)
            {
                Course c = new Course(ObjectCache.CourseRootList.FirstOrDefault(cs => cs.CourseID == course.courseID));
                lbCourses.Items.Add(c.name);
            }
        }

        private void lbCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection;

            //Workaround for a crash that occured when the ctrl key was being held while selecting a course.
            try
            {
                selection = lbCourses.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                return;
            }

            string studentID = lblID.Text.ToString();
            Student student = Student.GetStudentById(studentID);
            List<EnrolledCourse> courses = student.courses;
            var courseInfo = from c in courses
                             where c.info.name == selection
                             select c;
            foreach (EnrolledCourse course in courseInfo)
            {
                lblCourseId.Text = course.courseID.ToString();
                lblCourseNam.Text = course.info.name;
                lblCourseNum.Text = course.info.number;
                lblCourseCred.Text = course.info.credits;
                lblSemster.Text = course.semester.ToString();
                lblYear.Text = course.year.ToString();
                lblCourseType.Text = course.info.courseType;
                lblCourseGrade.Text = course.grade.ToString();

            }

        }

        public void ComputeCompletion(List<EnrolledCourse> courses)
        {
            double coreCompletion = 0;
            double electiveCompletion = 0;
            double genEdCompletion = 0;
            double totCompletion = 0;

            var electives = from course in courses
                            where course.info.courseType == "Elective"
                            select course;
            foreach (EnrolledCourse course in electives)
            {
                switch (course.grade)
                {
                    case LetterGrade.A:
                        electiveCompletion++;
                        break;
                    case LetterGrade.B:
                        electiveCompletion++;
                        break;
                    case LetterGrade.C:
                        electiveCompletion++;
                        break;
                    default:
                        break;
                }
            }

            var core = from course in courses
                       where course.info.courseType == "Core"
                       select course;

            foreach (EnrolledCourse course in core)
            {
                switch (course.grade)
                {
                    case LetterGrade.A:
                        coreCompletion++;
                        break;
                    case LetterGrade.B:
                        coreCompletion++;
                        break;
                    case LetterGrade.C:
                        coreCompletion++;
                        break;
                    default:
                        break;
                }
            }

            var genEd = from course in courses
                        where course.info.courseType == "General"
                        select course;

            foreach (EnrolledCourse course in genEd)
            {
                switch (course.grade)
                {
                    case LetterGrade.A:
                        genEdCompletion++;
                        break;
                    case LetterGrade.B:
                        genEdCompletion++;
                        break;
                    case LetterGrade.C:
                        genEdCompletion++;
                        break;
                    default:
                        break;
                }
            }

            totCompletion = electiveCompletion + coreCompletion + genEdCompletion;

            // Calcuates and rounds the % completion of each type to the nearest hundreth and sets it to the label
            lblElective.Text = Math.Round(((electiveCompletion / 8) * 100), 2).ToString();
            lblCore.Text = Math.Round(((coreCompletion / 26) * 100), 2).ToString();
            lblGenEd.Text = Math.Round(((genEdCompletion / 8) * 100), 2).ToString();

            lblCompleted.Text = Math.Round(((totCompletion / 42) * 100), 2).ToString();

        }

        public void ClearAllLabels()
        {
            lblCompleted.Text = "";
            lblCore.Text = "";
            lblCourseCred.Text = "";
            lblCourseGrade.Text = "";
            lblCourseId.Text = "";
            lblCourseNam.Text = "";
            lblCourseNum.Text = "";
            lblCourseType.Text = "";
            lblElective.Text = "";
            lblFname.Text = "";
            lblGenEd.Text = "";
            lblID.Text = "";
            lblLname.Text = "";
            lblSemster.Text = "";
            lblYear.Text = "";
        }


    }
}
