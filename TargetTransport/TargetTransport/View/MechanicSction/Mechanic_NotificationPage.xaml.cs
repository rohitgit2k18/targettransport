﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mechanic_NotificationPage : ContentPage
	{
		public Mechanic_NotificationPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Mechanic_NavigationPage();
            otherPage.Detail = new NavigationPage(new Mechanic_NotificationPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
           
        }
    }
}