using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Foundation;
using Microsoft.Toolkit.Uwp.Notifications;

namespace StudSearchUWP
{
    public class ObjectCache
    {
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="CourseArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<CourseArgs> CourseRootList
        {
            get
            {
                return JsonConvert.DeserializeObject<List<CourseArgs>>(new StreamReader(File.OpenRead("Courses.json")).ReadToEnd());
            }
        }
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="StudentArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<StudentArgs> StudentRootList
        {
            get
            {
                //var file = GetFileFromApplication("Students.json");
                //return JsonConvert.DeserializeObject<List<StudentArgs>>(File.ReadAllText("Assets/Students.json"));
                return JsonConvert.DeserializeObject<List<StudentArgs>>(new StreamReader(File.OpenRead("Students.json")).ReadToEnd());
            }
        }
    }

    public class ToastNotification
    {
        public static void CreateToast()
        {
            ToastContent content = new ToastContent()
            {
                Launch = "app-defined-string",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children = {
                            new AdaptiveText()
                            {
                                Text = "Sample"
                            },
                            new AdaptiveText()
                            {
                                Text = "This is a simple toast notification example"
                            }
                        },
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = "oneAlarm.png"
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons = {
                        new ToastButton("check", "check")
                        {
                            ImageUri = "check.png"
                        },
                        new ToastButton("cancel", "cancel")
                        {
                            ImageUri = "cancel.png"
                        }
                    }
                },
                Audio = new ToastAudio()
                {
                    Src = new Uri("ms-winsoundevent:Notification.Reminder")
                }
            };
        }
    }
}
