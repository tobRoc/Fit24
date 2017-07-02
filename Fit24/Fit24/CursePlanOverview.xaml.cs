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
	public partial class CursePlanOverview : ContentPage
    {
        private string location = "";

		public CursePlanOverview(string location)
        {
            InitializeComponent();
            Grid gridCursePlan = this.FindByName<Grid>("gridCursePlanOverview");
            this.location = location;

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            //todo: remove this if the external file reading work

            if (!App.ApplicationInfos.ContainsKey("kursplan_amberg light.csv")) { App.ApplicationInfos.Add("kursplan_amberg light.csv", AddCursePlan(assembly, "kursplan_amberg light.csv")); }
            if (!App.ApplicationInfos.ContainsKey("kursplan_amberg.csv")) { App.ApplicationInfos.Add("kursplan_amberg.csv", AddCursePlan(assembly, "kursplan_amberg.csv")); }
            if (!App.ApplicationInfos.ContainsKey("kursplan_nabburg.csv")) { App.ApplicationInfos.Add("kursplan_nabburg.csv", AddCursePlan(assembly, "kursplan_nabburg.csv")); }
            if (!App.ApplicationInfos.ContainsKey("kursplan_schwandorf.csv")) { App.ApplicationInfos.Add("kursplan_schwandorf.csv", AddCursePlan(assembly, "kursplan_schwandorf.csv")); }
            if (!App.ApplicationInfos.ContainsKey("kursplan_sulzbach-rosenberg.csv")) { App.ApplicationInfos.Add("kursplan_sulzbach-rosenberg.csv", AddCursePlan(assembly, "kursplan_sulzbach-rosenberg.csv")); }
            if (!App.ApplicationInfos.ContainsKey("kursplan_weiden i.d. opf.csv")) { App.ApplicationInfos.Add("kursplan_weiden i.d. opf.csv", AddCursePlan(assembly, "kursplan_weiden i.d. opf.csv")); }
            //end remove

            List<string> cursePlan = App.ApplicationInfos["kursplan_" + location.ToLower() + ".csv"];

            for (int i = 0; i < cursePlan.Count; i++)
            {
                string[] cellEntries = cursePlan[i].Split(';');
                for (int j = 0; j < cellEntries.Length; j++)
                {
                    if ((0 == j) || (0 == i))
                    {
                        Label cellEntrie = new Label();
                        cellEntrie.TextColor = Color.Yellow;
                        cellEntrie.Text = cellEntries[j];
                        gridCursePlan.Children.Add(cellEntrie, j, i);
                    }
                    else
                    {
                        Label cellEntrie = new Label();
                        cellEntrie.Text = cellEntries[j];
                        cellEntrie.GestureRecognizers.Add(new TapGestureRecognizer
                        {
                            TappedCallback = (v, o) => {
                                Navigation.PushAsync(new CurseLogin("Kursname"));
                            },
                            NumberOfTapsRequired = 1
                        });
                        PinchGestureRecognizer pgr = new PinchGestureRecognizer();
                        pgr.PinchUpdated += Pgr_PinchUpdated;
                        cellEntrie.GestureRecognizers.Add(pgr);
                        gridCursePlan.Children.Add(cellEntrie, j, i);
                    }
                }
            }
        }

        private void Pgr_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            //todo: zoom in and out
        }

        private static List<string> AddCursePlan(Assembly assembly, string studioCurses)
        {
            Stream stream = assembly.GetManifestResourceStream("Fit24.Droid.Data." + studioCurses);
            List<string> lines = new List<string>();
            using (TextReader tr = new System.IO.StreamReader(stream))
            {
                string line = tr.ReadLine();
                while (null != line)
                {
                    lines.Add(line);
                    line = tr.ReadLine();
                }
            }
            return lines;
        }
    }
}
