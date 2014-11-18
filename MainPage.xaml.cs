using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using calleCerradApp.Resources;

namespace calleCerradApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
        }
        private void btnMapa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/mapa.xaml", UriKind.Relative));
            string gps = "La Aplicacion calleCerradApp Necesitara obtener Tu ubicacion";
            MessageBox.Show(gps, "calleCerradApp", MessageBoxButton.OKCancel);
        }

        private void btnMapa_Copy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/calleCerradApp;component/LocalXMLDealingPage.xaml", UriKind.Relative));
        }

    }
}