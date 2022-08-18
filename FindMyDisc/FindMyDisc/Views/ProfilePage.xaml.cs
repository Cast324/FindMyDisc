using System;
using System.Collections.Generic;
using FindMyDisc.ViewModels;
using Xamarin.Forms;

namespace FindMyDisc.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }
    }
}
