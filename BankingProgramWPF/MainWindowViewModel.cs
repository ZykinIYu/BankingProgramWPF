using BankingProgram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgramWPF
{
    class MainWindowViewModel : Bindable
    {
        public List<Users> User;
        private ulong id;
        private Random randomize;
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
                User.Add(new ConsultantUsers(NumberId(), $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", true));
                User.Add(new Manager(NumberId() - 1, $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", false));
            }
        }

        /// <summary>
        /// Метод определяющий наибольший Id и увеличивающий его на 1
        /// </summary>
        /// <returns></returns>
        public ulong NumberId()
        {
            id = 0;
            for (int i = 0; i < User.Count; i++)
            {
                if (User[i].Id > id)
                {
                    id = User[i].Id;
                }
            }
            id++;
            return id;
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
    }
}
