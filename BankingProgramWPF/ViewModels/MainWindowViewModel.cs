using BankingProgram;
using BankingProgramWPF.Models;
using BankingProgramWPF.ViewModels;
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
    class MainWindowViewModel : Bindable
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        private List<IUsers> user;

        /// <summary>
        /// Свойство списка пользователей
        /// </summary>
        public List<IUsers> User 
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

        /// <summary>
        /// Список пользователей
        /// </summary>
        private List<Accounts<ulong, string, ulong>> accounts;

        /// <summary>
        /// Свойство списка пользователей
        /// </summary>
        public List<Accounts<ulong, string, ulong>> Accounts
        {
            get { return accounts; }
            set
            {
                accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        /// <summary>
        /// Список пользователей промежуточный
        /// </summary>
        private List<Accounts<ulong, string, ulong>> accountsIntermediateValue;

        /// <summary>
        /// Свойство списка пользователей промежуточного
        /// </summary>
        public List<Accounts<ulong, string, ulong>> AccountsIntermediateValue
        {
            get { return accountsIntermediateValue; }
            set
            {
                accountsIntermediateValue = value;
                OnPropertyChanged("AccountsIntermediateValue");
            }
        }

        /// <summary>
        /// Список пользователей промежуточный
        /// </summary>
        private List<Accounts<ulong, string, ulong>> accountsIntermediateValue2;

        /// <summary>
        /// Свойство списка пользователей промежуточного
        /// </summary>
        public List<Accounts<ulong, string, ulong>> AccountsIntermediateValue2
        {
            get { return accountsIntermediateValue2; }
            set
            {
                accountsIntermediateValue2 = value;
                OnPropertyChanged("AccountsIntermediateValue2");
            }
        }

        //Промежуточный список пользователей
        private List<IUsers> userIntermediateValue;
        public List<IUsers> UserIntermediateValue
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

        //Список клиентов
        private List<IUsers> userList;

        //Свойство списка клиентов
        public List<IUsers> UserList
        {
            get
            {
                return userList.Where(ul => ul.GetType() == typeof(Manager)).ToList();
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

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

        /// <summary>
        /// заплнение списка счетов в WPF
        /// </summary>
        private string selectedAccountsWPF;

        /// <summary>
        /// свойство заплнения списка счетов в WPF
        /// </summary>
        public string SelectedAccountsWPF
        {
            get { return selectedAccountsWPF; }
            set
            {
                accountsIntermediateValue = accounts;
            }
        }

        /// <summary>
        /// Тип счета
        /// </summary>
        public List<string> AccountsTypes { get; set; } = new List<string> { Convert.ToString((EnamAccountType)0), Convert.ToString((EnamAccountType)1) };

        private ulong id;
        private Random randomize;

        //связка для просмотра параметров пользователя
        private IUsers selectedUser;
        public IUsers SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        //Чтение поля с Фамилией
        private string selectedSurname;
        public string SelectedSurname
        {
            get { return selectedSurname; }
            set
            {
                selectedSurname = value;
                OnPropertyChanged("SelectedSurname");
            }
        }

        /// <summary>
        /// Выбор пользователя и его счетов
        /// </summary>
        private IUsers selectedAccounts;

        /// <summary>
        /// Свойство пользователя и его счетов
        /// </summary>
        public IUsers SelectedAccounts
        {
            get { return selectedAccounts; }
            set
            {
                selectedAccounts = value;
                AccountsIntermediateValue = Accounts.Where(a => value.Id == a.IdUser).ToList();
                AccountsIntermediateValue2 = Accounts.Where(a => value.Id != a.IdUser).ToList();
                OnPropertyChanged("SelectedAccounts");
            }
        }

        /// <summary>
        /// Выбор типа счета
        /// </summary>
        private string selectedTypeAccounts;

        /// <summary>
        /// Свойство выбора типа счета
        /// </summary>
        public string SelectedTypeAccounts
        {
            get
            {
                return selectedTypeAccounts;
            }
            set
            {
                selectedTypeAccounts = value;
                //if (value == "Недепозитный")
                //{
                //    MainWindow.staticPropertyStorageArray[6] = "Недепозитный";
                //}

                //if (value == "Депозитный")
                //{
                //    MainWindow.staticPropertyStorageArray[6] = "Депозитный";
                //}
                OnPropertyChanged("SelectedUserWPF");
            }
        }

        /// <summary>
        /// выбор счета
        /// </summary>
        private Accounts<ulong, string, ulong> selectedAccountList;

        /// <summary>
        /// Свойство выбора счета
        /// </summary>
        public Accounts<ulong, string, ulong> SelectedAccountList
        {
            get { return selectedAccountList; }
            set
            {
                selectedAccountList = value;
                OnPropertyChanged("SelectedAccountList");
            }
        }

        /// <summary>
        /// выбор счета клиента
        /// </summary>
        private Accounts<ulong, string, ulong> selectedAccountList2;

        /// <summary>
        /// Свойство выбора счета клиента
        /// </summary>
        public Accounts<ulong, string, ulong> SelectedAccountList2
        {
            get { return selectedAccountList2; }
            set
            {
                selectedAccountList2 = value;
                OnPropertyChanged("SelectedAccountList2");
            }
        }



        /// <summary>
        /// Старт программы
        /// </summary>
        public MainWindowViewModel()
        {
            User = new List<IUsers>();
            UserList = new List<IUsers>();
            Accounts = new List<Accounts<ulong, string, ulong>>();
            AccountsIntermediateValue = new List<Accounts<ulong, string, ulong>>();
            randomize = new Random();
            FillingCollectionWithUsers();
            FillingCollectionWithAccount();
            UserList = User;
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
        /// Метод для наполнения коллекции счетами
        /// </summary>
        public void FillingCollectionWithAccount()
        {
            for (ulong i = 1; i < 21; i++)
            {
                Accounts.Add(new Accounts<ulong, string, ulong>(i, Convert.ToString((EnamAccountType)0), Convert.ToUInt64(randomize.Next(0, 100000))));
                Accounts.Add(new Accounts<ulong, string, ulong>(i, Convert.ToString((EnamAccountType)1), Convert.ToUInt64(randomize.Next(0, 100000))));
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
                      if (string.IsNullOrEmpty(SurnameTranslate) || string.IsNullOrEmpty(NameTranslate) || string.IsNullOrEmpty(MiddleNameTranslate))
                      {
                          MessageBox.Show("Необходимо заполнить обязательные поля: Фамилия, Имя, отчество");
                      }
                      else
                      {
                          ConsultantUsers cu = new ConsultantUsers($"{SurnameTranslate}", $"{NameTranslate}", $"{MiddleNameTranslate}", $"{PhoneNumberTranslate}", $"{SeriesNumberPassportTranslate}", date, "-", "Добавлена новая запись", "Менеджер", true);
                          Manager m = new Manager($"{SurnameTranslate}", $"{NameTranslate}", $"{MiddleNameTranslate}", $"{PhoneNumberTranslate}", $"{SeriesNumberPassportTranslate}", date, "-", "Добавлена новая запись", "Менеджер", false);
                          User.Add(cu);
                          User.Add(m);
                          SelectedUser = cu;
                          SelectedUser = m;
                      }
                      UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                      UserList = User;
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
                      //if (string.IsNullOrEmpty(SelectedUser.Surname) || string.IsNullOrEmpty(SelectedUser.Name) || string.IsNullOrEmpty(SelectedUser.MiddleName))
                      //{
                      //    MessageBox.Show($"Необходимо выбрать пользователя и заполнить обязательные поля: Фамилия, Имя, отчество");
                      //}
                      //else
                      //{
                      //    if (selectedUserWPF == "Менеджер")
                      //    {
                      //        for (int i = 0; i < user.Count; i++)
                      //        {
                      //            if (user[i].Id == SelectedUser.Id && user[i].GetType() == typeof(Manager))
                      //            {
                      //                if (user[i].Surname != SurnameTranslate)
                      //                {
                      //                    MainWindow.changedFields += "Surname";
                      //                }

                      //                if (user[i].Name != NameTranslate)
                      //                {
                      //                    MainWindow.changedFields += ", Name";
                      //                }

                      //                if (user[i].MiddleName != MiddleNameTranslate)
                      //                {
                      //                    MainWindow.changedFields += ", MiddleName";
                      //                }

                      //                if (user[i].PhoneNumber != PhoneNumberTranslate)
                      //                {
                      //                    MainWindow.changedFields += ", PhoneNumber";
                      //                }

                      //                if (user[i].SeriesNumberPassport != SeriesNumberPassportTranslate)
                      //                {
                      //                    MainWindow.changedFields += ", SeriesNumberPassport";
                      //                }

                      //                ChangingParametersManager(Convert.ToString(SelectedUser.Id), SurnameTranslate, NameTranslate, MiddleNameTranslate, PhoneNumberTranslate, SeriesNumberPassportTranslate, MainWindow.changedFields);
                      //            }
                      //        }
                      //        UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                      //        UserList = User;
                      //    }

                      //    if (selectedUserWPF == "Консультант")
                      //    {
                      //        for (int i = 0; i < user.Count; i++)
                      //        {
                      //            if (user[i].Id == Convert.ToUInt64(SelectedUser.Id) && user[i].GetType() == typeof(ConsultantUsers))
                      //            {
                      //                if (user[i].PhoneNumber != SelectedUser.PhoneNumber)
                      //                {
                      //                    MainWindow.changedFields += "PhoneNumber";
                      //                }
                      //                ChangingParametersConsultant(Convert.ToString(SelectedUser.Id), PhoneNumberTranslate, MainWindow.changedFields);
                      //            }
                      //        }
                      //        UserIntermediateValue = User.Where(us => us.GetType() == typeof(ConsultantUsers)).ToList();
                      //        UserList = User;
                      //    }
                      //}

                      try
                      {
                          if (string.IsNullOrEmpty(SelectedUser.Surname) || string.IsNullOrEmpty(SelectedUser.Name) || string.IsNullOrEmpty(SelectedUser.MiddleName))
                          {
                              MessageBox.Show($"Необходимо выбрать пользователя и заполнить обязательные поля: Фамилия, Имя, отчество");
                          }
                          else
                          {
                              if (selectedUserWPF == "Менеджер")
                              {
                                  for (int i = 0; i < user.Count; i++)
                                  {
                                      if (user[i].Id == SelectedUser.Id && user[i].GetType() == typeof(Manager))
                                      {
                                          if (user[i].Surname != SurnameTranslate)
                                          {
                                              MainWindow.changedFields += "Surname";
                                          }

                                          if (user[i].Name != NameTranslate)
                                          {
                                              MainWindow.changedFields += ", Name";
                                          }

                                          if (user[i].MiddleName != MiddleNameTranslate)
                                          {
                                              MainWindow.changedFields += ", MiddleName";
                                          }

                                          if (user[i].PhoneNumber != PhoneNumberTranslate)
                                          {
                                              MainWindow.changedFields += ", PhoneNumber";
                                          }

                                          if (user[i].SeriesNumberPassport != SeriesNumberPassportTranslate)
                                          {
                                              MainWindow.changedFields += ", SeriesNumberPassport";
                                          }

                                          ChangingParametersManager(Convert.ToString(SelectedUser.Id), SurnameTranslate, NameTranslate, MiddleNameTranslate, PhoneNumberTranslate, SeriesNumberPassportTranslate, MainWindow.changedFields);
                                      }
                                  }
                                  UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                                  UserList = User;
                              }

                              if (selectedUserWPF == "Консультант")
                              {
                                  for (int i = 0; i < user.Count; i++)
                                  {
                                      if (user[i].Id == Convert.ToUInt64(SelectedUser.Id) && user[i].GetType() == typeof(ConsultantUsers))
                                      {
                                          if (user[i].PhoneNumber != SelectedUser.PhoneNumber)
                                          {
                                              MainWindow.changedFields += "PhoneNumber";
                                          }
                                          ChangingParametersConsultant(Convert.ToString(SelectedUser.Id), PhoneNumberTranslate, MainWindow.changedFields);
                                      }
                                  }
                                  UserIntermediateValue = User.Where(us => us.GetType() == typeof(ConsultantUsers)).ToList();
                                  UserList = User;
                              }
                          }
                      }
                      catch (NullReferenceException)
                      {
                          MessageBox.Show($"Необходимо выбрать пользователя и заполнить обязательные поля: Фамилия, Имя, отчество");
                      }

                  }));
            }
        }

        // команда удаления пользователя
        private RelayCommand deleteUser;

        //параметр команды удаления пользователей
        public RelayCommand DeleteUser
        {
            get
            { 
                return deleteUser ??
                    (deleteUser = new RelayCommand(obj =>
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(SelectedUser.Id)))
                        {
                            MessageBox.Show($"Необходимо выбрать пользователя для удаления");
                        }
                        else
                        {
                            Manager.RemoveEntry(Convert.ToUInt64(SelectedUser.Id), user);
                        }
                        UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                        UserList = User;
                    }));
            }
        }

        //команда сортировки по фамилии пользователя
        private RelayCommand sortSurnameUser;

        //параметр команды сортировки
        public RelayCommand SortSurnameUser
        {
            get
            {
                return sortSurnameUser ??
                    (sortSurnameUser = new RelayCommand(obj =>
                    {
                        user.Sort();
                        UserIntermediateValue = User.Where(us => us.GetType() == typeof(Manager)).ToList();
                    }));
            }
        }

        /// <summary>
        /// Команда добавления счета
        /// </summary>
        private RelayCommand addAccounts;

        /// <summary>
        /// Свойство команды добавления счета
        /// </summary>
        public RelayCommand AddAccounts
        {
            get
            {
                return addAccounts ??
                  (addAccounts = new RelayCommand(obj =>
                  {
                      if (string.IsNullOrEmpty(selectedTypeAccounts))
                      {
                          MessageBox.Show("Необходимо выбрать тип создаваемого счета");
                      }
                      else
                      {
                          if (Accounts.Exists(ac => ac.IdUser == SelectedAccounts.Id && ac.AccountType == selectedTypeAccounts))
                          {
                              MessageBox.Show($"{selectedTypeAccounts} счет уже открыт, нельзя еще раз его открыть");
                          }
                          else
                          {
                              Accounts<ulong, string, ulong> a = new Accounts<ulong, string, ulong>(SelectedAccounts.Id, $"{selectedTypeAccounts}", 0);
                              Accounts.Add(a);
                              SelectedAccountList = a;
                          }                          
                      }
                      AccountsIntermediateValue = Accounts.Where(a => SelectedAccounts.Id == a.IdUser).ToList();
                  }));
            }
        }

        /// <summary>
        /// Команда удаления счета
        /// </summary>
        private RelayCommand removeAccounts;

        /// <summary>
        /// Свойство команды удаления счета
        /// </summary>
        public RelayCommand RemoveAccounts
        {
            get
            {
                return removeAccounts ??
                  (removeAccounts = new RelayCommand(obj =>
                  {
                      if (SelectedAccountList.IdAccounts == 0)
                      {
                          MessageBox.Show("Необходимо выбрать счет для закрытия");
                      }
                      else
                      {
                          if (Accounts.Exists(ac => ac.MoneyBalance == 0))
                          {
                              Accounts.RemoveAll(ra => ra.IdAccounts == SelectedAccountList.IdAccounts);
                          }
                          else
                          {
                              MessageBox.Show($"счет с ID = {SelectedAccountList.IdAccounts} имеет баланс: {SelectedAccountList.MoneyBalance}, необходимо сначала перевести на другой счет, а потом закрывать");
                          }
                      }
                      AccountsIntermediateValue = Accounts.Where(a => SelectedAccounts.Id == a.IdUser).ToList();
                  }));
            }
        }

        /// <summary>
        /// Команда перевода между счетами клиент
        /// </summary>
        private RelayCommand transferСustomerAccounts;

        /// <summary>
        /// Свойство команды перевода между счетами клиент
        /// </summary>
        public RelayCommand TransferСustomerAccounts
        {
            get
            {
                return transferСustomerAccounts ??
                  (transferСustomerAccounts = new RelayCommand(obj =>
                  {


                      if (string.IsNullOrEmpty(Convert.ToString(SelectedAccountList.IdAccounts)))
                      {
                          MessageBox.Show("Необходимо выбрать счет с которого будут сняты средства и указать сумму перевода");
                      }
                      else
                      {
                          if (Convert.ToUInt64(SelectedAccountList.MoneyBalance) >= Convert.ToUInt64(TransferСustomerAccountsTranslate))
                          {
                              Accounts.FindAll(ac => ac.IdAccounts == SelectedAccountList.IdAccounts).ForEach(ac => ac.MoneyBalance -= Convert.ToUInt64(TransferСustomerAccountsTranslate));
                              Accounts.FindAll(ac => ac.IdUser == SelectedAccounts.Id && ac.IdAccounts != SelectedAccountList.IdAccounts).ForEach(ac => ac.MoneyBalance += Convert.ToUInt64(TransferСustomerAccountsTranslate));
                          }
                          else
                          {
                              MessageBox.Show("Невозможно со счета снять денег больше чем там есть");
                          }
                      }
                      AccountsIntermediateValue = Accounts.Where(a => SelectedAccounts.Id == a.IdUser).ToList();
                  }));
            }
        }

        /// <summary>
        /// Команда зачисления средств на счет
        /// </summary>
        private RelayCommand accountReplenishmentButton;

        /// <summary>
        /// Свойство команды зачисления средств на счет
        /// </summary>
        public RelayCommand AccountReplenishmentButton
        {
            get
            {
                return accountReplenishmentButton ??
                  (accountReplenishmentButton = new RelayCommand(obj =>
                  {
                      if (string.IsNullOrEmpty(Convert.ToString(SelectedAccountList.IdAccounts)))
                      {
                          MessageBox.Show("Необходимо выбрать счет на который будут зачислены средства");
                      }
                      else
                      {
                          if (string.IsNullOrEmpty(Convert.ToString(accountReplenishment)))
                          {
                              MessageBox.Show("Необходимо указать сумму к зачислению");
                          }
                          else
                          {
                              Accounts.FindAll(ac => ac.IdAccounts == SelectedAccountList.IdAccounts).ForEach(ac => ac.MoneyBalance += Convert.ToUInt64(AccountReplenishment));
                          }
                      }
                      AccountsIntermediateValue = Accounts.Where(a => SelectedAccounts.Id == a.IdUser).ToList();
                  }));
            }
        }

        /// <summary>
        /// Команда перевода средств между клиентами
        /// </summary>
        private RelayCommand commandTransfersBetweenClientsWPF;

        /// <summary>
        /// Свойство команды перевода средств между клиентами
        /// </summary>
        public RelayCommand CommandTransfersBetweenClientsWPF
        {
            get
            {
                return commandTransfersBetweenClientsWPF ??
                  (commandTransfersBetweenClientsWPF = new RelayCommand(obj =>
                  {
                      if (string.IsNullOrEmpty(Convert.ToString(SelectedAccountList.IdAccounts)) && string.IsNullOrEmpty(Convert.ToString(SelectedAccountList2.IdAccounts)))
                      {
                          MessageBox.Show("Необходимо выбрать счета для списания и зачисления");
                      }
                      else
                      {
                          if (string.IsNullOrEmpty(Convert.ToString(transferToTheClient)))
                          {
                              MessageBox.Show("Необходимо указать сумму перевода");
                          }
                          else
                          {
                              if (Convert.ToUInt64(SelectedAccountList.MoneyBalance) >= Convert.ToUInt64(transferToTheClient))
                              {
                                  Accounts.FindAll(ac => ac.IdAccounts == SelectedAccountList.IdAccounts).ForEach(ac => ac.MoneyBalance -= Convert.ToUInt64(transferToTheClient));
                                  Accounts.FindAll(ac => ac.IdAccounts == SelectedAccountList2.IdAccounts).ForEach(ac => ac.MoneyBalance += Convert.ToUInt64(transferToTheClient));
                              }
                              else
                              {
                                  MessageBox.Show("Невозможно со счета снять денег больше чем там есть");
                              }                              
                          }
                      }
                      AccountsIntermediateValue = Accounts.Where(a => SelectedAccounts.Id == a.IdUser).ToList();
                      AccountsIntermediateValue2 = Accounts.Where(a => SelectedAccounts.Id != a.IdUser).ToList();
                  }));
            }
        }

        /// <summary>
        /// Фамилия для передачи
        /// </summary>
        private string surnameTranslate;

        /// <summary>
        /// Свойство фамилии для передачи
        /// </summary>
        public string SurnameTranslate 
        {
            get
            {
                return surnameTranslate;
            }

            set
            {
                surnameTranslate = value;
                OnPropertyChanged("SurnameTranslate");
            }
        }

        /// <summary>
        /// Имя для передачи
        /// </summary>
        private string nameTranslate;

        /// <summary>
        /// Свойство Имени для передачи
        /// </summary>
        public string NameTranslate 
        {
            get
            {
                return nameTranslate;
            }

            set
            {
                nameTranslate = value;
                OnPropertyChanged("NameTranslate");
            }
        }

        /// <summary>
        /// Отчество для передачи
        /// </summary>
        private string middleNameTranslate;

        /// <summary>
        /// Свойство Отчества для передачи
        /// </summary>
        public string MiddleNameTranslate 
        {
            get
            {
                return middleNameTranslate;
            }

            set
            {
                middleNameTranslate = value;
                OnPropertyChanged("MiddleNameTranslate");
            }
        }

        /// <summary>
        /// Телефон для передачи
        /// </summary>
        private string phoneNumberTranslate;

        /// <summary>
        /// Свойство Номера телефона для передачи
        /// </summary>
        public string PhoneNumberTranslate 
        {
            get
            {
                return phoneNumberTranslate;
            }

            set
            {
                phoneNumberTranslate = value;
                OnPropertyChanged("PhoneNumberTranslate");
            }
        }

        /// <summary>
        /// Серия и номер паспорта для передачи
        /// </summary>
        private string seriesNumberPassportTranslate;

        /// <summary>
        ///Свойство Серии и номера паспорта для передачи
        /// </summary>
        public string SeriesNumberPassportTranslate 
        {
            get
            {
                return seriesNumberPassportTranslate;
            }

            set
            {
                seriesNumberPassportTranslate = value;
                OnPropertyChanged("SeriesNumberPassportTranslate");
            }
        }

        /// <summary>
        /// Сумма для перевода для передачи
        /// </summary>
        private string transferСustomerAccountsTranslate;

        /// <summary>
        /// Свойство Суммы для перевода для передачи
        /// </summary>
        public string TransferСustomerAccountsTranslate 
        {
            get
            {
                return transferСustomerAccountsTranslate;
            }

            set
            {
                transferСustomerAccountsTranslate = value;
                OnPropertyChanged("TransferСustomerAccountsTranslate");
            }
        }

        /// <summary>
        /// Сумма для зачисления на счет
        /// </summary>
        private string accountReplenishment;

        /// <summary>
        /// Свойство Суммы для зачисления на счет
        /// </summary>
        public string AccountReplenishment
        {
            get
            {
                return accountReplenishment;
            }

            set
            {
                accountReplenishment = value;
                OnPropertyChanged("AccountReplenishment");
            }
        }

        /// <summary>
        /// Сумма перевода клиенту
        /// </summary>
        private string transferToTheClient;

        /// <summary>
        /// Свойство суммы перевода клиенту
        /// </summary>
        public string TransferToTheClient
        {
            get
            {
                return transferToTheClient;
            }

            set
            {
                transferToTheClient = value;
                OnPropertyChanged("TransferToTheClient");
            }
        }
    }
}
