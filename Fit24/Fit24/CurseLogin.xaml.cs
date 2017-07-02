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
	public partial class CurseLogin : ContentPage
    {
        private string location = "";

		public CurseLogin(string location)
        {
            InitializeComponent();
            this.location = location;
            StackLayout layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            AddKurs(ref layout, "Cycling", "Jane Doe", "02.07.2015", "14:00", "15:00", 10);
            AddKurs(ref layout, "Bauch, Beine, Po", "Jane Doe", "02.07.2015", "15:00", "16:00", 8);
            AddKurs(ref layout, "Zumba", "Jane Doe", "02.07.2015", "19:00", "20:00", 14);

            Button pay = new Button { Text = "Bezahlen" };
            pay.Clicked += Pay_Clicked;
            layout.Children.Add(pay);
        }

        private void Pay_Clicked(object sender, EventArgs e)
        {
            //todo: check if the user is loged in
            Navigation.PushAsync(new UserLogin("Kursname"));
            //Navigation.PushAsync(new Pay("Kursname"));
        }

        private void AddKurs(ref StackLayout layout, string name, string trainer, string date, string startTime, string endTime, int places)
        {
            Grid grid = new Grid();
            grid.BackgroundColor = Color.Gray;

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            var topLeft = new Label { Text = name };
            topLeft.GestureRecognizers.Add(new TapGestureRecognizer
            {
                TappedCallback = (v, o) => {
                    Navigation.PushAsync(new CurseDetails("Kursname"));
                },
                NumberOfTapsRequired = 1
            });
            var topRight = new Label { Text = trainer };
            topRight.GestureRecognizers.Add(new TapGestureRecognizer
            {
                TappedCallback = (v, o) => {
                    Navigation.PushAsync(new CurseDetails("Kursname"));
                },
                NumberOfTapsRequired = 1
            });
            var middleLeft = new Label { Text = date };
            var middleRight = new Label { Text = places + " Plätze frei" };
            var bottomLeft = new Label { Text = "von " + startTime + " - " + endTime};
            var bottomRight = new Button { Text = "=> Jetzt anmelden" };
            grid.Children.Add(topLeft, 0, 0);
            grid.Children.Add(topRight, 1, 0);
            grid.Children.Add(middleLeft, 0, 1);
            grid.Children.Add(middleRight, 1, 1);
            grid.Children.Add(bottomLeft, 0, 2);
            grid.Children.Add(bottomRight, 1, 2);

            layout.Children.Add(grid);

            bottomRight.Clicked += OnButtonToShopingCarClicked;
        }

        void OnButtonToShopingCarClicked(object sender, EventArgs e)
        {
            //todo: Add to shopping car;
        }
    }
}
