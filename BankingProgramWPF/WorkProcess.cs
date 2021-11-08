using BankingProgramWPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class WorkProcess
    {
        public List<Users> user;
        private ulong id;
        private Random randomize;
        private string proofWork;
        private string typeEmployee;
        private string correctedUser;
        private string newParameterValue;
        private string newSurname;
        private string newName;
        private string newMiddleName;
        private string newPhoneNumber;
        private string newSeriesNumberPassport;

        public WorkProcess(MainWindow w)
        {
            this.w = w;
        }

        /// <summary>
        /// Экземпляр окна
        /// </summary>
        private MainWindow w;

        /// <summary>
        /// Старт программы
        /// </summary>
        public void Start()
        {
            user = new List<Users>();
            randomize = new Random();
            FillingCollectionWithUsers();
            //LoginName();
            //PrintDocument();
        }

        ///// <summary>
        ///// Метод выбора под какой ролью будет запускаться программа
        ///// </summary>
        //private void LoginName()
        //{
        //    for (; ; )
        //    {
        //        Console.Clear();
        //        Console.WriteLine($"Под кем хотите зайти?");
        //        Console.WriteLine($"1. Консультант");
        //        Console.WriteLine($"2. Менеджер");
        //        Console.Write($"Необходимо выбрать 1 или 2: ");
        //        typeEmployee = Console.ReadLine();
        //        WorkUnderRole();
        //        Console.Clear();
        //        Console.Write($"Необходимо еще выполнить работы в других ролях? да/нет: ");
        //        proofWork = Console.ReadLine().ToLower();
        //        if (proofWork == "нет")
        //        {
        //            break;
        //        }
        //    }
            
        //}

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
                user.Add(new ConsultantUsers(NumberId(), $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", true));
                user.Add(new Manager(NumberId() - 1, $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", false));
            }
        }

        ///// <summary>
        ///// Вывод в консоль всех пользователей
        ///// </summary>
        //private void ReadUser()
        //{
        //    for (int i = 0; i < user.Count; i++)
        //    {
        //        if (typeEmployee == "1" && user[i].GetType() == typeof(ConsultantUsers))
        //        {
        //            Console.WriteLine($"{user[i].Print()}");
        //        }

        //        if (typeEmployee == "2" && user[i].GetType() == typeof(Manager))
        //        {
        //            Console.WriteLine($"{user[i].Print()}");
        //        }
        //    }
        //}

        /// <summary>
        /// Метод определяющий наибольший Id и увеличивающий его на 1
        /// </summary>
        /// <returns></returns>
        private ulong NumberId()
        {
            id = 0;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].Id > id)
                {
                    id = user[i].Id;
                }
            }
            id++;
            return id;
        }

        ///// <summary>
        ///// Метод для корректировки пользовательских данных
        ///// </summary>
        //private void DataCorrection()
        //{
        //    if (typeEmployee == "1")
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine($"Какие работы необходимо выполнить: ");
        //        Console.WriteLine($"1. Скорректировать номер телефона ");
        //        Console.Write($"Необходимо выбрать 1: ");

        //        switch (Console.ReadLine())
        //        {
        //            case "1":
        //                ChangingParametersConsultant();
        //                break;
        //        }
        //    }

        //    if (typeEmployee == "2")
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine($"Какие работы необходимо выполнить: ");
        //        Console.WriteLine($"1. Скорректировать данные ");
        //        Console.WriteLine($"2. Добавить пользователя ");
        //        Console.Write($"Необходимо выбрать 1 или 2: ");

        //        switch (Console.ReadLine())
        //        {
        //            case "1":
        //                //ChangingParametersManager();
        //                break;

        //            case "2":
        //                AddNewUser();
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Изменение параметров пользователей под ролью консультанта
        /// </summary>
        public void ChangingParametersConsultant(string CorrectedUser, string NewPhoneNumber, string CF)
        {
            for (; ; )
            {
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].Id == Convert.ToUInt64(CorrectedUser) && user[i].GetType() == typeof(ConsultantUsers))
                    {
                        user[i].СhangedFields = CF;
                        user[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), user[i].Surname, user[i].Name, user[i].MiddleName, NewPhoneNumber, user[i].SeriesNumberPassport, user);
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
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].Id == Convert.ToUInt64(CorrectedUser) && user[i].GetType() == typeof(Manager))
                    {
                        user[i].СhangedFields = CF;
                        user[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), NewSurname, NewName, NewMiddleName, NewPhoneNumber, NewSeriesNumberPassport, user);

                        for (int j = 0; j < user.Count; j++)
                        {
                            if (user[j].Id == Convert.ToUInt64(CorrectedUser) && user[j].GetType() == typeof(ConsultantUsers))
                            {
                                user[j].SeriesNumberPassport = $"**********";
                            }
                        } 
                    } 
                }
                break;
            }
        }

        ///// <summary>
        ///// Метод описывающий работу под ролью
        ///// </summary>
        //private void WorkUnderRole()
        //{  
        //    for (; ; )
        //    {
        //        Console.Clear();
        //        ReadUser();
        //        DataCorrection();
        //        Console.Clear();
        //        Console.Write($"Необходимо еще выполнить работы? да/нет: ");
        //        proofWork = Console.ReadLine().ToLower();
        //        if (proofWork == "нет")
        //        {
        //            break;
        //        }
        //    }
        //}

        /// <summary>
        /// Печать списка пользователей в документы
        /// </summary>
        private void PrintDocument()
        {
            using (StreamWriter sw = new StreamWriter("consultant.csv", false, Encoding.Unicode))
            {
                sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].GetType() == typeof(ConsultantUsers))
                    {
                        sw.WriteLine(user[i].Print());
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter("manager.csv", false, Encoding.Unicode))
            {
                sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
                for (int i = 0; i < user.Count; i++)
                {
                    if (user[i].GetType() == typeof(Manager))
                    {
                        sw.WriteLine(user[i].Print());
                    }
                }
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public void AddNewUser(string NewSurname, string NewName, string NewMiddleName, string NewPhoneNumber, string NewSeriesNumberPassport)
        {
            user[user.Count - 1].AddEntry(NumberId(), NewSurname, NewName, NewMiddleName, NewPhoneNumber, NewSeriesNumberPassport, user);
            //for (; ; )
            //{
            //    Console.Clear();
            //    Console.Write($"Введите фамилию: ");
            //    newSurname = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(newSurname))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.Write($"Данное поле обязательно для заполнения");
            //        Console.ReadKey();
            //    }
            //}

            //for (; ; )
            //{
            //    Console.Clear();
            //    Console.Write($"Введите имя: ");
            //    newName = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(newName))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.Write($"Данное поле обязательно для заполнения");
            //        Console.ReadKey();
            //    }
            //}

            //for (; ; )
            //{
            //    Console.Clear();
            //    Console.Write($"Введите отчество: ");
            //    newMiddleName = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(newMiddleName))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.Write($"Данное поле обязательно для заполнения");
            //        Console.ReadKey();
            //    }
            //}

            //for (; ; )
            //{
            //    Console.Clear();
            //    Console.Write($"Введите номер телефона: ");
            //    var storage = Console.ReadLine();
            //    if (storage.Length == 11 && storage.All(char.IsDigit) == true)
            //    {
            //        newPhoneNumber = storage;
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.Write($"Номер телефона, является обязательным полем, оно не может быть пустым, должно содержать только цифры и иметь ровно 11 символов");
            //        Console.ReadKey();
            //    }
            //}

            //for (; ; )
            //{
            //    Console.Clear();
            //    Console.Write($"Введите серию и номер паспорта: ");
            //    var storage = Console.ReadLine();
            //    if (storage.Length == 10 && storage.All(char.IsDigit) == true || storage.Length == 0)
            //    {
            //        newSeriesNumberPassport = storage;
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.Write($"Серия и номер паспорта должна содержать 10 цифр, либо можно поле не заполнять");
            //        Console.ReadKey();
            //    }
            //}
            //user[user.Count-1].AddEntry(NumberId(), newSurname, newName, newMiddleName, newPhoneNumber, newSeriesNumberPassport, user);
        }
    }
}
