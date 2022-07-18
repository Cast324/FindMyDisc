using System;
using System.Collections.Generic;
using FindMyDisc.ViewModels;
using Xamarin.Forms;

namespace FindMyDisc.Views
{
    public partial class HomePage : ContentPage
    {

        private HomeViewModel mViewModel { get; set; }


        public HomePage()
        {
            InitializeComponent();
            BindingContext = mViewModel = new HomeViewModel();
        }
    }
}

