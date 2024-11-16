using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThemedWindow.Controls;

namespace ThemedWindowDemo
{
    /// <summary>
    /// Interaction logic for ThemedWindowSample.xaml
    /// </summary>
    public partial class ThemedWindowSample : TWindow
    {

        public ThemedWindowSample()
        {
            InitializeComponent();
            textBox.Text = @"o populate a TextBlock in a C# WPF application, you can set the Text property of the TextBlock control. Here’s a simple example of how to do this:
XAML:

<Window x:Class=""WpfApp.MainWindow""
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        Title=""TextBlock Example"" Height=""200"" Width=""300"">
    <Grid>
        <TextBlock Name=""myTextBlock"" HorizontalAlignment=""Center"" VerticalAlignment=""Center"" FontSize=""16""/>
    </Grid>
</Window>

C# (Code-Behind):

using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateTextBlock();
        }

        private void PopulateTextBlock()
        {
            myTextBlock.Text = ""Hello, WPF!"";
        }
    }
}

In this example:

    The TextBlock is defined in the XAML with the name myTextBlock.
    In the code-behind, the PopulateTextBlock() method sets the Text property to ""Hello, WPF!"". This populates the TextBlock with the desired text when the window is loaded.

You can dynamically populate the TextBlock based on your application logic by updating the Text property at any time.";
        }
    }
}
