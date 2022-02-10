using MEC3App.ViewModel;
using MEC3AppSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MEC3App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPageLocked : ContentPage
    {
        public DetailsPageLocked()
        {
            InitializeComponent();
            
        }

        protected override bool OnBackButtonPressed()
        {
            if (App.pageMonitor == 100)
            {

                var newViewModel = new CategoryViewModel(100, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 200)
            {

                var newViewModel = new CategoryViewModel(200, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 400)
            {

                var newViewModel = new CategoryViewModel(400, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 600)
            {

                var newViewModel = new CategoryViewModel(600, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 700)
            {

                var newViewModel = new CategoryViewModel(700, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            if (App.pageMonitor == 800)
            {

                var newViewModel = new CategoryViewModel(800, true) { };
                var newPage = new CategoryPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);

            }

            return true;
        }
    }
}