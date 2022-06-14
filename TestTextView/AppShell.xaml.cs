using System;
using System.Collections.Generic;
using TestTextView.ViewModels;
using TestTextView.Views;
using Xamarin.Forms;

namespace TestTextView
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
