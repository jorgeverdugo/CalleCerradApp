using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media.Imaging;

namespace calleCerradApp
{
    public partial class mapa : PhoneApplicationPage
    {
        public mapa()
        {
            InitializeComponent();

            GetCurrentPositionC();

            barraNegra();
            

        }

         #region miUbicacion

        private List<GeoCoordinate> coordinates = new List<GeoCoordinate>();

        private async void GetCurrentPositionC()
        {
            Geolocator geolocator = new Geolocator();
            Geoposition currentPosition = null;
            try
            {
                // Obtener posición actual
                currentPosition = await geolocator.GetGeopositionAsync();
                // Guardamos el valor de las coordenadas de la posición

                // actual en nuestra lista
                coordinates.Add(new GeoCoordinate
                                 (currentPosition.Coordinate.Latitude,
                                 currentPosition.Coordinate.Longitude));
                // Centramos el mapa en la posición actual
                //Centrar el mapa en mi posición
                this.mapaCalle.Center = coordinates.LastOrDefault();
                this.mapaCalle.ZoomLevel = 13;

                // Create a MapOverlay to contain the circle.
                MapOverlay myLocationOverlay = new MapOverlay();
                myLocationOverlay.Content = personaC();
                myLocationOverlay.PositionOrigin = new Point(1, 1);
                myLocationOverlay.GeoCoordinate = coordinates.LastOrDefault();              

                MapOverlay Calle1 = new MapOverlay();
                Calle1.Content = Circulo();
                Calle1.PositionOrigin = new Point(0.5, 0.5);
                Calle1.GeoCoordinate = new GeoCoordinate(-33.438568, -70.652507);


                MapOverlay Calle2 = new MapOverlay();
                Calle2.Content = Circulo();
                Calle2.PositionOrigin = new Point(0.5, 0.5);
                Calle2.GeoCoordinate = new GeoCoordinate(-33.445946, -70.651266);

                MapLayer myLocationLayer = new MapLayer();
                myLocationLayer.Add(myLocationOverlay);
                mapaCalle.Layers.Add(myLocationLayer);
                myLocationLayer.Add(Calle1);
                myLocationLayer.Add(Calle2);
            }
            catch
            {
                // Localización desactivada en las características del teléfono
                // o capacidad no incluida en el manifiesto
                MessageBox.Show("No Podemos Establecer su ubicación dado que no ha ensendido su GPS!");
            }



        }
        #endregion

        public Image personaC()
        {
            Image personaC = new Image();
            BitmapImage bi = new BitmapImage();
            bi.UriSource = new Uri("/imagenes/persona2.png", UriKind.Relative);
            personaC.Source = bi;
            personaC.Height = 40;
            personaC.Width = 40;
            personaC.Opacity = 50;
            personaC.Tap += personaC_Tap; 
            return personaC;
        }

        public Image Circulo()
        {
            Image Calles = new Image();
            BitmapImage bi = new BitmapImage();
            bi.UriSource = new Uri("/imagenes/circulo.png", UriKind.Relative);
            Calles.Source = bi;
            Calles.Height = 60;
            Calles.Width = 60;
            Calles.Opacity = 60;
            //Calles.Tap += clinica1_Tap;
            return Calles;
        }

        void personaC_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Porque Me precionas");
        }

        #region BarraNegra
        private void barraNegra()
        {
            // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
            ApplicationBarIconButton zoomMay = new ApplicationBarIconButton(new Uri("/Assets/mayor.png", UriKind.Relative));
            zoomMay.Text = "Zoom +";
            ApplicationBar.Buttons.Add(zoomMay);
            zoomMay.Click += zoomMay_Click;

            ApplicationBarIconButton zoomMen = new ApplicationBarIconButton(new Uri("/Assets/menor.png", UriKind.Relative));
            zoomMen.Text = "Zoom -";
            ApplicationBar.Buttons.Add(zoomMen);
            zoomMen.Click += zoomMen_Click;
        }

        private void zoomMen_Click(object sender, EventArgs e)
        {
            try
            {
                this.mapaCalle.ZoomLevel -= 1;
                if (mapaCalle.ZoomLevel == 1)
                {

                    MessageBox.Show("Esto Es Lo Minimo Del Zoom");
                }
            }
            catch (Exception) { }
        }

        private void zoomMay_Click(object sender, EventArgs e)
        {
            try
            {
                this.mapaCalle.ZoomLevel += 1;

                if (mapaCalle.ZoomLevel == 20)
                {
                    MessageBox.Show("Esto Es Lo Maximo Del Zoom");

                }
            }
            catch (Exception) { }

        }
        #endregion
   
    
    }
}