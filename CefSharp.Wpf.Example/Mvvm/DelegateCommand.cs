﻿using System;
using System.Windows.Input;

namespace CefSharp.Wpf.Example.Mvvm
{
    public class DelegateCommand : ICommand
    {
        private readonly Action commandHandler;
        private readonly Func<bool> canExecuteHandler;

        public DelegateCommand(Action commandHandler, Func<bool> canExecuteHandler = null)
        {
            this.commandHandler = commandHandler;
            this.canExecuteHandler = canExecuteHandler;
        }

        public void Execute(object parameter)
        {
            commandHandler();
        }

        public bool CanExecute(object parameter)
        {
            return
                canExecuteHandler == null ||
                canExecuteHandler();
        }

        public event EventHandler CanExecuteChanged;

        protected void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
