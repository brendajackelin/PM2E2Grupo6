using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E2Grupo6.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            double Latitud = Convert.ToDouble(txtLat.Text);
            double Longitud = Convert.ToDouble(txtLng.Text);

            //var location = await Geolocation.GetLocationAsync();

            //if (location == null)
            //{
            //    location = await Geolocation.GetLastKnownLocationAsync();
            //}

            Maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitud, Longitud), Distance.FromMiles(1)));

            var localizacion = CrossGeolocator.Current;

            if (localizacion != null)
            {
                localizacion.PositionChanged += Locatilazion_PositionChanged;

                if (!localizacion.IsListening)
                {
                    Debug.WriteLine("StarListeningAsync");
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                }

                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(Latitud, Longitud);
                Maps.MoveToRegion(MapSpan.FromCenterAndRadius(mapac, Distance.FromMiles(1)));

            }

            else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(Latitud, Longitud);


                Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

            }
        }



        private void Locatilazion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {

            double Latitud = Convert.ToDouble(txtLat.Text);
            double Longitud = Convert.ToDouble(txtLng.Text);
            var mapac = new Position(Latitud, Longitud);
            Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

        }

    }
}