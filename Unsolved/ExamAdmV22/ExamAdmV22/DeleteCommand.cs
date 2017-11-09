using System;
using System.Windows.Input;

namespace ExamAdmV22
{
    public class DeleteCommand : ICommand
    {
        private StudentMasterDetailsViewModel _viewModel;

        public DeleteCommand(StudentMasterDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.StudentItemViewModelSelected != null;
        }

        public void Execute(object parameter)
        {
            _viewModel.Delete(_viewModel.StudentItemViewModelSelected.Name);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}