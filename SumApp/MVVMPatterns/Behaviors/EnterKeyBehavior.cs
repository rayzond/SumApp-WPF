using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace SumApp.MVVMPatterns.Behaviors
{
    public class EnterKeyBehavior : Behavior<TextBox>
    {
        #region Members

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(EnterKeyBehavior),
                new PropertyMetadata(null));

        #endregion

        #region Properties

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion

        #region Overrides

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += onKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.KeyDown -= onKeyDown;
        }

        #endregion

        #region Private Methods

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Command?.CanExecute(null) == true)
            {
                Command.Execute(null);
                e.Handled = true;
            }
        }

        #endregion
    }
}
