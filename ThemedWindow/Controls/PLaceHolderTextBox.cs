using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace ThemedWindow.Controls
{
    public class PLaceHolderTextBox : Grid
    {
        public static readonly DependencyProperty TextProperty =
          DependencyProperty.Register(
              nameof(Text),
              typeof(string),
              typeof(PLaceHolderTextBox),
              new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty PlaceHolderTextProperty =
          DependencyProperty.Register(
              nameof(PlaceHolderText),
              typeof(string),
              typeof(PLaceHolderTextBox),
              new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string PlaceHolderText
        {
            get => (string)GetValue(PlaceHolderTextProperty);
            set => SetValue(PlaceHolderTextProperty, value);
        }

        public TextBox TextBox;
        public TextBlock PlaceHolderTextBlock;

        public PLaceHolderTextBox()
        {
            TextBox = new TextBox();
            TextBox.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text)) { Source = this, Mode = BindingMode.TwoWay });
            Children.Add(TextBox);

            PlaceHolderTextBlock = new TextBlock
            {
                IsHitTestVisible = false,
                Foreground = new SolidColorBrush(Colors.LightGray),
                Background = new SolidColorBrush(Colors.Transparent),
            };
            PlaceHolderTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(PlaceHolderText)) { Source = this, Mode = BindingMode.TwoWay });
            Children.Add(PlaceHolderTextBlock);

            TextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text)) PlaceHolderTextBlock.Visibility = Visibility.Visible;
            else PlaceHolderTextBlock.Visibility = Visibility.Collapsed;
        }
    }
}
