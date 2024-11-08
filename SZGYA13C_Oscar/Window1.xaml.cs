using System;
using System.Collections.Generic;
using System.IO;
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

namespace SZGYA13C_Oscar
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ujFelvetelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cimTB.Text))
            {
                MessageBox.Show("Nincs megadva Cím!", "HIBA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(evTB.Text))
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
                File.AppendAllLines(@"..\..\..\src\UJoscar.csv", ujOscar);

                MessageBox.Show("Sikeres felvétel!", "SIKER", MessageBoxButton.OK, MessageBoxImage.Information);

                cimTB.Text = string.Empty;
                evTB.Text = string.Empty;
                dijTB.Text = string.Empty;
                jelolesTB.Text = string.Empty;

                this.Close();

            }
        }
    }
}
