using MEC3App.Model;
using MEC3App.Views;
using MEC3AppSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MEC3App.ViewModel
{
    class SeminarsViewModel : BaseViewModel
    {

        public SeminarsViewModel()
        {
            seminarCards = GetSeminarList();

        }

        ObservableCollection<SeminarModel> seminarCards;
        public ObservableCollection<SeminarModel> SeminarCards
        {
            get { return seminarCards; }
            set
            {
                seminarCards = value;
                OnPropertyChanged();
            }
        }

        private SeminarModel selectedCard;
        public SeminarModel SelectedCard
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
                if (position != seminarCards.IndexOf(selectedCard))
                    return seminarCards.IndexOf(selectedCard);

                return position;
            }
            set
            {
                position = value;
                selectedCard = seminarCards[position];

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
                    Position = seminarCards.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == seminarCards.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }
        }

        private ObservableCollection<SeminarModel> GetSeminarList()
        {
            return new ObservableCollection<SeminarModel>
            {
                new SeminarModel { Name = "Pondělní seminář", Date = "05.08.2020", Video = "https://www.youtube.com/watch?v=zVnZ7RPQnYk&ab_channel=InTheKitchenWithMatt",  Image = "https://cdn.shopify.com/s/files/1/0048/7109/4360/files/logo_transparent.png?height=628&pad_color=ffffff&v=1559035573&width=1200", Details = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur vitae diam non enim vestibulum interdum. Nullam eget nisl. Nulla non lectus sed nisl molestie malesuada. Maecenas aliquet accumsan leo. Donec iaculis gravida nulla. Praesent dapibus. Aenean id metus id velit ullamcorper pulvinar. Mauris elementum mauris vitae tortor. Nam sed tellus id magna elementum tincidunt." },
                new SeminarModel { Name = "Úterní seminář", Date = "06.08.2020", Video = "https://www.youtube.com/watch?v=zVnZ7RPQnYk&ab_channel=InTheKitchenWithMatt", Image = "https://res.cloudinary.com/teepublic/image/private/s--09FMLPtv--/t_Resized%20Artwork/c_fit,g_north_west,h_954,w_954/co_ffffff,e_outline:35/co_ffffff,e_outline:inner_fill:35/co_ffffff,e_outline:35/co_ffffff,e_outline:inner_fill:35/co_bbbbbb,e_outline:3:1000/c_mpad,g_center,h_1260,w_1260/b_rgb:eeeeee/c_limit,f_auto,h_630,q_90,w_630/v1547641326/production/designs/4002092_0.jpg", Details = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur vitae diam non enim vestibulum interdum. Nullam eget nisl. Nulla non lectus sed nisl molestie malesuada. Maecenas aliquet accumsan leo. Donec iaculis gravida nulla. Praesent dapibus. Aenean id metus id velit ullamcorper pulvinar. Mauris elementum mauris vitae tortor. Nam sed tellus id magna elementum tincidunt."},
                new SeminarModel { Name = "Středeční seminář", Date = "07.08.2020", Video = "https://www.youtube.com/watch?v=zVnZ7RPQnYk&ab_channel=InTheKitchenWithMatt", Image = "https://www.thefactsite.com/wp-content/uploads/2017/07/wednesday-facts.jpg", Details = "Aliquam erat volutpat. Nulla non lectus sed nisl molestie malesuada. Etiam neque. Integer in sapien. Nulla non arcu lacinia neque faucibus fringilla. Nunc auctor. Et harum quidem rerum facilis est et expedita distinctio. In enim a arcu imperdiet malesuada. Etiam commodo dui eget wisi. Curabitur vitae diam non enim vestibulum interdum. Pellentesque arcu. Aliquam erat volutpat. Phasellus faucibus molestie nisl. Aenean vel massa quis mauris vehicula lacinia. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Et harum quidem rerum facilis est et expedita distinctio. Aenean id metus id velit ullamcorper pulvinar."},
                new SeminarModel { Name = "Čtvrteční seminář", Date = "08.08.2020", Video = "https://www.youtube.com/watch?v=zVnZ7RPQnYk&ab_channel=InTheKitchenWithMatt", Image = "https://i0.wp.com/www.goodigcaptions.com/wp-content/uploads/2020/03/Thursday-Instagram-Captions.jpg?resize=680%2C433&ssl=1", Details = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam sit amet magna in magna gravida vehicula. Aliquam erat volutpat. Proin pede metus, vulputate nec, fermentum fringilla, vehicula vitae, justo. Vivamus porttitor turpis ac leo. Phasellus et lorem id felis nonummy placerat. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean vel massa quis mauris vehicula lacinia. Donec iaculis gravida nulla. Nam sed tellus id magna elementum tincidunt."},
                new SeminarModel { Name = "Páteční seminář", Date = "09.08.2020", Video = "https://www.youtube.com/watch?v=zVnZ7RPQnYk&ab_channel=InTheKitchenWithMatt", Image = "https://tonimarino.co.uk/wp-content/uploads/2020/07/tgi_fridays_uk_logo-1200x439.png", Details = "Pellentesque arcu. Maecenas lorem. Duis bibendum, lectus ut viverra rhoncus, dolor nunc faucibus libero, eget facilisis enim ipsum id lacus. Nulla est. Curabitur vitae diam non enim vestibulum interdum. Suspendisse nisl. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. In laoreet, magna id viverra tincidunt, sem odio bibendum justo, vel imperdiet sapien wisi sed libero."}
            };
        }

        
                private Command selectionCommand;

                public ICommand SelectionCommand
                {
                    get
                    {
                        if (selectionCommand == null)
                        {
                            selectionCommand = new Command(DisplaySeminarDetail);
                        }

                        return selectionCommand;
                    }
                }
        
                private void DisplaySeminarDetail()
                {

                    var newViewModel = new SeminarDetailViewModel { SelectedCard = selectedCard, SeminarCards = seminarCards, Position = seminarCards.IndexOf(selectedCard) };
                    var newPage = new SeminarDetailsPage { BindingContext = newViewModel };
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(newPage, true);
                }
        

    }

}

