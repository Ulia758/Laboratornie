using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Add_Uchet.xaml
    /// </summary>
    public partial class Add_Uchet : Page
    {
        Uchetnaya uch;
        bool checkNew;
        public Add_Uchet(Uchetnaya c)
        {
            InitializeComponent();

            if (c == null)
            {
                c = new Uchetnaya();
                checkNew = true;
            }
            else checkNew = false;
            DataContext = uch = c;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Uchetnaya uchetnaya = Connect.context.Uchetnaya.Add(uch);
            }
            try
            {
                Connect.context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void mon_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char c in mon.Text)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Месяц должен состоять только из цифр", "Ошибка");
                    mon.Text = "";
                    break;
                }
                int month = Int32.Parse(mon.Text);
                if(month<1||month>12)
                {
                    MessageBox.Show("Введите номер месяца", "Ошибка");
                    mon.Text = "";
                }
            }
        }
        public static bool Chek(Uchetnaya s)
        {
            if (string.IsNullOrEmpty(s.Tabelnyi_nomer.ToString()))
                return false;
            return true;
        }
    }
}
