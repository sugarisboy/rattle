using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using RattlerCore;

namespace Rattler {
    public partial class EditStation : Window {
        public RattlerStation Station;
        public WindowType Type;
        private RattlerTransportType stationType;

        public EditStation(RattlerStation station, WindowType type) {
            InitializeComponent();
            Type = type;
            Station = Station;

            if (type == WindowType.EDIT) {
                BoxName.Text = station.name;

                BoxTram.IsEnabled = false;
                BoxMetro.IsEnabled = false;
                BoxTrain.IsEnabled = false;
                BoxExpressTrain.IsEnabled = false;

                convertFromType(station.getType()).IsChecked = true;
            }
        }

        private CheckBox convertFromType(RattlerTransportType type) {
            if (RattlerTransportType.TRAM.Equals(type))
                return BoxTram;
            else if (RattlerTransportType.METRO.Equals(type))
                return BoxMetro;
            else if (RattlerTransportType.TRAIN.Equals(type))
                return BoxTrain;
            else if (RattlerTransportType.EXPRESS_TRAIN.Equals(type))
                return BoxExpressTrain;

            return null;
        }

        private void setMetro(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = true;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = false;
            BoxComplex.IsChecked = false;
            this.stationType = RattlerTransportType.METRO;
        }

        private void setTram(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = true;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = false;
            BoxComplex.IsChecked = false;
            this.stationType = RattlerTransportType.TRAM;
        }

        private void setTrain(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = true;
            BoxExpressTrain.IsChecked = false;
            BoxComplex.IsChecked = false;
            this.stationType = RattlerTransportType.TRAIN;
        }

        private void setExpressTrain(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = true;
            BoxComplex.IsChecked = false;
            this.stationType = RattlerTransportType.EXPRESS_TRAIN;
        }

        private void setComplex(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = false;
            BoxComplex.IsChecked = true;
            this.stationType = RattlerTransportType.COMPLEX;
        }

        private void done(object sender, RoutedEventArgs e) {
            string name;

            if (BoxName.Text.Trim().Length > 0) {
                name = BoxName.Text;
            } else {
                new ErrorWindow("Ошибка в имени").Show();
                return;
            }
            
            if (Type == WindowType.CREATE) {
                if (RattlerTransportType.TRAM.Equals(stationType))
                    Station = new SimpleRattlerStation<Tram>(name, stationType);
                else if (RattlerTransportType.METRO.Equals(stationType))
                    Station = new SimpleRattlerStation<Metro>(name, stationType);
                else if (RattlerTransportType.TRAIN.Equals(stationType))
                    Station = new SimpleRattlerStation<Train>(name, stationType);
                else if (RattlerTransportType.EXPRESS_TRAIN.Equals(stationType))
                    Station = new SimpleRattlerStation<ExpressTrain>(name, stationType);
                else if (RattlerTransportType.COMPLEX.Equals(stationType))
                    Station = new ComplexRattlerStation(name);
                else {
                    new ErrorWindow("Не выбран тип транспорта!").Show();
                    return;
                }

                MainWindow.core.stationService.addStation(Station);
            } else {
                Station.name = name;
            }

            MainWindow.main.updateGrids();
            Close();
        }
    }
}