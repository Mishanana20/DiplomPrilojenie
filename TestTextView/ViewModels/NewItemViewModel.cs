using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using TestTextView.Models;
using Xamarin.Forms;

namespace TestTextView.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string texteditor;
        private string newText;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string TextEditor
        {
            get => texteditor;
            set => SetProperty(ref texteditor, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                TextEditor = TextEditor
        };
           
           await DataStore.AddItemAsync(newItem);

            ///пытаюсь создать текстовый файл
            var docs = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var docs2 = @"/storage/emulated/0/Android/data/com.companyname.testtextview2/Effect/";
            var docs3 = @"/storage/emulated/0/Android/data/com.companyname.testtextview2/Effect-Description/";
            //docs2 = docs + "/Effect";
            var filename = Path.Combine(docs2, Text+".txt");
            var filename2 = Path.Combine(docs3, Text + ".txt"); //для создания текстового файла с тем-же именем, но в другой папке
            //в котором хранится только имя файла и его описание 

            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(TextEditor);
            sw.Close();

            StreamWriter sw2 = new StreamWriter(filename2);
            sw2.WriteLine(Description);
            sw2.Close();

            if (File.Exists(filename))
            {
                await Shell.Current.DisplayAlert("Файл успешно создан!", filename.ToString(), "ok");
            }
            ///и окончание попытки


            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
