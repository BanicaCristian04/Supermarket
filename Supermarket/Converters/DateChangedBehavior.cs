using Microsoft.Xaml.Behaviors;
using Supermarket.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Supermarket.Converters
{
    public class DateChangedBehavior : Behavior<DatePicker>
    {

        public static readonly DependencyProperty CommandProperty =
       DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(DateChangedBehavior), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedDateChanged += OnSelectedDateChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectedDateChanged -= OnSelectedDateChanged;
        }

        private void OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = AssociatedObject.Tag as ComboBox;
            var selectedCashier = comboBox?.SelectedItem as User;
            var parameter = new UserDate
            {
                Cashier = selectedCashier,
                Date = AssociatedObject.SelectedDate
            };
            if (Command != null && Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
