using MEC3App.Model;
using MEC3App.Views;
using MEC3AppSample;
using MEC3AppSample.Model;
using MEC3AppSample.ViewModel;
using MEC3AppSample.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MEC3App.ViewModel
{
    class CategoryViewModel : BaseViewModel
    {

        private Page1 page1 = new Page1();

        public CategoryViewModel(int index, Boolean intConnection)
        {
            if (intConnection == true) { 

            categoryCards = GetCategoryList(index);
            name = GetCategoryName(index);
            AddCategoryItemToDB();

            } else
            {
                
                categoryCards = retypeAsync(index);
                name = "Offline";


            }

        }

        public CategoryViewModel()
        {

        }


        String name;

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }

        }

        ObservableCollection<CategoryDto> categoryCards;
        public ObservableCollection<CategoryDto> CategoryCards
        {
            get { return categoryCards; }
            set
            {
                categoryCards = value;
                OnPropertyChanged();
            }
        }


        private CategoryDto selectedCard;
        public CategoryDto SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged();
            }
        }

        private int position;
        public int Position
        {
            get
            {
                if (position != categoryCards.IndexOf(selectedCard))
                    return categoryCards.IndexOf(selectedCard);

                return position;
            }
            set
            {
                position = value;
                selectedCard = categoryCards[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedCard));
            }
        }

        private Command selectionCommand;

        public ICommand SelectionCommand
        {
            get
            {
                if (selectionCommand == null)
                {
                    selectionCommand = new Command(DisplayCategoryDetail);
                }

                return selectionCommand;
            }
        }

        private void DisplayCategoryDetail()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {



                if (App.isLogged)

                {
                    var newViewModel = new DetailsViewModel(selectedCard.BaseIndex, true) { };
                    var newPage = new DetailsPage { BindingContext = newViewModel };
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(newPage, true);

                    Console.WriteLine("jsi prihlasen");


                } else
                {
                    var newViewModel = new DetailsViewModel(selectedCard.BaseIndex, true) { };
                    var newPage = new DetailsPageLocked{BindingContext = newViewModel};
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(newPage, true);

                    Console.WriteLine("nejsi prihlasen");

                }



            } else
            {
                Console.WriteLine("Nejsi připojen k internetu");

                var newViewModel = new DetailsViewModel(selectedCard.BaseIndex, false) { };
                var newPage = new DetailsPage { BindingContext = newViewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(newPage, true);
            }
   
        }

        public CategoryApiModel.Rootobject GetCategoryApiModel(int id)
        {

            var CategoryApiModel = new CategoryApiModel.Rootobject();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var requestObj = (HttpWebRequest)WebRequest.Create("https://mec3.cz/mec3mobile/ProductMobile/GetCategory/" + id); ;
            requestObj.Method = "Get";

            var responseObj = (HttpWebResponse)requestObj.GetResponse();
            if (responseObj.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    CategoryApiModel = JsonConvert.DeserializeObject<CategoryApiModel.Rootobject>(sr.ReadToEnd());
                    sr.Close();
                }
            }
            return CategoryApiModel;

        }

        public ObservableCollection<CategoryDto> GetCategoryList(int index)
        {
            var CategoryDto = new ObservableCollection<CategoryDto>();
            var model = GetCategoryApiModel(index);

            foreach (var result in model.Data.SubCategories)
            {
                var name = result.Name;
                var image = result.Image;
                var id = result.ID; ;

                CategoryDto.Add(new CategoryDto(name, image, id));
            }

            return CategoryDto;
        }

        public String GetCategoryName(int index)
        {

            var model = GetCategoryApiModel(index);
            var name = model.Data.Name;    

            return name;
        }


        async void AddCategoryItemToDB()
        {

            // Nejdříve vymazání kategorií z databáze 
            
            var list = App.Database.GetCategoriesAsync();

            foreach (var item in list.Result)
            {
                await App.Database.DeleteCategoryItemAsync(item);

            }
            


            var categoryList = new ObservableCollection<CategoryDto>();

            for (int i = 100; i <= 700; i = i + 100)
            {
                if(i == 300 || i == 500)
                {

                } else
                {
                    categoryList.Clear();
                    categoryList = GetCategoryList(i);

                    foreach (var item in categoryList)
                    {
                        
                            await App.Database.SaveCategoryItemAsync(new CategoryDto
                            {

                                Name = item.Name,
                                Image = item.Image,
                                BaseIndex = item.BaseIndex

                            });                      
                    }
                }
            }                 
        }

         private ObservableCollection<CategoryDto> retypeAsync(int index)
        {
            var list = App.Database.GetCategoriesAsync();
            var ocList = new ObservableCollection<CategoryDto>();

            
                foreach (var item in list.Result)
                {
                    if (item.BaseIndex >= index && item.BaseIndex < index+100)
                {
                    ocList.Add(item);
                }
                    
                }

                return ocList;
            
        }

    }
}

