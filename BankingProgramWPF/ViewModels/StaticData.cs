using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgramWPF.ViewModels
{
    /// <summary>
    /// Класс хранилище данных
    /// </summary>
    public static class StaticData
    {
        /// <summary>
        /// Временное хранение Фамилии
        /// </summary>
        public static string SurnameTB { get; set; }

        /// <summary>
        /// Временное хранение Имени
        /// </summary>
        public static string NameTB { get; set; }

        /// <summary>
        /// Временное хранение Отчества
        /// </summary>
        public static string MiddleNameTB { get; set; }

        /// <summary>
        /// Временное хранение Номера телефона
        /// </summary>
        public static string PhoneNumberTB { get; set; }

        /// <summary>
        /// Временное хранение Серии и номера паспорта
        /// </summary>
        public static string SeriesNumberPassportTB { get; set; }

        /// <summary>
        /// Временное хранение Суммы для перевода
        /// </summary>
        public static string TransferСustomerAccountsWPF { get; set; }
    }
}
