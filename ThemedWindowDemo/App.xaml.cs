﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace ThemedWindowDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new ThemedWindow.ThemedWindow().Show();
        }
    }

}