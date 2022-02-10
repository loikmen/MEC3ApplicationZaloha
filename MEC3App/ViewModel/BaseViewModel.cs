using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MEC3AppSample.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public BaseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
