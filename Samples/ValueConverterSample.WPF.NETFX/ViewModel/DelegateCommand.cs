using System;
using System.Windows.Input;

namespace ValueConverterSample.WPF.ViewModel
{
    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action execute)
            : this(execute, () => true)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute) 
            : base((o) => execute(), canExecute)
        {
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action<T> execute)
            : this(execute, () => true)
        {
            this.execute = execute;
        }

        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            var param = default(T);
            if (parameter is T t)
            {
                param = t;
            }

            this.execute(param);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}