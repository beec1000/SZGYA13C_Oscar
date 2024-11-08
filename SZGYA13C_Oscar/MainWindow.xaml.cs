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
        List<Oscar> UJoscar = new List<Oscar>();

        public MainWindow()
        {
            InitializeComponent();
            oscar = Oscar.FromFile(@"..\..\..\src\oscar.csv");
            UJoscar = Oscar.FromFile(@"..\..\..\src\UJoscar.csv");

            var oscarDijasFilmek = oscar.OrderByDescending(o => o.Dij).Select(o => new {FCim = o.Cim,FEv = o.Ev }).ToList();
            foreach (var o in oscarDijasFilmek)
            {
                oDijasFilmList.Items.Add($"{o.FCim}, {o.FEv}");
            }

            //csak akkor frissít, amikor újraindul a window
            var UJoscarDijasFilmek = UJoscar.OrderByDescending(o => o.Dij).Select(o => new { FCim = o.Cim, FEv = o.Ev }).ToList();

            foreach (var uo in UJoscarDijasFilmek)
            {
                UJoDijasFilmList.Items.Add($"{uo.FCim}, {uo.FEv}");
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
            else if (string.IsNullOrEmpty(jelolesTB.Text))
            {
                MessageBox.Show("Nincs megadva a Jelölések Száma!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(dijTB.Text))
            {
                MessageBox.Show("Nincs megadva az Elnyert Díjak Száma!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            else
            {
                var nospace = cimTB.Text.TrimEnd();
                var azonosito = $"{nospace.Substring(nospace.Length - 4)}{evTB.Text.Substring(evTB.Text.Length - 2)}";
                string[] ujOscar = [$"{azonosito}\t{cimTB.Text}\t{evTB.Text}\t{dijTB.Text}\t{jelolesTB.Text}"];
                File.AppendAllLines(@"..\..\..\src\oscar.csv", ujOscar);

                MessageBox.Show("Sikeres felvétel!", "SIKER", MessageBoxButton.OK, MessageBoxImage.Information);

                cimTB.Text = string.Empty;
                evTB.Text = string.Empty;
                dijTB.Text = string.Empty;
                jelolesTB.Text = string.Empty;

            }
        }

        private void legtobbDijBTN_Click(object sender, RoutedEventArgs e)
        {
            var legtobbDijCim = oscar.OrderByDescending(o => o.Dij).First();

            filmCimeLB.Content = $"{legtobbDijCim.Cim}";
        }

        private void keresBTN_Click(object sender, RoutedEventArgs e)
        {
            var keresettReszlet = keresettFilmTB.Text.ToLower();

            var keresettFilm = oscar.Where(o => o.Cim.ToLower().Contains(keresettReszlet)).Select(o => o.Cim).ToList();

            if (keresettFilm.Any())
            {
                var random = new Random();
                var randomFilm = keresettFilm[random.Next(keresettFilm.Count)];
                talalatLB.Content = randomFilm;
            }
        }

        private void listazzBTN_Click(object sender, RoutedEventArgs e)
        {
            var keresettSzo = keresettSzoTB.Text.ToLower();

            var keresettFilmek = oscar.Where(o => o.Cim.ToLower().Contains(keresettSzo)).Select(o => o.Cim).ToList();

            if (keresettFilmek.Any())
            {
                list2.ItemsSource = keresettFilmek;
            }
        }

        private void UJablak_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 newWindow = new Window1();
            newWindow.Show();
        }
    }
}