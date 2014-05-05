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
using System.Device.Location;
using Appacitive.Sdk;

namespace Push
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            txtChannel.TextChanged += txtChannel_TextChanged;
        }

        void txtChannel_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSetChannel.IsEnabled = txtChannel.Text.Trim().Length > 0;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if ((AppContext.DeviceContext == null || AppContext.DeviceContext.CurrentDevice == null) && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                return;
            }
            //hide the progress bar
            progress.Visibility = System.Windows.Visibility.Collapsed;
            
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            //get the device location
            LocateDevice();
        }

        private void LocateDevice()
        {
            var watcher = new GeoCoordinateWatcher();
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default)
            {
                MovementThreshold = 100 //100 meters
            };

            watcher.StatusChanged += this.watcher_StatusChanged;
            watcher.Start();
        }

        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    MessageBox.Show("Your location service is turned off. Please go in settings and turn it ON.", "Location service is Off", MessageBoxButton.OK);
                    break;
                case GeoPositionStatus.Ready:
                    ((GeoCoordinateWatcher)sender).PositionChanged += this.watcher_PositionChanged;
                    break;
            }
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var epl = e.Position.Location;
            txtLat.Text = epl.Latitude.ToString();
            txtLon.Text = epl.Longitude.ToString();
        }
    }
}