using System;
using System.Windows.Input;
using ExamAdmV22.Model;

namespace ExamAdmV22.ViewModel
{
    public class DeleteCommand : ICommand
    {
        private StudentCatalog _catalog;
        private StudentMasterDetailsViewModel _viewModel;

        public DeleteCommand(StudentCatalog catalog, StudentMasterDetailsViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.StudentItemViewModelSelected != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.StudentItemViewModelSelected.DomainObject.Key);

            // Set selection to null
            _viewModel.StudentItemViewModelSelected = null;

            // Refresh the item list
            _viewModel.RefreshStudentItemViewModelCollection();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}