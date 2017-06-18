using System;
using System.IO;
using System.Collections.Generic;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Fit24.Droid
{
	[Activity (Label = "Fit24", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            Fit24.App myApp = new Fit24.App();
            
            #region handle additional files 
            /*todo: toro; it is not working, no idea why! I change the csv files from "Content" to "Embedded Ressource". It was not possible to say additional files.  
            List<string> filesToBeOpend = new List<string>();
            filesToBeOpend.Add("kursplan_amberg.csv");
            foreach (string fileName in filesToBeOpend)
            {
                string filePath = FileAccessHelper.GetLocalFilePath(fileName);
                using (TextReader tr = File.OpenText(filePath))
                {
                    string line = tr.ReadLine();
                    List<string> lines = new List<string>();
                    lines.Add(line);
                    while (null != tr.ReadLine())
                    {
                        lines.Add(line);
                    }
                    App.ApplicationInfos.Add("kursplan_amberg.csv", lines);
                }
            }
            */
            #endregion
            LoadApplication(myApp);
        }
	}
}

