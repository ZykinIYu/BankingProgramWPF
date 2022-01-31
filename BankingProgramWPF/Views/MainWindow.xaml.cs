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
        public static string[] staticPropertyStorageArray;
        public static string changedFields;

        public MainWindow()
        {
            InitializeComponent();
            staticPropertyStorageArray = new string[10];
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

        private void idTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[0] = idTB.Text;
        }

        private void surnameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[1] = surnameTB.Text;
        }

        private void nameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[2] = nameTB.Text;
        }

        private void middleNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[3] = middleNameTB.Text;
        }

        private void phoneNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[4] = phoneNumberTB.Text;
        }

        private void seriesNumberPassportTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[5] = seriesNumberPassportTB.Text;
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
                //moneyBalanceWPF.IsEnabled = true;
                openAccountWPF.IsEnabled = true;
                //IDRemoveAccountWPF.IsEnabled = true;
                removeAccountWPF.IsEnabled = true;
                //accountTypeWPF.IsEnabled = true;
                //accountTypeWPF.IsEnabled = true;
                //accountTypeWPF.IsEnabled = true;
                TransferСustomerAccountsWPF.IsEnabled = true;
                TransferСustomerAccountsButtonWPF.IsEnabled = true;
            }

        }

        private void IDRemoveAccountWPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[7] = IDRemoveAccountWPF.Text;
        }

        private void moneyBalanceWPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[8] = moneyBalanceWPF.Text;
        }

        private void TransferСustomerAccountsWPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            staticPropertyStorageArray[9] = TransferСustomerAccountsWPF.Text;
        }
    }
}
