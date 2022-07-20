using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2Grupo6.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourSquarePage : ContentPage
    {
        public FourSquarePage()
        {
            InitializeComponent();
        }

        private async void btncargarvenues_Clicked(object sender, EventArgs e)
        {
            List<Models.ApiFourSquare.Venue> sitioscerca = new List<Models.ApiFourSquare.Venue>();
            sitioscerca = await Controllers.FoursquareController.getListSites(13.3122, -87.1798);

            listasitios.ItemsSource = sitioscerca;
        }
    }
}