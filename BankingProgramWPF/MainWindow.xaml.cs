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
        WorkProcess workProcess;
        
        public MainWindow()
        {
            InitializeComponent();
            workProcess = new WorkProcess(this);
            workProcess.Start();
            Debug.WriteLine(userWPF.Text);
            //lvWorkers.ItemsSource = workProcess.user;
            //lvWorkers.Items.Refresh();
        }

        /// <summary>
        /// СОбытие при изменении поля с выпадающим списком
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userWPF.Text == "Менеджер")
            {
                lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(Manager));
            }

            if (userWPF.Text == "Консультант")
            {
                lvWorkers.ItemsSource = workProcess.user.Where(us => us.GetType() == typeof(ConsultantUsers));
            }
        }
    }
}
