using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using RattlerCore;

namespace Rattler {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public static RattlerCore.RattlerCore core;
        public static MainWindow main;
        public ObservableCollection<RattlerTransportType> AllTypes { get; set; }


        public MainWindow() {
            InitializeComponent();
            main = this;

            try {
                core = new RattlerCore.RattlerCore();

                TransportGrid.ItemsSource = core.store.transports;
                TransportGrid.AutoGenerateColumns = false;

                StationGrid.ItemsSource = core.store.stations;
                StationGrid.AutoGenerateColumns = false;

                TransportGrid.Visibility = Visibility.Hidden;
                StationGrid.Visibility = Visibility.Hidden;

                ButtonDelete.IsEnabled = false;
                ButtondEdit.IsEnabled = false;

                AllTypes = new ObservableCollection<RattlerTransportType>() {
                    RattlerTransportType.TRAM,
                    RattlerTransportType.METRO,
                    RattlerTransportType.TRAIN,
                    RattlerTransportType.EXPRESS_TRAIN
                };
            } catch (Exception e) {
                new ErrorWindow(e.Message).Show();
            }
        }

        private void show_station(object sender, RoutedEventArgs e) {
            TransportGrid.Visibility = Visibility.Hidden;
            StationGrid.Visibility = Visibility.Visible;
        }

        private void show_transport(object sender, RoutedEventArgs e) {
            StationGrid.Visibility = Visibility.Hidden;
            TransportGrid.Visibility = Visibility.Visible;
        }

        private void selectTransport(object sender, SelectedCellsChangedEventArgs e) {
            RattlerTransport transport = TransportGrid.SelectedItem as RattlerTransport;
            ButtondEdit.IsEnabled = ButtonDelete.IsEnabled = true;
        }

        private void selectStation(object sender, SelectedCellsChangedEventArgs e) {
            RattlerStation transport = TransportGrid.SelectedItem as RattlerStation;
            ButtondEdit.IsEnabled = ButtonDelete.IsEnabled = true;
        }

        private void delete(object sender, RoutedEventArgs e) {
            try {
                if (TransportGrid.Visibility == Visibility.Visible && TransportGrid.SelectedItem != null) {
                    RattlerTransport transport = TransportGrid.SelectedItem as RattlerTransport;
                    core.transportService.removeTransport(transport);
                } else if (StationGrid.Visibility == Visibility.Visible && StationGrid.SelectedItem != null) {
                    RattlerStation station = StationGrid.SelectedItem as RattlerStation;
                    core.stationService.removeStation(station);
                }
            } catch (Exception ex) {
                new ErrorWindow(ex.Message).Show();
            }

            updateGrids();
        }

        private void edit(object sender, RoutedEventArgs e) {
            try {
                if (TransportGrid.Visibility == Visibility.Visible && TransportGrid.SelectedItem != null) {
                    RattlerTransport transport = TransportGrid.SelectedItem as RattlerTransport;
                    new EditTransport(transport, WindowType.EDIT).Show();
                } else if (StationGrid.Visibility == Visibility.Visible && StationGrid.SelectedItem != null) {
                    RattlerStation transport = StationGrid.SelectedItem as RattlerStation;
                    new EditStation(transport, WindowType.EDIT).Show();
                }
            } catch (Exception ex) {
                new ErrorWindow(ex.Message).Show();
            }
        }

        public void updateGrids() {
            TransportGrid.ItemsSource = null;
            StationGrid.ItemsSource = null;

            TransportGrid.ItemsSource = core.store.transports;
            StationGrid.ItemsSource = core.store.stations;
        }

        private void updateGrids(object sender, RoutedEventArgs routedEventArgs) {
            updateGrids();
        }

        private void addTransport(object sender, RoutedEventArgs e) {
            new EditTransport(null, WindowType.CREATE).Show();
        }

        private void addStation(object sender, RoutedEventArgs e) {
            new EditStation(null, WindowType.CREATE).Show();
        }

        private void save(object sender, RoutedEventArgs e) {
            core.save();
        }
        private void disable(object sender, RoutedEventArgs e) {
            core.disable();
            this.Close();
        }
    }
}