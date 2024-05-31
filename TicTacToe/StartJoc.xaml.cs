using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

    public partial class StartJoc : Page
    {
        private string symbol; // Variabila pt a stoca simbolul utilizat

        public StartJoc(string symbol)
        {
            InitializeComponent();
            this.symbol = symbol; // init cu simbolul primit
            Grid = grid;
        }

        public Grid Grid { get; set; } // se acceseaza si se seteaza elementul din grid

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            // Verifica daca butonul este deja marcat
            if (button.Content != null)
                return;

            // Seteaza simbolul pe butonul dorit
            button.Content = symbol;

            // Apelam functia pentru a face calculatorul o miscare
            ComputerMove();
        }

        // aceasta functie determina calculatorul sa faca o miscare
        private void ComputerMove()
        {
            // Afla butoanele libere
            List<Button> emptyButtons = grid.Children.OfType<Button>().Where(b => b.Content == null).ToList();

            // verifica daca mai sunt butoane disponibile
            if (emptyButtons.Count > 0)
            {
                // Alege random un buton si plaseaza simbolul calculatorului
                Random random = new Random();
                Button randomButton = emptyButtons[random.Next(emptyButtons.Count)];
                randomButton.Content = symbol == "X" ? "O" : "X";
            }

            // Verifica daca exista un castigator sau tabla este plina
            if (CheckWinner() || IsBoardFull())
            {
                //string winner = symbol == "X" ? "Jucătorul X" : "Jucătorul O";
                //ShowResultMessage("Felicitări! " + winner + " a câștigat!");
                // În acest caz, resetăm jocul
                //ResetGame();
            }
        }
        private void ShowResultMessage(string message)
        {
            MessageBox.Show(message, "Rezultatul jocului", MessageBoxButton.OK);
            ResetGame();
        }
        // Funcție pentru verificarea câștigătorului
        private bool CheckWinner()
        {
            // Verifica randurile
            for (int i = 0; i < 3; i++)
            {
                if (AreEqual(btn(i, 0), btn(i, 1), btn(i, 2)))
                {
                    return true;
                }
            }

            // verifica coloanele
            for (int i = 0; i < 3; i++)
            {
                if (AreEqual(btn(0, i), btn(1, i), btn(2, i)))
                {
                    return true;
                }
            }

            // verifica diagonala principala
            if (AreEqual(btn(0, 0), btn(1, 1), btn(2, 2)))
            {
                return true;
            }

            // verifica diagonala secundara
            if (AreEqual(btn(0, 2), btn(1, 1), btn(2, 0)))
            {
                return true;
            }

            return false;
        }

        // functia care verifica daca cele 3 butoane are acelasi simbol
        private bool AreEqual(Button b1, Button b2, Button b3)
        {
            return b1.Content != null && b1.Content.Equals(b2.Content) && b2.Content.Equals(b3.Content);
        }

        // functie pentru a actiona butonul specific
        private Button btn(int row, int col)
        {
            // identificam numele butonului pe baza coordonatelor
            string buttonName = "btn" + row + col;
            return (Button)grid.FindName(buttonName);
        }

        // functie care verifica daca tabla este plina
        private bool IsBoardFull()
        {
            // iteram prin fiecare buton si vedem daca este ocupat
            foreach (var item in grid.Children)
            {
                if (item is Button button && button.Content == null)
                {
                    return false;
                }
            }
            return true;
        }

        // Functie pentru resetarea jocului
        private void ResetGame()
        {
            // Resetare toate butoanele
            foreach (var item in grid.Children)
            {
                if (item is Button button)
                {
                    button.Content = null;
                }
            }
        }
    }
}