using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    /// <summary>
    /// Описание пользователей
    /// </summary>
    interface Users
    {
        /// <summary>
        /// Свойство чтения и записи идентификатора
        /// </summary>
        ulong Id { get; set; }

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        string Surname { get; set; }

        /// <summary>
        /// свойствр для чтения имени пользователя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        string SeriesNumberPassport { get; set; }

        /// <summary>
        /// Свойство поля дата и время изменения записи
        /// </summary>
        DateTime DateTimeEntryModified { get; set; }

        /// <summary>
        /// Свойство поля показывающее какие данные изменены
        /// </summary>
        string WhatDataChanged { get; set; }

        /// <summary>
        /// Свойство поля показывающее тип изменения
        /// </summary>
        string TypeChange { get; set; }

        /// <summary>
        /// Свойство поля показывающее кто изменил
        /// </summary>
        string WhoChangedData { get; set; }

        /// <summary>
        /// Свойство поля временного хранения
        /// </summary>
        string СhangedFields { get; set; }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        string Print();

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
        void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user);

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        void AddEntry(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user);

    }
}
