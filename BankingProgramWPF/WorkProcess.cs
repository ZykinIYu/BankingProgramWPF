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
        //public List<Users> user;
        //private ulong id;
        //private Random randomize;

        //public WorkProcess(MainWindow w)
        //{
        //    this.w = w;
        //}

        ///// <summary>
        ///// Экземпляр окна
        ///// </summary>
        //private MainWindow w;

        ///// <summary>
        ///// Старт программы
        ///// </summary>
        //public void Start()
        //{
        //    user = new List<Users>();
        //    randomize = new Random();
        //    FillingCollectionWithUsers();
        //}

        ///// <summary>
        ///// Метод для наполнения коллекции пользователями
        ///// </summary>
        //public void FillingCollectionWithUsers()
        //{
        //    for (int i = 0; i < 21; i++)
        //    {
        //        var userPhoneNumber = Convert.ToString(80000000000 + randomize.Next(800000000, 900000000));
        //        var userSeriesNumberPassport = Convert.ToString(1000000000 + randomize.Next(100000000, 999999999));
        //        var userDateTimeNow = DateTime.Now;
        //        user.Add(new ConsultantUsers(NumberId(), $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", true));
        //        user.Add(new Manager(NumberId() - 1, $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", userPhoneNumber, userSeriesNumberPassport, userDateTimeNow, "-", "Добавлена новая запись", "SysAdmin", false));
        //    }
        //}

        ///// <summary>
        ///// Метод определяющий наибольший Id и увеличивающий его на 1
        ///// </summary>
        ///// <returns></returns>
        //public ulong NumberId()
        //{
        //    id = 0;
        //    for (int i = 0; i < user.Count; i++)
        //    {
        //        if (user[i].Id > id)
        //        {
        //            id = user[i].Id;
        //        }
        //    }
        //    id++;
        //    return id;
        //}

        ///// <summary>
        ///// Изменение параметров пользователей под ролью консультанта
        ///// </summary>
        //public void ChangingParametersConsultant(string CorrectedUser, string NewPhoneNumber, string CF)
        //{
        //    for (; ; )
        //    {
        //        for (int i = 0; i < user.Count; i++)
        //        {
        //            if (user[i].Id == Convert.ToUInt64(CorrectedUser) && user[i].GetType() == typeof(ConsultantUsers))
        //            {
        //                user[i].СhangedFields = CF;
        //                user[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), user[i].Surname, user[i].Name, user[i].MiddleName, NewPhoneNumber, user[i].SeriesNumberPassport, user);
        //            }
        //        }
        //        break;
        //    }
        //}

        ///// <summary>
        ///// Изменение параметров пользователей под ролью менеджера
        ///// </summary>
        //public void ChangingParametersManager(string CorrectedUser, string NewSurname, string NewName, string NewMiddleName, string NewPhoneNumber, string NewSeriesNumberPassport, string CF)
        //{
        //    for (; ; )
        //    {
        //        for (int i = 0; i < user.Count; i++)
        //        {
        //            if (user[i].Id == Convert.ToUInt64(CorrectedUser) && user[i].GetType() == typeof(Manager))
        //            {
        //                user[i].СhangedFields = CF;
        //                user[i].ParameterСhange(Convert.ToUInt64(CorrectedUser), NewSurname, NewName, NewMiddleName, NewPhoneNumber, NewSeriesNumberPassport, user);

        //                for (int j = 0; j < user.Count; j++)
        //                {
        //                    if (user[j].Id == Convert.ToUInt64(CorrectedUser) && user[j].GetType() == typeof(ConsultantUsers))
        //                    {
        //                        user[j].SeriesNumberPassport = $"**********";
        //                    }
        //                } 
        //            } 
        //        }
        //        break;
        //    }
        //}

        ///// <summary>
        ///// Печать списка пользователей в документы
        ///// </summary>
        //private void PrintDocument()
        //{
        //    using (StreamWriter sw = new StreamWriter("consultant.csv", false, Encoding.Unicode))
        //    {
        //        sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
        //        for (int i = 0; i < user.Count; i++)
        //        {
        //            if (user[i].GetType() == typeof(ConsultantUsers))
        //            {
        //                sw.WriteLine(user[i].Print());
        //            }
        //        }
        //    }

        //    using (StreamWriter sw = new StreamWriter("manager.csv", false, Encoding.Unicode))
        //    {
        //        sw.WriteLine($"ID\tФамилия\tИмя\tОтчество\tНомер телефона\tСерия и номер паспорта\tВремя изменения\tЧто изменено\tТип изменения\tКто изменил");
        //        for (int i = 0; i < user.Count; i++)
        //        {
        //            if (user[i].GetType() == typeof(Manager))
        //            {
        //                sw.WriteLine(user[i].Print());
        //            }
        //        }
        //    }
        //}

    }
}
