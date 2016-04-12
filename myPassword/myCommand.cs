using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Input;

namespace myPassword
{
    public class myCommand : ICommand
    {
        #region Declarations
        readonly Func<Boolean> _canExecute;
        readonly Action<object> _execute;
        #endregion

        #region Constructors

        public myCommand(Action<Object> execute)
            : this(execute, null)
        { }

        public myCommand(Action<Object> execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Icommand Members
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }

        }

        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public void Execute(Object parameter)
        {            
            _execute(parameter);
        }
        #endregion
    }
}
