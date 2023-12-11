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
    /// Логика взаимодействия для Poisk.xaml
    /// </summary>
    public partial class Poisk : Page
    {
        public Poisk()
        {
            InitializeComponent();
            var selectClients = Connect.context.Spravochnaya.Where(x => x.Tabelnyi_nomer == 1 && x.Familia == "Никитин").ToList();
            p.ItemsSource = selectClients;
            var selectClient = Connect.context.Uchetnaya.Where(x => x.Month == 1 && x.Procent_oplaty == 5).ToList();
            p2.ItemsSource = selectClient;
            var select = Connect.context.Spravochnaya.Where(x => x.Data_rod < new DateTime(2000,11,04)).ToList();
            p3.ItemsSource = select;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
