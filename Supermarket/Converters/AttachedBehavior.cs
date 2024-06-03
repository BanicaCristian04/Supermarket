using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Supermarket.Converters
{
    public static class AttachedBehavior
    {
        public static readonly DependencyProperty SellingPriceTextBoxProperty =
            DependencyProperty.RegisterAttached(
                "SellingPriceTextBox", typeof(TextBox), typeof(AttachedBehavior),
                new PropertyMetadata(null, OnSellingPriceTextBoxChanged));

        public static TextBox GetSellingPriceTextBox(DependencyObject obj)
        {
            return (TextBox)obj.GetValue(SellingPriceTextBoxProperty);
        }

        public static void SetSellingPriceTextBox(DependencyObject obj, TextBox value)
        {
            obj.SetValue(SellingPriceTextBoxProperty, value);
        }

        private static void OnSellingPriceTextBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if (e.OldValue != null)
                {
                    textBox.TextChanged -= PurchasePriceTextBox_TextChanged;
                }

                if (e.NewValue != null)
                {
                    textBox.TextChanged += PurchasePriceTextBox_TextChanged;
                }
            }
        }

        private static void PurchasePriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox purchasePriceTextBox)
            {
                if (double.TryParse(purchasePriceTextBox.Text, out double purchasePrice))
                {
                    double marginPercentage = 0.2; // Margine de profit de 20%
                    double sellingPrice = purchasePrice * (1 + marginPercentage);

                    var sellingPriceTextBox = GetSellingPriceTextBox(purchasePriceTextBox);
                    if (sellingPriceTextBox != null)
                    {
                        sellingPriceTextBox.Text = sellingPrice.ToString("F2");
                    }
                }
            }
        }
    }
}