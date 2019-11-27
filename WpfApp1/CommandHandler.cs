using System;
using System.Windows.Input;

namespace WpfApp1
{
    internal class CommandHandler : ICommand
    {
        private Func<object> p1;
        private Func<bool> p2;

        public CommandHandler(Func<object> p1, Func<bool> p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return p2.Invoke();
        }

        public void Execute(object parameter)
        {
            p1();
        }
    }
}