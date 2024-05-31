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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            DateTime dataSiOraCurenta = DateTime.Now;
            MessageBox.Show($"Developer: Mihail Brazdis\n\nProfesie: Dezvoltator Profesionist de jocuri\n\nEmail: mihail.brazdis@student.ro\n\nData și ora curentă: {dataSiOraCurenta}");
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Jucătorii se alternează pentru a alege o căsuță liberă pe tablă și pentru a plasa simbolul propriu în acea căsuță.\n\n2. Primul jucător care reușește să obțină trei simboluri consecutive pe o linie, coloană sau diagonală câștigă jocul.\n\n3. Dacă toate căsuțele sunt ocupate și niciun jucător nu a reușit să obțină trei simboluri consecutive, jocul se încheie cu rezultatul de remiză.");
        }

        private void StartJoc_Click(object sender, RoutedEventArgs e)
        {
            PaginaJoc1 paginaJoc1 = new PaginaJoc1();
            paginaJoc1.Show(); 
        }
    }
}