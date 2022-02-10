using MEC3AppSample.Views;
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
    public partial class SeminarListPage : ContentPage
    {
        public SeminarListPage()
        {
            InitializeComponent();
        }
        async void returnHome(object sender, EventArgs e)
        {


            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation .PushAsync(landingPage, true);






        }

        protected override bool OnBackButtonPressed()
        {
            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            navigation.PushAsync(landingPage, true);

            return true;
        }
    }
}