using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using RattlerCore;

namespace Rattler {
    public partial class EditTransport : Window {
        public RattlerTransport Transport;
        public WindowType Type;
        private RattlerTransportType transportType;

        public EditTransport(RattlerTransport transport, WindowType type) {
            InitializeComponent();
            Type = type;
            Transport = transport;

            if (type == WindowType.EDIT) {
                BoxName.Text = transport.name;
                BoxCapacity.Text = transport.capacity.ToString();
                BoxSpeed.Text = transport.averageSpeed.ToString();

                BoxTram.IsEnabled = false;
                BoxMetro.IsEnabled = false;
                BoxTrain.IsEnabled = false;
                BoxExpressTrain.IsEnabled = false;

                convertFromType(transport.getType()).IsChecked = true;
            } else {
                BoxCapacity.Text = "0";
                BoxSpeed.Text = 0.1D.ToString();
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
            this.transportType = RattlerTransportType.METRO;
        }

        private void setTram(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = true;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = false;
            this.transportType = RattlerTransportType.TRAM;
        }

        private void setTrain(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = true;
            BoxExpressTrain.IsChecked = false;
            this.transportType = RattlerTransportType.TRAIN;
        }

        private void setExpressTrain(object sender, RoutedEventArgs e) {
            BoxTram.IsChecked = false;
            BoxMetro.IsChecked = false;
            BoxTrain.IsChecked = false;
            BoxExpressTrain.IsChecked = true;
            this.transportType = RattlerTransportType.EXPRESS_TRAIN;
        }

        private void done(object sender, RoutedEventArgs e) {
            string name;
            int capacity = 0;
            double averageSpeed = 0;

            if (BoxName.Text.Trim().Length > 0) {
                name = BoxName.Text;
            } else {
                new ErrorWindow("Ошибка в имени").Show();
                return;
            }

            try {
                var boxCapacityText = BoxCapacity.Text;
                capacity = int.Parse(boxCapacityText);
            } catch (Exception ex) {
                new ErrorWindow("Ошибка вместимости: " + ex.Message).Show();
                return;
            }

            try {
                var BoxSpeedText = BoxSpeed.Text;
                averageSpeed = double.Parse(BoxSpeedText);
            } catch (Exception ex) {
                new ErrorWindow("Ошибка ср. скорости: " + ex.Message).Show();
                return;
            }
            
            if (Type == WindowType.CREATE) {
                if (RattlerTransportType.TRAM.Equals(transportType))
                    Transport = new Tram(name);
                else if (RattlerTransportType.METRO.Equals(transportType))
                    Transport = new Tram(name);
                else if (RattlerTransportType.TRAIN.Equals(transportType))
                    Transport = new Tram(name);
                else if (RattlerTransportType.EXPRESS_TRAIN.Equals(transportType))
                    Transport = new Tram(name);
                else {
                    new ErrorWindow("Не выбран тип транспорта!").Show();
                    return;
                }

                MainWindow.core.transportService.addTransport(Transport);
            } else {
                Transport.name = name;
            }

            Transport.averageSpeed = averageSpeed;
            Transport.capacity = capacity;
            
            MainWindow.main.updateGrids();
            Close();
        }
    }
}