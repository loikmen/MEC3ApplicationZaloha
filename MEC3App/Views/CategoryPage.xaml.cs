using MEC3App.Model;
using MEC3AppSample.Interfaces;
using MEC3AppSample.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MEC3App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        private readonly IFilesService filesService;

        public CategoryPage()
        {
            InitializeComponent();
 
            filesService = DependencyService.Get<IFilesService>();
        }
        async void returnHome(object sender, EventArgs e)
        {


            var landingPage = new LandingPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(landingPage, true);

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