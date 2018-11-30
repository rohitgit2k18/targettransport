using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashSignInPage : ContentPage
    {
        public SplashSignInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new LoginPage(),true);
        }
    }
}