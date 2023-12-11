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
    /// Логика взаимодействия для Filtr.xaml
    /// </summary>
    public partial class Filtr : Page
    {
        public Filtr()
        {
            InitializeComponent();
            
            var selectClients = Connect.context.Spravochnaya.Where(x => x.Tabelnyi_nomer == 1 || x.Familia == "Никитин").ToList();
            p.ItemsSource = selectClients;
            var selectClient = Connect.context.Uchetnaya.Where(x => x.Month == 2 || x.Procent_oplaty == 10).ToList();
            p2.ItemsSource = selectClient;
        }

        private void Filtri_Click(object sender, RoutedEventArgs e)
        {
            int mi = Convert.ToInt32(min.Text);
            int ma = Convert.ToInt32(max.Text);
            var s = Connect.context.Uchetnaya.Where(x=> x.Oklad + x.Procent_oplaty * x.Oklad / 100 >=mi && x.Oklad + x.Procent_oplaty * x.Oklad / 100 <=ma).ToList();
            tab.ItemsSource = s;
        }
        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void BackX_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Filtri_Click_1(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(p5.SelectionBoxItem);
            int b = Convert.ToInt32(p6.SelectionBoxItem);
            var select = Connect.context.Uchetnaya.Where(x => x.Month==b && x.Spravochnaya.Tabelnyi_nomer==a).ToList();
            d.ItemsSource = select;
        }

    }
}
