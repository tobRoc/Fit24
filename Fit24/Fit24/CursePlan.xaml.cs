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
	public partial class CursePlan : ContentPage
    {
        private string location = "";

		public CursePlan(string location)
        {
            InitializeComponent();
            Grid gridCursePlan = this.FindByName<Grid>("gridCursePlan");
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
                    Label cellEntrie = new Label();
                    cellEntrie.Text = cellEntries[j];
                    if ((0 == j)||(0 == i)) { cellEntrie.TextColor = Color.Yellow; }
                    gridCursePlan.Children.Add(cellEntrie, j, i);
                }
            }

            //< Label Grid.Row = "0" Grid.Column = "1" Text = "Mo" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "2" Text = "Di" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "3" Text = "Mi" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "4" Text = "Do" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "5" Text = "Fr" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "6" Text = "Sa" TextColor = "Yellow" />
            //< Label Grid.Row = "0" Grid.Column = "7" Text = "So" TextColor = "Yellow" />
            //< Label Grid.Row = "1" Grid.Column = "0" Text = "08:00" TextColor = "Yellow" />       
            //< Label Grid.Row = "2" Grid.Column = "0" Text = "09:00" TextColor = "Yellow" />              
            //< Label Grid.Row = "3" Grid.Column = "0" Text = "10:00" TextColor = "Yellow" />                     
            //< Label Grid.Row = "4" Grid.Column = "0" Text = "17:00" TextColor = "Yellow" />                            
            //< Label Grid.Row = "5" Grid.Column = "0" Text = "17:30" TextColor = "Yellow" />                                   
            //< Label Grid.Row = "6" Grid.Column = "0" Text = "18:00" TextColor = "Yellow" />                                          
            //< Label Grid.Row = "7" Grid.Column = "0" Text = "18:30" TextColor = "Yellow" />                                                 
            //< Label Grid.Row = "8" Grid.Column = "0" Text = "19:00" TextColor = "Yellow" />                                                        
            //< Label Grid.Row = "9" Grid.Column = "0" Text = "19:30" TextColor = "Yellow" />                                                               
            //< Label Grid.Row = "10" Grid.Column = "0" Text = "20:00" TextColor = "Yellow" />
            //var topLeft = new Label { Text = "Top Left" };
            //grid.Children.Add(topLeft, 0, 0);
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
