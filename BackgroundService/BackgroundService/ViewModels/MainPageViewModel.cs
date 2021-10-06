using BackgroundService.Models;
using BackgroundService.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BackgroundService.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            EmpolyeeList = new ObservableCollection<Empolyee>();
            EmpolyeeList.Add(new Empolyee { Name = "Praveen", Address = "Vijay Enclave" });
            EmpolyeeList.Add(new Empolyee { Name = "Abhinav", Address = "Laxmi Nagar" });
            EmpolyeeList.Add(new Empolyee { Name = "Ashwini", Address = "Lajpat Nagar" });
            EmpolyeeList.Add(new Empolyee { Name = "Neelam", Address = "Sagarpur" });
        }
        
        public Command AddEmpolyee
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Unsubscribe<Data>(this, "Key");
                    Navigation.PushPopupAsync(new AddEmpolyeePage());
                    MessagingCenter.Subscribe<Data>(this, "Key", (value) =>
                    {
                        EmpolyeeList.Add(new Empolyee { Name = value.Name, Address = value.Address });
                        MessagingCenter.Unsubscribe<Data>(this, "Key");
                    });
                });
            }
        }

        ObservableCollection<Empolyee> _empolyeeList;
        public ObservableCollection<Empolyee> EmpolyeeList
        {
            get { return _empolyeeList; }
            set
            {
                _empolyeeList = value;
                OnPropertyChnaged();
            }
        }
        protected virtual void OnPropertyChnaged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
    public class Data
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
