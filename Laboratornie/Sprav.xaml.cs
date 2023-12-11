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
    /// Логика взаимодействия для Sprav.xaml
    /// </summary>
    public partial class Sprav : Page
    {
        public Sprav()
        {
            InitializeComponent();
        }
        private void Spravka_Loaded(object sender, RoutedEventArgs e)
        {
            SpravkaDG.ItemsSource = Connect.context.Spravochnaya.ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Add_Sprav(null));
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var delClients = SpravkaDG.SelectedItems.Cast<Spravochnaya>().ToList();
            foreach (var delClient in delClients)
                if (Connect.context.Uchetnaya.Any(x => x.Tabelnyi_nomer == delClient.Tabelnyi_nomer))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Connect.context.Spravochnaya.RemoveRange(delClients);
            }

            try
            {
                Connect.context.SaveChanges();
                SpravkaDG.ItemsSource = Connect.context.Spravochnaya.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Add_Sprav((sender as Button).DataContext as Spravochnaya));
        }
    }
}
