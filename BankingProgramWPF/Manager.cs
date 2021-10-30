using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class Manager : ConsultantUsers
    {
        /// <summary>
        /// Конструктор для создания пользователей
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Surname"></param>
        /// <param name="Name"></param>
        /// <param name="MiddleName"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="SeriesNumberPassport"></param>
        /// <param name="DateTimeEntryModified"></param>
        /// <param name="WhatDataChanged"></param>
        /// <param name="TypeChange"></param>
        /// <param name="WhoChangedData"></param>
        public Manager(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, DateTime DateTimeEntryModified, string WhatDataChanged, string TypeChange, string WhoChangedData)
            : base (Id, Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, DateTimeEntryModified, WhatDataChanged, TypeChange, WhoChangedData)
        {
            
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public override string Print()
        {
            return $"{Id}\t{Surname}\t{Name}\t{MiddleName}\t{PhoneNumber}\t{SeriesNumberPassport}\t{DateTimeEntryModified}\t{WhatDataChanged}\t{TypeChange}\t{WhoChangedData}";
        }

        /// <summary>
        /// Метод корректировки параметров пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">Серия и номер паспорта</param>
        /// <param name="user">Коллекция пользователей для консультанта</param>
        /// <param name="userM">Коллекция пользователей для менеджера</param>
        public override void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user)
        {
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Surname = Surname);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Name = Name);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.MiddleName = MiddleName);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.SeriesNumberPassport = SeriesNumberPassport);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.DateTimeEntryModified = DateTime.Now);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhatDataChanged = СhangedFields);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.TypeChange = "Изменена запись");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhoChangedData = "Менеджер");
        }

        /// <summary>
        /// Метод добавление новой записи
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">Серия и номер паспорта</param>
        /// <param name="user">Коллекция пользователей</param>
        public override void AddEntry(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user)
        {
            var data = DateTime.Now;
            user.Add(new Manager(Id, Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, data, "-", "Добавлена новая запись", "Менеджер"));
            user.Add(new ConsultantUsers(Id, Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, data, "-", "Добавлена новая запись", "Менеджер"));
        }

    }
}
