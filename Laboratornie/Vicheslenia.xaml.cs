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
    /// Логика взаимодействия для Vicheslenia.xaml
    /// </summary>
    public partial class Vicheslenia : Page
    {
        public Vicheslenia()
        {
            InitializeComponent();
            var selectClients = Connect.context.Uchetnaya.Select(x =>
            new
            {
                Uchetnaya = x,
                Spravochnaya = x.Spravochnaya,
                Sum = x.Procent_oplaty * x.Oklad / 100,
                Sumnar = x.Oklad + x.Procent_oplaty * x.Oklad / 100,
            }).ToList();
            ClientsDG.ItemsSource = selectClients;
            var gr = Connect.context.Spravochnaya.GroupBy(x => x.Data_rod).Select(g => new { Data_rod = g.Key, Count = g.Count() }).ToList();
            p2.ItemsSource = gr;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
