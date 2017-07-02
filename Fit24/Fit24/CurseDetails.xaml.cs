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
	public partial class CurseDetails : ContentPage
    {
        private string location = "";

		public CurseDetails(string location)
        {
            InitializeComponent();
            this.location = location;

            Grid gridCursePlan = this.FindByName<Grid>("gridCurseDetails");
            #region fill grid curse plan
            Label cellEntrie = new Label();
            cellEntrie.Text = "Bild Bild\nBild Bild\nBild Bild\nBild Bild";
            gridCursePlan.Children.Add(cellEntrie, 0, 0);

            Label cellEntrie2 = new Label();
            cellEntrie2.Text = "Name: " + "Jane Doe" + "\n";
            cellEntrie2.Text = "Ausbildung & Erfahrung" + "\n";
            cellEntrie2.Text = "*   " + "Reha Ausbildung" + "\n";
            cellEntrie2.Text = "*   " + "..." + "\n";
            cellEntrie2.Text = "*   " + "..." + "\n";
            cellEntrie2.Text = "*   " + "..." + "\n";
            cellEntrie2.Text = "*   " + "..." + "\n";
            cellEntrie2.Text = "*   " + "..." + "\n";
            gridCursePlan.Children.Add(cellEntrie2, 0, 1);
            #endregion
            Grid gridCursePlanFurtherCurse = this.FindByName<Grid>("gridCurseDetailsFurtherCurse");
            #region fill grid curse plan further curse
            Label cellEntrieFurtherCurse0_0 = new Label();
            cellEntrieFurtherCurse0_0.Text = "Rücken";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse0_0, 0, 0);
            Label cellEntrieFurtherCurse0_1 = new Label();
            cellEntrieFurtherCurse0_1.Text = "23.06.2017;  8:00";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse0_1, 0, 1);
            Label cellEntrieFurtherCurse1_0 = new Label();
            cellEntrieFurtherCurse1_0.Text = "Bach Beine Po";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse1_0, 1, 0);
            Label cellEntrieFurtherCurse1_1 = new Label();
            cellEntrieFurtherCurse1_1.Text = "23.06.2017; 10:00";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse1_1, 1, 1);
            Label cellEntrieFurtherCurse2_0 = new Label();
            cellEntrieFurtherCurse2_0.Text = "...";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse2_0, 2, 0);
            Label cellEntrieFurtherCurse2_1 = new Label();
            cellEntrieFurtherCurse2_1.Text = "...";
            gridCursePlanFurtherCurse.Children.Add(cellEntrieFurtherCurse2_1, 2, 1);
            #endregion

            Button button = this.FindByName<Button>("btnCurseDetailsBook");
            button.Clicked += OnButtonClicked;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserLogin("Kursname"));
        }
    }
}
