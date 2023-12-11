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
    /// Логика взаимодействия для Add_Sprav.xaml
    /// </summary>
    public partial class Add_Sprav : Page
    {
        Spravochnaya spr;
        bool checkNew;
        public Add_Sprav(Spravochnaya c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Spravochnaya();
                checkNew = true;
            }
            else checkNew = false;
            DataContext = spr = c;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {

                Spravochnaya spravochnaya = Connect.context.Spravochnaya.Add(spr);
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char c in nm.Text)
            {
                if (!Char.IsLetter(c))
                {
                    MessageBox.Show("Имя должно состоять только из букв", "Ошибка");
                    nm.Text = "";
                    break;
                }
            }
        }

        public static bool Check(Spravochnaya s)
        {
            if (string.IsNullOrEmpty(s.Familia)) 
                return false;
            return true;
        }
    }
}
