using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Extensions.AddOns.Implementation;
using MVVMEx05.ViewModels.App;
using MVVMEx05.Views.App;

namespace MVVMEx05.Configuration.App
{
    /// <summary>
    /// Manages initial setup for the application.
    /// </summary>
    public class AppConfig
    {
        public static void Setup(Page mainPage, Frame appFrame)
        {
            SetupAppImages("..\\..\\..\\Assets\\App\\");
            SetupDomainImages("..\\..\\..\\Assets\\Domain\\");

            // Navigate to File view, which is the initial view
            appFrame.Navigate(typeof(FileView));
            ((AppViewModel)mainPage.DataContext).SetAppFrame(appFrame);
        }

        private static void SetupAppImages(string prefix)
        {
            ServiceProvider.Images.SetAppImageSource(AppImageType.NotFound, prefix + "NotSet.jpg");
        }

        private static void SetupDomainImages(string prefix)
        {
            List<IImage> imageList = new List<IImage>();

            #region Movie image objects
            TaggedImage m1 = new TaggedImage("Alien", prefix + "Alien.jpg");
            m1.AddTag("Movie");
            m1.AddTag("Alien");

            TaggedImage m2 = new TaggedImage("Terminator", prefix + "Terminator.jpg");
            m2.AddTag("Movie");
            m2.AddTag("Terminator");

            TaggedImage m3 = new TaggedImage("Inception", prefix + "Inception.jpg");
            m3.AddTag("Movie");
            m3.AddTag("Inception");

            TaggedImage m4 = new TaggedImage("Seven", prefix + "Seven.jpg");
            m4.AddTag("Movie");
            m4.AddTag("Seven");

            TaggedImage m5 = new TaggedImage("Arrival", prefix + "Arrival.jpg");
            m5.AddTag("Movie");
            m5.AddTag("Arrival");

            imageList.Add(m1);
            imageList.Add(m2);
            imageList.Add(m3);
            imageList.Add(m4);
            imageList.Add(m5);
            #endregion

            #region Studio image objects
            TaggedImage s1 = new TaggedImage("Paramount", prefix + "Paramount.jpg");
            s1.AddTag("Studio");
            s1.AddTag("Paramount");

            TaggedImage s2 = new TaggedImage("Fox", prefix + "Fox.jpg");
            s2.AddTag("Studio");
            s2.AddTag("Fox");

            TaggedImage s3 = new TaggedImage("New Line Cinema", prefix + "NewLineCinema.jpg");
            s3.AddTag("Studio");
            s3.AddTag("New Line Cinema");

            imageList.Add(s1);
            imageList.Add(s2);
            imageList.Add(s3);
            #endregion

            ServiceProvider.Images.SetImages(imageList);
        }
    }
}