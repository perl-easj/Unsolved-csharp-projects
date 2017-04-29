using System.Collections.Generic;
using MVVMStarter.ViewModels.App;
using MVVMStarter.ViewModels.Base;
using _REPLACEME_Class = MVVMStarter.Models.Domain._REPLACEME_._REPLACEME_;

/// <summary>
/// TEMPLATE: You must 
/// 1) Create a file called MasterDetailsViewModel.cs in your domain folder (under ViewModel/Domain)
/// 2) Delete the entire content of the file
/// 3) Copy-paste the entire content of this template into the file
/// 4) replace the text _REPLACEME_ with the name of your domain
/// 5) Delete this comment
namespace MVVMStarter.ViewModels.Domain._REPLACEME_
{
    public class MasterDetailsViewModel : MasterDetailsViewModelBase<_REPLACEME_Class>
    {
        public MasterDetailsViewModel()
            : base(new ViewModelFactory(), Models.Domain._REPLACEME_.DomainModel.Instance)
        {
            //// Use the below code as a template for setting up default
            //// behavior for your GUI controls

            //List<string> fixedProperties = new List<string>();
            //// Add names of "fixed" (cannot be changed after creation) properties here
            //fixedProperties.Add(nameof(_REPLACEME_Class.FixedPropertyA));
            //fixedProperties.Add(nameof(_REPLACEME_Class.FixedPropertyB));
            //fixedProperties.Add(nameof(_REPLACEME_Class.FixedPropertyC));

            //List<string> nonFixedKeyProperties = new List<string>();
            //// Add names of "non-fixed" (can be changed after creation) properties here
            //nonFixedKeyProperties.Add(nameof(_REPLACEME_Class.NonFixedPropertyA));
            //nonFixedKeyProperties.Add(nameof(_REPLACEME_Class.NonFixedPropertyB));

            //StateManager.AddFixedPropertiesDefaultStates(fixedProperties);
            //StateManager.AddNonFixedPropertiesDefaultStates(nonFixedKeyProperties);
            //StateManager.AddButtonDefaultStates();
        }
    }
}
