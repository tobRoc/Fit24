using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fit24
{
	public partial class UserLogin : ContentPage
    {
        private string location = "";

		public UserLogin(string location)
        {
            InitializeComponent();
            this.location = location;
            Grid gridUserLogin = this.FindByName<Grid>("gridUserLogin");
            #region fill grid curse plan
            Label cellEntrie = new Label();
            cellEntrie.Text = "Emailadresse";
            gridUserLogin.Children.Add(cellEntrie, 0, 0);

            Entry cellEmailaddress = new Entry();
            cellEmailaddress.Text = "Emailadresse@gmx.de";
            gridUserLogin.Children.Add(cellEmailaddress, 0, 1);

            Label cellEntriePassword = new Label();
            cellEntriePassword.Text = "Kennwort";
            gridUserLogin.Children.Add(cellEntriePassword, 1, 0);

            Entry cellPassword = new Entry();
            cellPassword.Text = "Mein Kennwort";
            gridUserLogin.Children.Add(cellPassword, 1, 1);

            #endregion

            Button buttonFacebook = this.FindByName<Button>("btnFacebook");
            buttonFacebook.Clicked += OnButtonFacebookClicked;
            
            Button btnUserlogin = this.FindByName<Button>("btnUserlogin");
            btnUserlogin.Clicked += OnButtonUserloginClicked;
        }
        void OnButtonFacebookClicked(object sender, EventArgs e)
        {
            //todo: Navigation.PushAsync(new FacebookLogin("Kursname"));
        }
        void OnButtonUserloginClicked(object sender, EventArgs e)
        {
            //todo: UserLogin;
        }
    }
}
