using Microsoft.Xaml.Behaviors;
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
    public class ComboBoxSelectionChangedBehavior:Behavior<ComboBox>
    {

        public static readonly DependencyProperty CommandProperty =
       DependencyProperty.Register("Command", typeof(ICommand), typeof(ComboBoxSelectionChangedBehavior), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Command != null && Command.CanExecute(AssociatedObject.SelectedItem))
            {
                Command.Execute(AssociatedObject.SelectedItem);
            }
        }
    }
}
