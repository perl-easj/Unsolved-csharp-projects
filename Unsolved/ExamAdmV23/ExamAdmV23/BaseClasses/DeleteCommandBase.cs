using System;
using System.Windows.Input;

namespace ExamAdmV23.BaseClasses
{
    public class DeleteCommandBase<TDomainClass, TViewModel, TKey> : ICommand
        where TViewModel : MasterDetailsViewModelBase<TDomainClass, TKey> 
        where TDomainClass : DomainClassBase<TKey>
    {
        private TViewModel _viewModel;

        public DeleteCommandBase(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.ItemViewModelSelected != null;
        }

        public void Execute(object parameter)
        {
            _viewModel.Delete(_viewModel.ItemViewModelSelected.DomainObject.Key);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}