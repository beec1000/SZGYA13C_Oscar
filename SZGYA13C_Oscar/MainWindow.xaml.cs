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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
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
    }
}