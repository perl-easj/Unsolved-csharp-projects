using MVVMExample05.DataTransformation.Domain.Studio;
using ViewModel.Implementation;

namespace MVVMExample05.ViewModels.Domain.Studio
{
    public class DetailsViewModel : DetailsViewModelBase<StudioViewModel>
    {
        public string Name
        {
            get { return DataObject.Name; }
            set
            {
                DataObject.Name = value;
                OnPropertyChanged();
            }
        }

        public string HQCity
        {
            get { return DataObject.HQCity; }
            set
            {
                DataObject.HQCity = value;
                OnPropertyChanged();
            }
        }

        public string NoOfEmployees
        {
            get { return DataObject.NoOfEmployees; }
            set
            {
                DataObject.NoOfEmployees = value;
                OnPropertyChanged();
            }
        }


        public DetailsViewModel(StudioViewModel obj) : base(obj)
        {
        }
    }
}