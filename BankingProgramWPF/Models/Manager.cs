using BankingProgramWPF;
using BankingProgramWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public Manager(string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, DateTime DateTimeEntryModified, string WhatDataChanged, string TypeChange, string WhoChangedData, bool СonsultantСheck)
            : base (Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, DateTimeEntryModified, WhatDataChanged, TypeChange, WhoChangedData, СonsultantСheck)
        {
            this.Id = NextId();
        }

        //public event ValueChangedHandler ValueChanged;

        //public event EventHandler CanExecuteChanged;

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
        public override void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<IUsers> user)
        {
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Surname = Surname);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Name = Name);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.MiddleName = MiddleName);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.SeriesNumberPassport = SeriesNumberPassport);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.DateTimeEntryModified = DateTime.Now);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhatDataChanged = MainWindow.changedFields);
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
        public new static void AddEntry(string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<IUsers> user)
        {
            var data = DateTime.Now;
            user.Add(new Manager(Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, data, "-", "Добавлена новая запись", "Менеджер", false));
            //user.Add(new ConsultantUsers(Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, data, "-", "Добавлена новая запись", "Менеджер", true));
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        public new static void RemoveEntry(ulong id, List<IUsers> user)
        {
            user.RemoveAll(us => us.Id == id);
        }


        //private void SetTextSurname(string newTextSurname)
        //{
        //    if (Surname == newTextSurname)
        //        return;

        //    string oldTextSurname = Surname;
        //    Surname = newTextSurname;

        //    ValueChanged?.Invoke(this, nameof(Surname), oldTextSurname, Surname);
        //}

        //private void SetTextName(string newTextName)
        //{
        //    if (Name == newTextName)
        //        return;

        //    string oldTextName = Name;
        //    Name = newTextName;

        //    ValueChanged?.Invoke(this, nameof(Name), oldTextName, Name);
        //}

        //private void SetTextMiddleName(string newTextMiddleName)
        //{
        //    if (MiddleName == newTextMiddleName)
        //        return;

        //    string oldTextMiddleName = MiddleName;
        //    MiddleName = newTextMiddleName;

        //    ValueChanged?.Invoke(this, nameof(MiddleName), oldTextMiddleName, MiddleName);
        //}

        //private void SetTextPhoneNumber(string newTextPhoneNumber)
        //{
        //    if (PhoneNumber == newTextPhoneNumber)
        //        return;

        //    string oldTextPhoneNumber = PhoneNumber;
        //    PhoneNumber = newTextPhoneNumber;

        //    ValueChanged?.Invoke(this, nameof(PhoneNumber), oldTextPhoneNumber, PhoneNumber);
        //}

        //private void SetTextSeriesNumberPassport(string newTextSeriesNumberPassport)
        //{
        //    if (SeriesNumberPassport == newTextSeriesNumberPassport)
        //        return;

        //    string oldTextSeriesNumberPassport = SeriesNumberPassport;
        //    SeriesNumberPassport = newTextSeriesNumberPassport;

        //    ValueChanged?.Invoke(this, nameof(SeriesNumberPassport), oldTextSeriesNumberPassport, SeriesNumberPassport);
        //}

        //public void SendValue(string valueName, object newValue)
        //{
        //    switch (valueName)
        //    {
        //        case nameof(Surname): SetTextSurname((string)newValue); break;
        //        case nameof(Name): SetTextName((string)newValue); break;
        //        case nameof(MiddleName): SetTextMiddleName((string)newValue); break;
        //        case nameof(PhoneNumber): SetTextPhoneNumber((string)newValue); break;
        //        case nameof(SeriesNumberPassport): SetTextSeriesNumberPassport((string)newValue); break;
        //        default: throw new ArgumentException(nameof(valueName));
        //    }
        //}

        //public bool ValidateValue(string valueName, object newValue)
        //{
        //    switch (valueName)
        //    {
        //        case nameof(Surname): return newValue is string;
        //        case nameof(Name): return newValue is string;
        //        case nameof(MiddleName): return newValue is string;
        //        case nameof(PhoneNumber): return newValue is string;
        //        case nameof(SeriesNumberPassport): return newValue is string;
        //        default: return false;
        //    }
        //}

        //public void AllValueChanged()
        //{
        //    ValueChanged?.Invoke(this, nameof(Surname), null, Surname);
        //    ValueChanged?.Invoke(this, nameof(Name), null, Name);
        //    ValueChanged?.Invoke(this, nameof(MiddleName), null, MiddleName);
        //    ValueChanged?.Invoke(this, nameof(PhoneNumber), null, PhoneNumber);
        //    ValueChanged?.Invoke(this, nameof(SeriesNumberPassport), null, SeriesNumberPassport);
        //}
    }
}
