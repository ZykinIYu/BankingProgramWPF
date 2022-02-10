using BankingProgram;
using BankingProgramWPF.ViewModels;
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
        public static string changedFields;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// Событие при изменении поля с выпадающим списком
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserWPFTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Convert.ToString(userWPFTypes.SelectedValue) == "Консультант")
            {
                surnameTB.IsReadOnly = true;
                nameTB.IsReadOnly = true;
                middleNameTB.IsReadOnly = true;
                seriesNumberPassportTB.IsReadOnly = true;
                phoneNumberTB.IsReadOnly = false;
                addUser.IsEnabled = false;
                create.IsEnabled = true;
                remove.IsEnabled = false;
                sortAlphabetically.IsEnabled = true;
            }

            if (Convert.ToString(userWPFTypes.SelectedValue) == "Менеджер")
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

        /// <summary>
        /// Событие при выборе в выпадающем списке пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(userWPF.SelectedValue)))
            {
                accountTypeWPF.IsEnabled = true;
                openAccountWPF.IsEnabled = true;
                removeAccountWPF.IsEnabled = true;
                TransferСustomerAccountsWPF.IsEnabled = true;
                TransferСustomerAccountsButtonWPF.IsEnabled = true;
            }

        }

        
        private void surnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.SurnameTB = surnameTB.Text;
        }

        private void nameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.NameTB = nameTB.Text;
        }

        private void middleNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.MiddleNameTB = middleNameTB.Text;
        }

        private void phoneNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.PhoneNumberTB = phoneNumberTB.Text;
        }

        private void seriesNumberPassportTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.SeriesNumberPassportTB = seriesNumberPassportTB.Text;
        }

        private void TransferСustomerAccountsWPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticData.TransferСustomerAccountsWPF = TransferСustomerAccountsWPF.Text;
        }
    }
}
