using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestTextView.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Загрузка файла в LED-костюм";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://192.168.0.10"));
        }

        public ICommand OpenWebCommand { get; }
    }
}