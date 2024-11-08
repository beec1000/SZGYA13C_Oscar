using System.IO;
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

namespace SZGYA13C_Oscar
{
    public partial class MainWindow : Window
    {
        List<Oscar> oscar = new List<Oscar>();
        public MainWindow()
        {
            InitializeComponent();
            oscar = Oscar.FromFile(@"..\..\..\src\oscar.csv");

            var oscarDijasFilmek = oscar.OrderByDescending(o => o.Dij).Select(o => new {FCim = o.Cim,FEv = o.Ev }).ToList();
            foreach (var o in oscarDijasFilmek)
            {
                oDijasFilmList.Items.Add($"{o.FCim}, {o.FEv}");
            }

        }

        private void keresettFilmTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresettFilmTB.Text != string.Empty)
            {
                placeholder1.Visibility = Visibility.Hidden;
            }
            else
            {
                placeholder1.Visibility = Visibility.Visible;
            }
        }

        private void keresettSzoTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keresettSzoTB.Text != string.Empty)
            {
                placeholder2.Visibility = Visibility.Hidden;
            }
            else
            {
                placeholder2.Visibility = Visibility.Visible;
            }
        }

        private void ujFelvetelBTN_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(cimTB.Text))
            {
                MessageBox.Show("Nincs megadva Cím!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(string.IsNullOrEmpty(evTB.Text))
            {
                MessageBox.Show("Nincs megadva Díjazási Év!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(dijTB.Text))
            {
                MessageBox.Show("Nincs megadva az Elnyert Díjak Száma!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(jelolesTB.Text))
            {
                MessageBox.Show("Nincs megadva a Jelölések Száma!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var azonosito = $"{cimTB.Text.Substring(cimTB.Text.Length - 4)}{evTB.Text.Substring(evTB.Text.Length - 2)}";
                string[] ujOscar = [$"{azonosito}\t{cimTB.Text}\t{evTB.Text}\t{dijTB.Text}\t{jelolesTB.Text}"];
                File.AppendAllLines(@"..\..\..\src\oscar.csv", ujOscar);

                MessageBox.Show("Sikeres felvétel!", "SIKER", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}