using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ista.Presentacion.WPF.Demo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            NavigationController.Host = UCHost;
            this.DataContext = new NavigationController();
        }
        private void btnDialogo_Click(object sender, RoutedEventArgs e) {
            var win = new CuadroDialogo();
            win.Owner = this;
            if(win.ShowDialog() == true) {
                MessageBox.Show("Cerrada.");
            } else {
                MessageBox.Show("Cancelada.");
            }
        }

        private void btnModal_Click(object sender, RoutedEventArgs e) {
            var win = new DemoWindow();
            win.Owner = this;
            win.Show();

        }

        private void btnParalela_Click(object sender, RoutedEventArgs e) {
            var win = new DemoWindow();
            win.Show();

        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e) {
            // Configure open folder dialog box
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open folder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if(result == true) {
                // Get the selected folder
                string fullPathToFolder = dialog.FolderName;
                string folderNameOnly = dialog.SafeFolderName;
                MessageBox.Show($"fullPathToFolder: {dialog.FolderName}\nfolderNameOnly: {dialog.SafeFolderName}");
            }
        }

        private void btnAbrirPOP_Click(object sender, RoutedEventArgs e) {
            popDlg.IsOpen = true;
        }

        private void btnCerrarPOP_Click(object sender, RoutedEventArgs e) {
            popDlg.IsOpen = false;
        }

        private void btnUC1_Click(object sender, RoutedEventArgs e) {
            var uc = new DemoUserControl();
            //(uc.Content as StackPanel).DataContext = new PersonaViewModal();
            UCHost.Content = uc;
        }

        private void btnUC2_Click(object sender, RoutedEventArgs e) {
            UCHost.Content = new AjedrezWin.ucAjedrez();
        }
    }
}