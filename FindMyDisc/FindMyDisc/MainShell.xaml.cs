using System;
using System.Collections.Generic;
using FindMyDisc.Views;
using Xamarin.Forms;

namespace FindMyDisc
{
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}
