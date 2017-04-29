using System;
using System.Windows.Input;
using MVVMStarter.Models.Base;
using MVVMStarter.ViewModels.Base;

namespace MVVMStarter.Controllers.Base
{
    /// <summary>
    /// Base class for handlers. Most handlers will need access to
    /// view model and domain model, which is provided by this class.
    /// </summary>
    /// <typeparam name="TDomainClass"></typeparam>
    public abstract class ControllerBase<TDomainClass> : ICommand
        where TDomainClass : DomainClassBase, new()
    {
        protected MasterDetailsViewModelBase<TDomainClass> MasterDetailsViewModel;
        protected DomainModelBase<TDomainClass> DomainModel;

        protected ControllerBase(MasterDetailsViewModelBase<TDomainClass> masterDetailsViewModel,
                                 DomainModelBase<TDomainClass> domainModel)
        {
            MasterDetailsViewModel = masterDetailsViewModel;
            DomainModel = domainModel;
        }

        public abstract void Execute();

        public virtual bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
