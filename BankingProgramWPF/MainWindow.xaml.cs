using BankingProgram;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BankingProgramWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] staticArrayUserProperties;

        public MainWindow()
        {
            InitializeComponent();
            staticArrayUserProperties = new string[6];
            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// Событие при изменении поля с выпадающим списком
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Convert.ToString(userWPF.SelectedValue) == "Консультант")
            {
                surnameTB.IsReadOnly = true;
                nameTB.IsReadOnly = true;
                middleNameTB.IsReadOnly = true;
                seriesNumberPassportTB.IsReadOnly = true;
                phoneNumberTB.IsReadOnly = false;
                addUser.IsEnabled = false;
                create.IsEnabled = true;
                remove.IsEnabled = false;
                sortAlphabetically.IsEnabled = false;
            }

            if (Convert.ToString(userWPF.SelectedValue) == "Менеджер")
            {
                surnameTB.IsReadOnly = false;
                nameTB.IsReadOnly = false;
                middleNameTB.IsReadOnly = false;
                seriesNumberPassportTB.IsReadOnly = false;
                phoneNumberTB.IsReadOnly = false;
                addUser.IsEnabled = true;
                create.IsEnabled = true;
                remove.IsEnabled = true;
                sortAlphabetically.IsEnabled = true;
            }
        }

        private void idTB_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            staticArrayUserProperties[0] = idTB.Text;
        }

        private void surnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticArrayUserProperties[1] = surnameTB.Text;
        }

        private void nameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticArrayUserProperties[2] = nameTB.Text;
        }

        private void middleNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticArrayUserProperties[3] = middleNameTB.Text;
        }

        private void phoneNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticArrayUserProperties[4] = phoneNumberTB.Text;
        }

        private void seriesNumberPassportTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticArrayUserProperties[5] = seriesNumberPassportTB.Text;
        }

        
    }
}
