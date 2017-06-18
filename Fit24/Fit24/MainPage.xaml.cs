using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fit24
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
			InitializeComponent();

            Label lblMainText = this.FindByName<Label>("mainText");
            Picker picker = this.FindByName<Picker>("mainPicker");
            Image imgMain = this.FindByName<Image>("mainImage");
            imgMain.Aspect = Aspect.AspectFit;
            imgMain.Source = ImageSource.FromResource("karte_amberg.png");

            string text = @"Fitness und Gesundheitstraining ist nicht nur eine Tätigkeit, sondern eine Lebenseinstellung.";
            //text += @"Fit 24 und seine Mitarbeiter sind der festen Überzeugung, dass Bewegung zu den Grundbedürfnissen des Menschen gehören und dass richtiges, auf die Person zugeschnittes Training nicht nur die Kondition verbessert, sondern viel mehr bewirkt.";
            //text += @"Ein schmerzfreier Rücken oder eine Figur, mit der man sich wohl fühlt, tragen direkt zu mehr Lebensqualität bei.";
            //text += @"Fit 24 legt besonders viel Wert auf Qualität und Freundlichkeit.";
            //text += @"Jeder wird hier mit einem Lächeln begrüßt und findet in unserer großen Auswahl an Trainingsmöglichkeiten sicher das passende Training." + "\n";
            //text += @"In Kursen wie Spinning oder Zumba kann man in der Gruppe mit viel Spaß und Anleitung sein Ziel verfolgen.";
            text += @"Wer effektiv abnehmen möchte, für den ist unser Gesundheitszirkel, genau das Richtige.";
            text += @"Vollautomatische Geräte, die sich individuell und von ganz alleine auf den Trainierenden einstellen." + "\n";
            //text += @"Dies und noch viel mehr kann man 24 Stunden am Tag und sieben Tage die Woche nutzen.";
            text += @"Es gibt keine Öffnungszeiten und keine Feiertage." + "\n";
            text += @"Die Teams von Fit 24 freuen sich auf deinen Besuch.";
            //text += @"Vereinbare einfach einen Termin für ein unverbindliches Probetraining und pack es an." + "\n";
            text += @"Dein Fit 24 Team";

            lblMainText.Text = text;
            picker.SelectedIndex = 0;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = this.FindByName<Picker>("mainPicker");
            if (1 > picker.SelectedIndex)
            {
                return;
            }
            /*
                        if (1 == picker.SelectedIndex)      { imgMain.Source = ImageSource.FromResource("karte_amberg.png"); }
                        else if (2 == picker.SelectedIndex) { imgMain.Source = ImageSource.FromResource("karte_nabburg.png"); }
                        else if (3 == picker.SelectedIndex) { imgMain.Source = ImageSource.FromResource("karte_schwandorf.png"); }
                        else if (4 == picker.SelectedIndex) { imgMain.Source = ImageSource.FromResource("karte_sulzbachrosenberg.png"); }
                        else if (5 == picker.SelectedIndex) { imgMain.Source = ImageSource.FromResource("karte_weiden.png"); }
              */
            Navigation.PushAsync(new CursePlan(picker.Items[picker.SelectedIndex]));
        }
    }
}
