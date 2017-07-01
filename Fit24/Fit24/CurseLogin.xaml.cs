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
            
        }
    }
}
