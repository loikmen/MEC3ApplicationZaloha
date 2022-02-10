using MEC3AppSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MEC3AppSample;
using MEC3App.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Net.Http;
using Plugin.XamarinFormsSaveOpenPDFPackage;

namespace MEC3AppSample.ViewModel
{
    public class DetailsViewModel : BaseViewModel
    {

        public ICommand ViewPdf { get; set; }

        public DetailsViewModel(int index, Boolean intConnection)
        {
            if(intConnection == true)
            {
                detailCard = GetDetailList(index);
              //  AddDetailItemToDB(index);

            } else
            {
            //    detailCard = RetypeAsync();
            }

            ViewPdf = new Command(async (arg) =>
            {
                try
                {
                    var httpClient = new HttpClient();
                    var stream = await httpClient.GetStreamAsync(arg.ToString());            

                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);

                        await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("File.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
                    }

                } catch 
                {

                }
                
            });

        }

        public DetailsViewModel()
        {

        }

        private DetailDto detailCard;
        public DetailDto DetailCard
        {
            get { return detailCard; }
            set
            {
                detailCard = value;
                OnPropertyChanged();
            }
        }

  
        /*

                private ObservableCollection<DetailDto> detailCards;
                public ObservableCollection<DetailDto> DetailCards
                {
                    get { return detailCards; }
                    set
                    {
                        detailCards = value;
                        OnPropertyChanged();
                    }
                }

                private DetailDto selectedCard;
                public DetailDto SelectedCard
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
                        if (position != detailCards.IndexOf(selectedCard))
                            return detailCards.IndexOf(selectedCard);

                        return position;
                    }
                    set
                    {
                        position = value;
                        selectedCard = detailCards[position];

                        OnPropertyChanged();
                        OnPropertyChanged(nameof(SelectedCard));
                    }
                }

                public ICommand ChangePositionCommand => new Command(ChangePosition);

                private void ChangePosition(object obj)
                {
                    string direction = (string)obj;

                    if (direction == "L")
                    {
                        if (position == 0)
                        {
                            Position = detailCards.Count - 1;
                            return;
                        }

                        Position -= 1;
                    }
                    else if (direction == "R")
                    {
                        if (position == detailCards.Count - 1)
                        {
                            Position = 0;
                            return;
                        }

                        Position += 1;
                    }
                }
        */

        public DetailApiModel.Rootobject GetDetailApiModel(int id)
        {

            var DetailApiModel = new DetailApiModel.Rootobject();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var requestObj = (HttpWebRequest)WebRequest.Create("https://mec3.cz/mec3mobile/ProductMobile/GetCategoryDetail/" + id); ;
            requestObj.Method = "Get";


            var responseObj = (HttpWebResponse)requestObj.GetResponse();
            if (responseObj.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    DetailApiModel = JsonConvert.DeserializeObject<DetailApiModel.Rootobject>(sr.ReadToEnd());               
                    sr.Close();
                }
            }
            return DetailApiModel;

        }

        public DetailDto GetDetailList(int index)
        {
            
            var model = GetDetailApiModel(index);

            var name = model.Data.Name;
            var image = model.Data.Image;
            var id = model.Data.ID;
            var description = model.Data.Description;
            var products = GetDetailProductsList(index);

            var DetailDto = new DetailDto(name,id,image, description, products);


            return DetailDto;
        }


        private ObservableCollection<DetailProductDto> GetDetailProductsList(int index)
        {
            var DetailProductDto = new ObservableCollection<DetailProductDto>();
            var model = GetDetailApiModel(index);

            foreach (var result in model.Data.Products)
            {
                var productName = result.Name;
                var productPartNumber = result.PartNumber;
                var productId = result.ID;
                var productDescription = result.Description;
                var productImage = result.Image;
                var documents = new ObservableCollection<DetailDocumentDto>();


                foreach (var docResult in result.Documents)
                {
                    documents.Add(new DetailDocumentDto(docResult.Nazev, docResult.Url));
                }

                DetailProductDto.Add(new DetailProductDto(productName, productPartNumber, productId, productDescription, productImage, documents));

            }

            
            return DetailProductDto;
        }



        async void AddDetailItemToDB(int index)
        {

            // Nejdříve vymazání detailů z databáze 

            var list = App.Database.GetDetailsAsync();

            foreach (var item in list.Result)
            {
                await App.Database.DeleteDetailItemAsync(item);
            }

                    var detailDto = new DetailDto();      

                    detailDto = GetDetailList(index);

                     



            await App.Database.SaveDetailItemAsync(new DetailDto
                        {

                            Name = detailDto.Name,
                            DetailID = detailDto.DetailID,
                            Image = detailDto.Image,
                            Description = detailDto.Description,
                            Products = detailDto.Products

                        });                            
            }

        private DetailDto RetypeAsync()
        {
            var list = App.Database.GetDetailsAsync();
            var detailDto = new DetailDto();

            foreach (var item in list.Result)
            {
                detailDto = new DetailDto
                {
                    Name = item.Name,
                    DetailID = item.DetailID,
                    Image = item.Image,
                    Description = item.Description,
                    Products = item.Products
                };
            }

            return detailDto;

        }

        

    }
    }

