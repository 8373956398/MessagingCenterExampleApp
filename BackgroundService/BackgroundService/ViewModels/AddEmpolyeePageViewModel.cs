using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace BackgroundService.ViewModels
{
    class AddEmpolyeePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public AddEmpolyeePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        public Command ClosePopup
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PopPopupAsync();
                });
            }
        }
        public Command SaveEmpolyee
        {
            get
            {
                return new Command(() =>
                {
                    Data data = new Data();
                    data.Name = EmpolyeeName;
                    data.Address = Address;
                    MessagingCenter.Send<Data>(data, "Key");
                    Navigation.PopPopupAsync();
                });
            }
        }
        string _empolyeeName;
        public string EmpolyeeName
        {
            get
            {
                return _empolyeeName;
            }
            set
            {
                _empolyeeName = value;
            }

        }
        string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
