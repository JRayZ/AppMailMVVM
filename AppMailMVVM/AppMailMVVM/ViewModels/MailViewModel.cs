using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppMailMVVM.Models;

namespace AppMailMVVM.ViewModels
{
    class MailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<mail> _mails;
        public ICommand AddCommand { get; }

        public ICommand LoadPhotoCommand { get; }

        public MailViewModel(ObservableCollection<mail> mails)
        {
            _mails = mails;
            LoadPhotoCommand = new Command(async (e) =>
            {
                var photos = await MediaPicker.PickPhotoAsync();
                var stream = await LoadImageAsync(photos);
            });
            AddCommand = new Command(async () => {

                mails.Add(new mail(Title, Description, From, image));

                await App.Current.MainPage.Navigation.PopAsync();
            });
        }

        async Task<Stream> LoadImageAsync(FileResult photos)
        {

            if (photos == null)
            {
                return null;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photos.FileName);
            var stream = await photos.OpenReadAsync();
            image = photos.FullPath;
            return stream;
        }

        private string _title;
        private string _description;
        private DateTime _date;
        private string _from;
        private string _image;
        private string _to;

        public string Title 
        {
            get 
            { return _title; } 
            set 
            { _title = value; 
                OnPropertyChanged(nameof(Title)); } 
        }

        public string Description 
        { 
            get 
            { return _description; } 
            set 
            { _description = value; 
                OnPropertyChanged(nameof(Description)); } 
        }

        public DateTime Date 
        {
            get 
            { return _date; } 
            set 
            { _date = value; 
                OnPropertyChanged(nameof(Date)); } 
        }
        
        public string From 
        { 
            get 
            { return _from; } 
            set 
            { _from = value; 
                OnPropertyChanged(nameof(From)); } 
        }
        
        public string To 
        { 
            get 
            { return _to; } 
            set 
            { _to = value; 
                OnPropertyChanged(nameof(To)); }  
        }

        public string image 
        { 
            get 
            { return _image; } 
            set 
            { _image = value; 
                OnPropertyChanged(nameof(image)); } 
        }
        
        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }

    }
}
