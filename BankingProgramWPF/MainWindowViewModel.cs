using BankingProgram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace BankingProgramWPF
{
    class MainWindowViewModel : INotifyPropertyChanged/*, ICommand*/
    {
        //Список пользователей
        private List<Users> user;
        public List<Users> User 
        {
            get 
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        //Промежуточный список пользователей
        private List<Users> userIntermediateValue;
        public List<Users> UserIntermediateValue
        {
            get
            {
                return userIntermediateValue;
            }
            set
            {
                userIntermediateValue = value;
                OnPropertyChanged("UserIntermediateValue");
            }
        }

        //Для кого предназначены пользователи, тип пользователя
        public List<string> UserTypes { get; set; } = new List<string> { "Консультант", "Менеджер" };

        //Свойство для заполнения списка пользователей
        private string selectedUserWPF;
        public string SelectedUserWPF
        {
            get
            {
                return selectedUserWPF;
            }
            set
            {
                UserIntermediateValue = User;
                selectedUserWPF = value;
                if (value == "Менеджер")
                {
                    UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                }

                if (value == "Консультант")
                {
                    UserIntermediateValue = User.Where(us => us.GetType() == typeof(ConsultantUsers)).ToList();
                }
                OnPropertyChanged("SelectedUserWPF");
            }
        }

        private ulong id;
        private Random randomize;

        //связка для просмотра параметров пользователя
        private Users selectedUser;
        public Users SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }



        /// <summary>
        /// Старт программы
        /// </summary>
        public MainWindowViewModel()
        {
            User = new List<Users>();
            randomize = new Random();
            FillingCollectionWithUsers();
        }

        /// <summary>
        /// Метод для наполнения коллекции пользователями
        /// </summary>
        public void FillingCollectionWithUsers()
        {
            for (int i = 0; i < 21; i++)
            {
                var userPhoneNumber = Convert.ToString(80000000000 + randomize.Next(800000000, 900000000));
                var userSeriesNumberPassport = Convert.ToString(1000000000 + randomize.Next(100000000, 999999999));
                var userDateTimeNow = DateTime.Now;
                User.Add(new ConsultantUsers($"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "Менеджер", true));
                User.Add(new Manager($"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "Менеджер", false));
            }
        }

        /// <summary>
        /// Изменение параметров пользователей под ролью консультанта
        /// </summary>
        public void ChangingParametersConsultant(string CorrectedUser, string NewPhoneNumber, string CF)
        {
            for (; ; )
            {
                for (int i = 0; i < User.Count; i++)
                {
                    if (User[i].Id == Convert.ToUInt64(CorrectedUser) && User[i].GetType() == typeof(ConsultantUsers))
                    {
                        User[i].СhangedFields = CF;
                        User[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), User[i].Surname, User[i].Name, User[i].MiddleName, NewPhoneNumber, User[i].SeriesNumberPassport, User);
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Изменение параметров пользователей под ролью менеджера
        /// </summary>
        public void ChangingParametersManager(string CorrectedUser, string NewSurname, string NewName, string NewMiddleName, string NewPhoneNumber, string NewSeriesNumberPassport, string CF)
        {
            for (; ; )
            {
                for (int i = 0; i < User.Count; i++)
                {
                    if (User[i].Id == Convert.ToUInt64(CorrectedUser) && User[i].GetType() == typeof(Manager))
                    {
                        User[i].СhangedFields = CF;
                        User[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), NewSurname, NewName, NewMiddleName, NewPhoneNumber, NewSeriesNumberPassport, User);

                        for (int j = 0; j < User.Count; j++)
                        {
                            if (User[j].Id == Convert.ToUInt64(CorrectedUser) && User[j].GetType() == typeof(ConsultantUsers))
                            {
                                User[j].SeriesNumberPassport = $"**********";
                            }
                        }
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Печать списка пользователей в документы
        /// </summary>
        private void PrintDocument()
        {
            using (StreamWriter sw = new StreamWriter("consultant.csv", false, Encoding.Unicode))
            {
                sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
                for (int i = 0; i < User.Count; i++)
                {
                    if (User[i].GetType() == typeof(ConsultantUsers))
                    {
                        sw.WriteLine(User[i].Print());
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter("manager.csv", false, Encoding.Unicode))
            {
                sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
                for (int i = 0; i < User.Count; i++)
                {
                    if (User[i].GetType() == typeof(Manager))
                    {
                        sw.WriteLine(User[i].Print());
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        // команда добавления нового пользователя 
        private RelayCommand addUser;
        public RelayCommand AddUser
        {
            get
            {
                return addUser ??
                  (addUser = new RelayCommand(obj =>
                  {
                      var date = DateTime.Now;
                      if (string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[1]) || string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[2]) || string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[2]))
                      {
                          MessageBox.Show("Необходимо заполнить обязательные поля: Фамилия, Имя, отчество");
                      }
                      else
                      {
                          ConsultantUsers cu = new ConsultantUsers($"{MainWindow.staticArrayUserProperties[1]}", $"{MainWindow.staticArrayUserProperties[2]}", $"{MainWindow.staticArrayUserProperties[3]}", $"{MainWindow.staticArrayUserProperties[4]}", $"{MainWindow.staticArrayUserProperties[5]}", date, "-", "Добавлена новая запись", "Менеджер", true);
                          Manager m = new Manager($"{MainWindow.staticArrayUserProperties[1]}", $"{MainWindow.staticArrayUserProperties[2]}", $"{MainWindow.staticArrayUserProperties[3]}", $"{MainWindow.staticArrayUserProperties[4]}", $"{MainWindow.staticArrayUserProperties[5]}", date, "-", "Добавлена новая запись", "Менеджер", false);
                          User.Add(cu);
                          User.Add(m);
                          SelectedUser = cu;
                          SelectedUser = m;
                      }
                      UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                  }));
            }
        }

        // команда редактирования пользователя 
        private RelayCommand editUser;
        public RelayCommand EditUser
        {
            get
            {
                return editUser ??
                  (editUser = new RelayCommand(obj =>
                  {
                      var date = DateTime.Now;
                      MainWindow.changedFields = "Изменено: ";
                      if (string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[1]) || string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[2]) || string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[2]))
                      {
                          MessageBox.Show($"Необходимо выбрать пользователя и заполнить обязательные поля: Фамилия, Имя, отчество");
                      }
                      else
                      {
                          if (selectedUserWPF == "Менеджер")
                          {
                              for (int i = 0; i < user.Count; i++)
                              {
                                  if (user[i].Id == Convert.ToUInt64(MainWindow.staticArrayUserProperties[0]) && user[i].GetType() == typeof(Manager))
                                  {
                                      if (user[i].Surname != MainWindow.staticArrayUserProperties[1])
                                      {
                                          MainWindow.changedFields += "Surname";
                                      }

                                      if (user[i].Name != MainWindow.staticArrayUserProperties[2])
                                      {
                                          MainWindow.changedFields += ", Name";
                                      }

                                      if (user[i].MiddleName != MainWindow.staticArrayUserProperties[3])
                                      {
                                          MainWindow.changedFields += ", MiddleName";
                                      }

                                      if (user[i].PhoneNumber != MainWindow.staticArrayUserProperties[4])
                                      {
                                          MainWindow.changedFields += ", PhoneNumber";
                                      }

                                      if (user[i].SeriesNumberPassport != MainWindow.staticArrayUserProperties[5])
                                      {
                                          MainWindow.changedFields += ", SeriesNumberPassport";
                                      }

                                      ChangingParametersManager(MainWindow.staticArrayUserProperties[0], MainWindow.staticArrayUserProperties[1], MainWindow.staticArrayUserProperties[2], MainWindow.staticArrayUserProperties[3], MainWindow.staticArrayUserProperties[4], MainWindow.staticArrayUserProperties[5], MainWindow.changedFields);
                                  }
                              }
                              UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                          }

                          if (selectedUserWPF == "Консультант")
                          {
                              for (int i = 0; i < user.Count; i++)
                              {
                                  if (user[i].Id == Convert.ToUInt64(MainWindow.staticArrayUserProperties[0]) && user[i].GetType() == typeof(ConsultantUsers))
                                  {
                                      if (user[i].PhoneNumber != MainWindow.staticArrayUserProperties[4])
                                      {
                                          MainWindow.changedFields += "PhoneNumber";
                                      }
                                      ChangingParametersConsultant(MainWindow.staticArrayUserProperties[0], MainWindow.staticArrayUserProperties[4], MainWindow.changedFields);
                                  }
                              }
                              UserIntermediateValue = User.Where(us => us.GetType() == typeof(ConsultantUsers)).ToList();
                          }
                      }
                  }));
            }
        }

        // команда удаления пользователя
        private RelayCommand deleteUser;

        public RelayCommand DeleteUser
        {
            get
            { 
                return deleteUser ??
                    (deleteUser = new RelayCommand(obj =>
                    {
                        if (string.IsNullOrEmpty(MainWindow.staticArrayUserProperties[0]))
                        {
                            MessageBox.Show($"Необходимо выбрать пользователя для удаления");
                        }
                        else
                        {
                            Manager.RemoveEntry(Convert.ToUInt64(MainWindow.staticArrayUserProperties[0]), user);
                        }
                        UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                    }));
            }
        }
    }
}
