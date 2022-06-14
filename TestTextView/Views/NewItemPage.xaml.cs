using System;
using System.Collections.Generic;
using System.ComponentModel;
using TestTextView.Models;
using TestTextView.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestTextView.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}