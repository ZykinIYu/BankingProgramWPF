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

        /// <summary>
        /// Клик для изменения данных пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickCreate(object sender, RoutedEventArgs e)
        {
            //string[] userChange = new string[6];
            //userChange[0] = idTB.Text;
            //userChange[1] = surnameTB.Text;
            //userChange[2] = nameTB.Text;
            //userChange[3] = middleNameTB.Text;
            //userChange[4] = phoneNumberTB.Text;
            //userChange[5] = seriesNumberPassportTB.Text;
            //string changedFields = "Изменено: ";

            //for (int i = 0; i < User.Count; i++)
            //{
            //    if (User[i].Id == Convert.ToUInt64(userChange[0]) && workProcess.User[i].GetType() == typeof(Manager))
            //    {
            //        if (workProcess.User[i].Surname != userChange[1])
            //        {
            //            if (userChange[1] == "")
            //            {
            //                MessageBox.Show("Поле \"Фамилия\" является обязательным для заполнения");
            //                break;
            //            }
            //            changedFields += "Surname";
            //        }

            //        if (workProcess.User[i].Name != userChange[2])
            //        {
            //            if (userChange[2] == "")
            //            {
            //                MessageBox.Show("Поле \"Имя\" является обязательным для заполнения");
            //                break;
            //            }
            //            changedFields += ", Name";
            //        }

            //        if (workProcess.User[i].MiddleName != userChange[3])
            //        {
            //            changedFields += ", MiddleName";
            //        }

            //        if (workProcess.User[i].PhoneNumber != userChange[4])
            //        {
            //            changedFields += ", PhoneNumber";
            //        }

            //        if (workProcess.User[i].SeriesNumberPassport != userChange[5])
            //        {
            //            changedFields += ", SeriesNumberPassport";
            //        }

            //        workProcess.ChangingParametersManager(userChange[0], userChange[1], userChange[2], userChange[3], userChange[4], userChange[5], changedFields);
            //    }
            //}

            //lvWorkers.Items.Refresh();
        }

        

        /// <summary>
        /// Клик для удаления пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickRemove(object sender, RoutedEventArgs e)
        {
            //string[] userChange = new string[1];
            //userChange[0] = idTB.Text;

            //if (userWPF.Text == "Консультант")
            //{
            //    Manager.RemoveEntry(Convert.ToUInt64(userChange[0]), workProcess.User);
            //    lvWorkers.ItemsSource = workProcess.User.Where(us => us.GetType() == typeof(Manager));
            //}

            //if (userWPF.Text == "Менеджер")
            //{
            //    MessageBox.Show("Консультанту запрещено удалять пользователей");
            //}

        }
    }
}
