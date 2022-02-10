using MEC3App.Model;
using MEC3AppSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MEC3App.ViewModel
{
    class SeminarDetailViewModel : BaseViewModel
    {

        private ObservableCollection<SeminarModel> seminarCards;
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


    }
}
