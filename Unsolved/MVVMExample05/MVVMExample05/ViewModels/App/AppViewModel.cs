using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExtensionsServices.Implementation;
using Images.Types;

namespace MVVMExample05.ViewModels.App
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public string LoadImageSource
        {
            get { return ServiceProvider.Images.GetAppImageSource(AppImageType.Load); }
        }

        public string SaveImageSource
        {
            get { return ServiceProvider.Images.GetAppImageSource(AppImageType.Save); }
        }

        public string QuitImageSource
        {
            get { return ServiceProvider.Images.GetAppImageSource(AppImageType.Quit); }
        }

        public string LogoImageSource
        {
            get { return ServiceProvider.Images.GetAppImageSource(AppImageType.Logo); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}