using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class DelegateCommand : ICommand
    {
        /// <summary>
        ///     The _execute
        /// </summary>
        private readonly Action execute;

        /// <summary>
        ///     The _can execute
        /// </summary>
        private readonly Func<bool> canExecute;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <exception cref="ArgumentNullException">execute</exception>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");

            if (canExecute != null)
            {
                this.canExecute = canExecute;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the DelegateCommand class that
        ///     can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <exception cref="ArgumentNullException">If the execute argument is null.</exception>
        public DelegateCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        ///     Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute.Invoke();
        }

        /// <summary>
        ///     Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to null.
        /// </param>
        public virtual void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
            {
                this.execute.Invoke();
            }
        }
    }

    /// <summary>
    ///     This class allows delegating the commanding logic to methods passed as parameters,
    ///     and enables a View to bind commands to objects that are not part of the element tree.
    /// </summary>
    /// <typeparam name="T">Type of the parameter passed to the delegates</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /// <summary>
        ///     The execute
        /// </summary>
        private readonly Action<T> execute;

        /// <summary>
        ///     The can execute
        /// </summary>
        private readonly Predicate<T> canExecute;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute action.</param>
        /// <exception cref="ArgumentNullException">execute</exception>
        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand{T}" /> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute predicate.</param>
        /// <exception cref="ArgumentNullException">execute</exception>
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");

            if (canExecute != null)
            {
                this.canExecute = canExecute;
            }
        }

        /// <summary>
        ///     Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        ///     Raise <see cref="DelegateCommand{T}.CanExecuteChanged" /> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns><c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute.Invoke((T)parameter);
        }

        /// <summary>
        ///     Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public virtual void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
            {
                this.execute((T)parameter);
            }
        }
    }
}
