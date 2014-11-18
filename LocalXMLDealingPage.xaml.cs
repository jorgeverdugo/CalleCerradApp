using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Resources;
using System.Xml.Linq;
using System.Text;
using Windows.Phone.Speech.Synthesis;
using calleCerradApp.Resources;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
//using Windows.Phone.Speech.Synthesis;

namespace calleCerradApp
{
    public partial class LocalXMLDealingPage : PhoneApplicationPage
    {
        string dice = "";
        string dicele = "";

        public LocalXMLDealingPage()
        {
            InitializeComponent();
            barraNegra();
            XDocument loadedData = XDocument.Load("People.xml");

            var data = from query in loadedData.Descendants("Calle")
                       select new Calle
                          {
                              tipo = (string)query.Element("Tipo"),
                              calles = (string)query.Element("Calles"),
                              comuna = (string)query.Element("Comuna"),
                              descripcion = (string)query.Element("Descripcion"),
                              cordenada1 = (string)query.Element("Cordenada1"),
                              cordenada2 = (string)query.Element("Cordenada2")
                          };
            lbList.ItemsSource = data;
            
            foreach (var aux in data)
            {
                 dice=dice+ aux.tipo+" en la comuna de "+aux.comuna+", " +aux.descripcion +".           ";
                 dicele=dicele + aux.calles+" ";
            }

        }


        public class Calle
        {
            string Tipo;
            string Calles;
            string Comuna;
            string Descripcion;
            string Cordenada1;
            string Cordenada2;

            public string tipo
            {
                get { return Tipo; }
                set { Tipo = value; }
            }

            public string calles
            {
                get { return Calles; }
                set { Calles = value; }
            }

            public string comuna
            {
                get { return Comuna; }
                set { Comuna = value; }
            }

            public string descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public string cordenada1
            {
                get { return Cordenada1; }
                set { Cordenada1 = value; }


            }
            public string cordenada2
            {
                get { return Cordenada2; }
                set { Cordenada2 = value; }
            }
        }

        private void barraNegra()
        {
            // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
            ApplicationBarIconButton leer = new ApplicationBarIconButton(new Uri("/Assets/leer.png", UriKind.Relative));
            leer.Text = "Leer Texto";
            ApplicationBar.Buttons.Add(leer);
            leer.Click += leer_Click;

            ApplicationBarIconButton compartir = new ApplicationBarIconButton(new Uri("//Assets/Facebook.png/", UriKind.Relative));
            compartir.Text = "Compartir";
            ApplicationBar.Buttons.Add(compartir);
            compartir.Click += compartir_Click;

        }

        void compartir_Click(object sender, EventArgs e)
        {
            ShareLinkTask task = new ShareLinkTask();

            task.Title = " !Problema¡ Calle Cerrada "+dicele+"Para Mas informacion visita";
            task.LinkUri = new Uri("http://www.uoct.cl/", UriKind.Absolute);
            task.Message = "Calle Cerrada Por Problemas";

            task.Show();
        }

       private async void leer_Click(object sender, EventArgs e)
        {
             if (lbList.Items.Count < 1)
            {
                MessageBox.Show("No Existes Desvios hoy ");
            }
            else
            {
                try
                {
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    await synth.SpeakTextAsync(dice);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        }
        }
    }