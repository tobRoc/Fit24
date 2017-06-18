using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Fit24
{
	public partial class App : Application
	{
        public static Dictionary<string, List<string>> ApplicationInfos = new Dictionary<string, List<string>>();

        public App ()
		{
			InitializeComponent();

			//MainPage = new Fit24.MainPage();
            MainPage = new NavigationPage(new Fit24.MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
