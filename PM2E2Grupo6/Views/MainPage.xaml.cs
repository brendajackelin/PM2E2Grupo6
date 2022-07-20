using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using Plugin.Geolocator;
using System.Reflection;
using System.IO;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.AudioRecorder;
using Xamarin.Essentials;
using PM2E2Grupo6.Models;
using PM2E2Grupo6.Views;
using Newtonsoft.Json;
using System.Net.Http;

namespace PM2E2Grupo6
{
    public partial class MainPage : ContentPage
    {
        public string PhotoPath;

        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        public string AudioPath, fileName;

        public bool takedvideo = false;
        public bool audio = false;

        public bool takedfoto = false;
        public byte[] imgbyte;
        public Image image = new Image();

        public MainPage()
        {
            InitializeComponent();
            Conexion();
        }

        //INICIO DE VALIDACION DE CONEXION A INTERNET
        private async void Conexion()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert("Sin Internet", "Por favor active su conexion a internet", "Ok");
                return;
            }
            else
            {
                await DisplayAlert("Bienvenido", "Cuenta con Internet", "Ok");
                Ubicacion();
            }
        }//FIN



        //BOTON DE GRABAR VIDEO
        private async void BtnGrabarVideo_Clicked(object sender, EventArgs e)
        {

            var status = await Permissions.RequestAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                return; // si no tiene los permisos no avanza
            }

            GrabarVideo();
        }

        //MÉTODO PARA CAPTURAR EL VIDEO
        public async void GrabarVideo()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");

                takedvideo = true;

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {

                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            PhotoPath = newFile;
        }

        // INICIO UBICACION
        private async void Ubicacion()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al cargar el plugin", "OK");
                return;
            }

            if (CrossGeolocator.Current.IsGeolocationEnabled)
            {
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 0.5);

            }
            else
            {
                await DisplayAlert("Error", "El GPS no esta activo en este dispositivo", "OK");
            }

        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {

                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();

            txtlatitud.Text = position.Result.Latitude.ToString();
            txtlongitud.Text = position.Result.Longitude.ToString();
        }




        //TOOLBAR DE NUEVA UBICACIÓN
        private async void Toolbar01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        //TOOLBAR DE LISTA DE UBICACIONES
        private async void Toolbar02_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DirectionsPage());
        }

        //BOTON GRABAR AUDIO
        private async void BtnGrabarAudio_Clicked(object sender, EventArgs e)
        {

            var status = await Permissions.RequestAsync<Permissions.Microphone>();
            var status2 = await Permissions.RequestAsync<Permissions.StorageRead>();
            var status3 = await Permissions.RequestAsync<Permissions.StorageWrite>();
            if (status != PermissionStatus.Granted & status2 != PermissionStatus.Granted & status3 != PermissionStatus.Granted)
            {
                return; // si no tiene los permisos no avanza
            }

            audio = true;

            if (string.IsNullOrEmpty(txtdescripcion.Text))
            {
                await DisplayAlert("Notificación", "Ingrese una descripción", "OK");
                return;
            }


            if (audioRecorderService.IsRecording)
            {
                await audioRecorderService.StopRecording();
                audioPlayer.Play(audioRecorderService.GetAudioFilePath());
            }
            else
            {
                btnGrabarAudio.IsEnabled = false;
                btnDetener.IsEnabled = true;
                await audioRecorderService.StartRecording();
            }

        }

        //BOTON DETENER AUDIO
        private async void BtnDetener_Clicked(object sender, EventArgs e)
        {



            if (audioRecorderService.IsRecording)
            {
                await audioRecorderService.StopRecording();
                //saveAudio();

                if (await DisplayAlert("Audio", "¿Desea reproducir el audio?", "SI", "NO"))
                {
                    audioPlayer.Play(audioRecorderService.GetAudioFilePath());
                }
                btnGrabarAudio.IsEnabled = true;
                btnDetener.IsEnabled = false;

            }
            else
            {
                await audioRecorderService.StartRecording();
            }

        }

        //METODO PARA GUARDAR EL AUDIO EN EL STORAGE
        private void SaveAudio()
        {
            if (audioRecorderService.FilePath != null)
            {

                var stream = audioRecorderService.GetAudioFileStream();

                fileName = Path.Combine(FileSystem.CacheDirectory, DateTime.Now.ToString("ddMMyyyymmss") + "_VoiceNote.wav");

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }

                AudioPath = fileName;

            }
        }

        //BOTON DE GUARDAR
        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            if (ValidationForm().IsCompleted)
            {
                SaveAudio();

                var sit = new Models.Sitio
                //sitios sit = new sitios
                {
                    descripcion = this.txtdescripcion.Text,
                    latitud = this.txtlatitud.Text,
                    longitud = this.txtlongitud.Text,
                    Uri = PhotoPath,
                    Url = AudioPath
                };
                
                /*Models.sitios sit = new Models.sitios();

                sit.descripcion = txtdescripcion.Text;
                sit.latitud = txtdescripcion.Text;
                sit.latitud = txtdescripcion.Text;
                sit.Uri = PhotoPath;
                sit.Url = AudioPath;*/
                

                //Console.WriteLine("" + txtdescripcion);
                /*Uri RequestUri = new Uri("https://sitiosweb2021.000webhostapp.com/PM2E2GRUPO6/insertarSitio.php");

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(sit);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);

                if (response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Salvado", "Guardado Exitosamente", "Ok");
                }*/

                await Controllers.SitiosController.CrearSitio(sit);
                ClearScreen();
                await DisplayAlert("Salvado", "Guardado Exitosamente", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar la ubicacion", "Ok");
            }

        }

        //BOTON LISTA DE UBICACIONES
        private async void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DirectionsPage());
        }

        //METODO PARA VALIDAR LOS CAMPOS
        private async Task ValidationForm()
        {
            if (String.IsNullOrWhiteSpace(txtlatitud.Text) ||
                String.IsNullOrWhiteSpace(txtlongitud.Text) ||
                String.IsNullOrWhiteSpace(txtdescripcion.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "OK");
            }
        }

        //METODO PARA LIMPIAR PANTALLA
        private void ClearScreen()
        {
           //videoPlayer.Source = null;
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtdescripcion.Text = String.Empty;
            //AudioPath = null;
        }

    }
}
