﻿#pragma checksum "C:\Users\Jorge\Documents\Visual Studio 2013\Projects\calleCerradApp\calleCerradApp\mapa.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8A8F9294B90E229CE94F2CBB5FA70878"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18449
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace calleCerradApp {
    
    
    public partial class mapa : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Maps.Controls.Map mapaCalle;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/calleCerradApp;component/mapa.xaml", System.UriKind.Relative));
            this.mapaCalle = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("mapaCalle")));
        }
    }
}

