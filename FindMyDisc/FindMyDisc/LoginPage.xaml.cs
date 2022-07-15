using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMyDisc.ViewModels;
using Xamarin.Forms;

namespace FindMyDisc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}

