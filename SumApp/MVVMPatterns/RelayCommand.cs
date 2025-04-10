using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumApp.MVVMPatterns
{
    public class RelayCommand : ICommand
    {
        #region Members

        private readonly Action _func;
        private readonly Func<bool> _canExecute;

        #endregion

        #region Constructors

        /// <param name="func">Action to run when executing this relay command.</param>
        /// <param name="canExecute">Function to check if this relay command can be executed.</param>
        public RelayCommand(Action func, Func<bool> canExecute = null)
        {
            _func = func;
            _canExecute = canExecute;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check and returns if the relay command can be executed.
        /// </summary>
        /// <param name="parameter">parameter object for the relay command</param>
        /// <returns>True if this relay command can be executed, False otherwise.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Executes the relay command function with the provided parameter.
        /// </summary>
        /// <param name="parameter">parameter object for the relay command</param>
        public void Execute(object parameter) => _func();

        #endregion
    }
}
