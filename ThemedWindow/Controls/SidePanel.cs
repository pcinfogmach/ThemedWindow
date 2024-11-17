using System;
using System.Windows.Controls;
using System.Windows.Input;
using ThemedWindow.Helpers;

namespace ThemedWindow.Controls
{
    internal class SidePanel : TabControl
    {
        public ICommand ChangeViewCommand => new RelayObjectCommand(ChangeViewIndex);

        void ChangeViewIndex(object parameter)
        {
            if (parameter is int index)   SelectedIndex = index;
        }
    }
}
