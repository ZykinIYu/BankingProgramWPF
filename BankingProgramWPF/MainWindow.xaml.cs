using BankingProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private void userWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (userWPF.Text == "Менеджер")
            //{
            //    lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(Manager));
            //}

            //if (userWPF.Text == "Консультант")
            //{
            //    lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(ConsultantUsers));
            //}
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

            //if (userWPF.Text == "Консультант")
            //{
            //    for (int i = 0; i < workProcess.user.Count; i++)
            //    {
            //        if (workProcess.user[i].Id == Convert.ToUInt64(userChange[0]) && workProcess.user[i].GetType() == typeof(Manager))
            //        {
            //            if (workProcess.user[i].Surname != userChange[1])
            //            {
            //                if (userChange[1] == "")
            //                {
            //                    MessageBox.Show("Поле \"Фамилия\" является обязательным для заполнения");
            //                    break;
            //                }
            //                changedFields += "Surname";
            //            }

            //            if (workProcess.user[i].Name != userChange[2])
            //            {
            //                if (userChange[2] == "")
            //                {
            //                    MessageBox.Show("Поле \"Имя\" является обязательным для заполнения");
            //                    break;
            //                }
            //                changedFields += ", Name";
            //            }

            //            if (workProcess.user[i].MiddleName != userChange[3])
            //            {
            //                changedFields += ", MiddleName";
            //            }

            //            if (workProcess.user[i].PhoneNumber != userChange[4])
            //            {
            //                changedFields += ", PhoneNumber";
            //            }

            //            if (workProcess.user[i].SeriesNumberPassport != userChange[5])
            //            {
            //                changedFields += ", SeriesNumberPassport";
            //            }

            //            workProcess.ChangingParametersManager(userChange[0], userChange[1], userChange[2], userChange[3], userChange[4], userChange[5], changedFields);
            //        }
            //    }
            //}

            //if (userWPF.Text == "Менеджер")
            //{
            //    for (int i = 0; i < workProcess.user.Count; i++)
            //    {
            //        if (workProcess.user[i].Id == Convert.ToUInt64(userChange[0]) && workProcess.user[i].GetType() == typeof(ConsultantUsers))
            //        {
            //            if (workProcess.user[i].Surname != userChange[1])
            //            {
            //                MessageBox.Show("Консультанту разрешено вносить изменения только в номер телефона пользователя");
            //                break;
            //            }

            //            if (workProcess.user[i].Name != userChange[2])
            //            {
            //                MessageBox.Show("Консультанту разрешено вносить изменения только в номер телефона пользователя");
            //                break;
            //            }

            //            if (workProcess.user[i].MiddleName != userChange[3])
            //            {
            //                MessageBox.Show("Консультанту разрешено вносить изменения только в номер телефона пользователя");
            //                break;
            //            }

            //            if (workProcess.user[i].PhoneNumber != userChange[4])
            //            {
            //                changedFields += ", PhoneNumber";
            //            }

            //            if (workProcess.user[i].SeriesNumberPassport != userChange[5])
            //            {
            //                MessageBox.Show("Консультанту разрешено вносить изменения только в номер телефона пользователя");
            //                break;
            //            }

            //            workProcess.ChangingParametersConsultant(userChange[0], userChange[4], changedFields);
            //        }
            //    }
            //}

            //lvWorkers.Items.Refresh();
        }

        /// <summary>
        /// Клик для создания нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClickAddUser(object sender, RoutedEventArgs e)
        {
            //string[] userChange = new string[5];
            //userChange[0] = surnameTB.Text;
            //userChange[1] = nameTB.Text;
            //userChange[2] = middleNameTB.Text;
            //userChange[3] = phoneNumberTB.Text;
            //userChange[4] = seriesNumberPassportTB.Text;

            //if (userWPF.Text == "Консультант")
            //{
            //    Manager.AddEntry(workProcess.NumberId(), userChange[0], userChange[1], userChange[2], userChange[3], userChange[4], workProcess.user);
            //    lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(Manager));
            //}

            //if (userWPF.Text == "Менеджер")
            //{
            //    MessageBox.Show("Консультанту запрещено добавлять пользователей");
            //}
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
            //    Manager.RemoveEntry(Convert.ToUInt64(userChange[0]), workProcess.user);
            //    lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(Manager));
            //}

            //if (userWPF.Text == "Менеджер")
            //{
            //    MessageBox.Show("Консультанту запрещено удалять пользователей");
            //}

        }
    }
}
