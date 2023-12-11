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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratornie
{
    /// <summary>
    /// Логика взаимодействия для Sortirovka.xaml
    /// </summary>
    public partial class Sortirovka : Page
    {
        public Sortirovka()
        {
            InitializeComponent();
            var selectClients = Connect.context.Spravochnaya.OrderBy(x => x.Data_rod).ToList();
            ClientsDG.ItemsSource = selectClients;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
