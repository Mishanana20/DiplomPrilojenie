using System;
using System.ComponentModel;
using System.IO;
using TestTextView.ViewModels;
using Xamarin.Forms;

namespace TestTextView.Views
{
    public partial class ItemDetailPage : ContentPage
    {

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

       async void Save(object sender, EventArgs args)
        {
            var docs = @"/storage/emulated/0/Android/data/com.companyname.testtextview2/Effect-Description/"; //путь к файлу с описанием
            var docs2 = @"/storage/emulated/0/Android/data/com.companyname.testtextview2/Effec/";             //путь к исходному файлу
            //docs2 = docs + "/Effect";
            var filename = Path.Combine(docs, /*Text +*/ ".txt");
            // string filename = Text + ".txt";
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filename);
                
                    File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
                    // обновляем список файлов
                    //UpdateFileList();
                    sw.Close();
                    await Shell.Current.DisplayAlert("Файл сохранен!", filename, "ok");
                }
                catch
                {
                    await Shell.Current.DisplayAlert("Файл не сохранен!", filename, "ok");
                }
            }

        }


    }
}