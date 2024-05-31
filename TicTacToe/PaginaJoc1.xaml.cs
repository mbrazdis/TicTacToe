using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for PaginaJoc1.xaml
    /// </summary>
    public partial class PaginaJoc1 : Window
    {
        public PaginaJoc1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string symbol = "";

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            symbol = radioButton.Content.ToString(); 
        }
        private void Buton_Click(object sender, RoutedEventArgs e)
        {
            StartJoc startJoc = new StartJoc(symbol);
            this.Content = startJoc;
        }
    }
}
