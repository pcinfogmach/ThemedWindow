﻿using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ThemedWindow.Helpers;

namespace ThemedWindow.Controls
{
    public partial class TWindow : Window
    {
        private SolidColorBrush _themedBackGround, _themedForeGround;

        public SolidColorBrush ThemedBackGround
        {
            get => _themedBackGround;
            set { if (_themedBackGround != value) { _themedBackGround = value; OnPropertyChanged(nameof(ThemedBackGround)); } }
        }

        public SolidColorBrush ThemedForeGround
        {
            get => _themedForeGround;
            set { if (_themedForeGround != value) { _themedForeGround = value; OnPropertyChanged(nameof(ThemedForeGround)); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ICommand _minimizeCommand;
        private ICommand _maximizeRestoreCommand;
        private ICommand _closeCommand;
        public ICommand MinimizeCommand => _minimizeCommand ??= new RelayCommand(Minimize);
        public ICommand MaximizeRestoreCommand => _maximizeRestoreCommand ??= new RelayCommand(MaximizeRestore);
        public ICommand CloseCommand => _closeCommand ??= new RelayCommand(Close);

        private void Minimize() => this.WindowState = WindowState.Minimized;
        private void MaximizeRestore() => this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;


        public TWindow()
        {
            bool isDarkTheme = IsDarkThemeEnabled();
            ThemedBackGround = isDarkTheme ? new SolidColorBrush(Color.FromRgb(34, 34, 34)) : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF9F9FA"));
            ThemedForeGround = new SolidColorBrush(isDarkTheme ? Color.FromRgb(200, 200, 200) : Colors.DarkSlateGray);
            this.FlowDirection = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "he" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            
            try { if (this.Icon == null) this.Icon = ConvertIconToImageSource(); }catch (Exception ex) { }

            this.Style = (Style)Application.Current.Resources["ThemedWindowStyle"];
        }

        ImageSource ConvertIconToImageSource()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(exePath);
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }

        bool IsDarkThemeEnabled()
        {
            const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            const string registryValueName = "AppsUseLightTheme";

            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryKeyPath))
            {
                if (key?.GetValue(registryValueName) is int value)
                {
                    return value == 0; // 0 means Dark Theme is enabled, 1 means Light Theme
                }
            }
            return false; // Default to light theme if the registry value is not found
        }


    }
}
