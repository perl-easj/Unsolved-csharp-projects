using System.Reflection;
using ExtensionsServices.Implementation;
using Images.Types;
using MVVMExample05.Models.App;

namespace MVVMExample05.Configuration.App
{
    public class AppConfig
    {
        public static void Setup()
        {
            SetupCatalogs();
            SetupAppImages("..\\..\\..\\Assets\\App\\");
        }

        private static void SetupCatalogs()
        {
            foreach (var prop in typeof(ObjectProvider).GetProperties())
            {
                prop.GetMethod.Invoke(null, null);
            }
        }

        private static void SetupAppImages(string prefix)
        {
            ServiceProvider.Images.SetAppImageSource(AppImageType.Load, prefix + "Load.png");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Save, prefix + "Save.png");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Quit, prefix + "Quit.png");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Login, prefix + "Login.png");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Image, prefix + "Image.png");
            ServiceProvider.Images.SetAppImageSource(AppImageType.NotFound, prefix + "NotSet.jpg.jpg");
            ServiceProvider.Images.SetAppImageSource(AppImageType.Logo, prefix + "Logo120x60.jpg");
        }
    }
}