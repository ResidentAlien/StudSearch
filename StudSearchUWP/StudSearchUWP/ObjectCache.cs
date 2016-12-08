using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudSearchUWP
{
    public class ObjectCache
    {
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="CourseArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<CourseArgs> CourseRootList { get { return JsonConvert.DeserializeObject<List<CourseArgs>>(File.ReadAllText("Courses.json")); } }
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="StudentArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<StudentArgs> StudentRootList { get { return JsonConvert.DeserializeObject<List<StudentArgs>>(File.ReadAllText("Students.json")); } }
    }
}
