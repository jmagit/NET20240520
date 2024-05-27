using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AjedrezWin {
    /// <summary>
    /// Lógica de interacción para PromocionWindow.xaml
    /// </summary>
    public partial class PromocionWindow : Window {
        public PromocionWindow() {
            InitializeComponent();
        }
        private void Seleccionar_Click(object sender, RoutedEventArgs e) {
            if(sender is RadioButton control) {
                Tag = control.Content;
                DialogResult = true;
            }
        }

    }
}
