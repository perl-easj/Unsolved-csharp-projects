using MVVMStarter.Validators.App;
using MVVMStarter.ViewModels.Base;
using _REPLACEME_Class = MVVMStarter.Models.Domain._REPLACEME_._REPLACEME_;

/// <summary>
/// TEMPLATE: You must 
/// 1) Create a file called DetailsViewModel.cs in your domain folder (under ViewModel/Domain)
/// 2) Delete the entire content of the file
/// 3) Copy-paste the entire content of this template into the file
/// 4) replace the text _REPLACEME_ with the name of your domain
/// 5) Delete this comment
/// </summary>
namespace MVVMStarter.ViewModels.Domain._REPLACEME_
{
    public class DetailsViewModel : DetailsViewModelBase<_REPLACEME_Class>
    {
        //// Template for validated property (may throw ValidationException) 
        //public string MyValidatedProperty
        //{
        //    get { return DomainObject.MyValidatedProperty; }
        //    set
        //    {
        //        var orgValue = DomainObject.MyValidatedProperty;
        //        try
        //        {
        //            DomainObject.MyValidatedProperty = value;
        //        }
        //        catch (ValidationException e)
        //        {
        //            PresentValidationError(e.Message, () => { MyValidatedProperty = orgValue; });
        //        }
        //        OnPropertyChanged();
        //    }
        //}

        //// Template for non-validated property
        //public string MyNonValidatedProperty
        //{
        //    get { return DomainObject.MyNonValidatedProperty; }
        //    set
        //    {
        //        DomainObject.MyNonValidatedProperty = value;
        //        OnPropertyChanged();
        //    }
        //}

        public DetailsViewModel(_REPLACEME_Class obj) : base(obj)
        {
        }
    }
}
