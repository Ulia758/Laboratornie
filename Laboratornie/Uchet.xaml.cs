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
    /// Логика взаимодействия для Uchet.xaml
    /// </summary>
    public partial class Uchet : Page
    {
        public Uchet()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Add_Uchet((sender as Button).DataContext as Uchetnaya));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Add_Uchet(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = UchetDG.SelectedItems.Cast<Uchetnaya>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Spravochnaya.Any(x => x.Tabelnyi_nomer == delClient.Tabelnyi_nomer))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.Uchetnaya.RemoveRange(delClients);
            try
            {
                Connect.context.SaveChanges();
                UchetDG.ItemsSource = Connect.context.Uchetnaya.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Uchetn_Loaded(object sender, RoutedEventArgs e)
        {
            UchetDG.ItemsSource = Connect.context.Uchetnaya.ToList();
        }
    }
}
