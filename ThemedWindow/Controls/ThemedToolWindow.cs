using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThemedWindow.Controls
{
    public partial class ThemedToolWindow : TWindow
    {
        public ThemedToolWindow() 
        {
            this.Owner = Application.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Style = (Style)Application.Current.Resources["ThemedToolWindowStyle"];
        }
    }
}
