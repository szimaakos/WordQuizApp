﻿using System.Configuration;
using System.Data;
using System.Windows;
using WordQuizApp.Data;

namespace WordQuizApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatabaseInitializer.Initialize();
        }
    }

}
