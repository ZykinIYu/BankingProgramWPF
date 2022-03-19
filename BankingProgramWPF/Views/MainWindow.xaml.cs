using BankingProgram;
using BankingProgramWPF.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Clipboard = System.Windows.Clipboard;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

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
                AccountReplenishmentWPF.IsEnabled = true;
                AccountReplenishmentButtonWPF.IsEnabled = true;
                TransfersBetweenClientsWPF.IsEnabled = true;
                TransfersBetweenClientsButtonWPF.IsEnabled = true;
            }

        }

        /// <summary>
        /// Запрет ввода текста в поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phoneNumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        /// <summary>
        /// Запрет открытия контекстного меню правой кнопкой мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phoneNumberTB_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void phoneNumberTB_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V)
            {
                e.Handled = true;
                MessageBox.Show("Запрещено использовать сочетание клавиш \"CTRL + V\"");
            }

            if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Insert)
            {
                e.Handled = true;
                MessageBox.Show("Запрещено использовать сочетание клавиш \"SHIFT + INSERT\"");
            }
        }

    }
}
