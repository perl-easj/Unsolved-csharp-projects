using System;
using System.Windows.Input;

namespace MVVMStarter.Common
{
    /// <summary>
    /// This class is the "standard" implementation of RelayCommand,
    /// qwhich originates from an open-source MVVM project.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Use if command is always executable
        /// </summary>
        /// <param name="execute">
        /// Action to execute
        /// </param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Use if command may not always be executable
        /// </summary>
        /// <param name="execute">
        /// Action to execute
        /// </param>
        /// <param name="canExecute">
        /// Function should return true when command is executable
        /// </param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Returns true if command is executable
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return ((_canExecute == null) || _canExecute());
        }

        /// <summary>
        /// Execute the command specified when object was created
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Call this method if the object should re-evaluate
        /// if the command can be executed
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
