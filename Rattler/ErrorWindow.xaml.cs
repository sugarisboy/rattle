using System.Windows;

namespace Rattler {
    public partial class ErrorWindow : Window {
        
        public ErrorWindow(string message) {
            InitializeComponent();
            Message.Text = message;
        }

        private void button_close(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}