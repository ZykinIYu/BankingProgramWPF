using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankingProgramWPF.Models
{
    /// <summary>
    /// Модель описывающая банковские счета
    /// </summary>
    class Accounts<T1, T2> : IComparable
    {
        /// <summary>
        /// Иденификатор счета
        /// </summary>
        private ulong idAccounts;

        /// <summary>
        /// Параметр id счета
        /// </summary>
        public ulong IdAccounts
        {
            get { return idAccounts; }
            set 
            {
                idAccounts = value;
                OnPropertyChanged("IdAccounts");
            }
        }

        /// <summary>
        /// Статическое поле для записи id
        /// </summary>
        public static ulong stIdAccounts;

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Accounts()
        {
            stIdAccounts = 0;
        }

        public ulong NextStId()
        {
            stIdAccounts++;
            return stIdAccounts;
        }

        /// <summary>
        /// id пользователя
        /// </summary>
        private T1 idUser;

        /// <summary>
        /// Параметр id пользователя
        /// </summary>
        public T1 IdUser
        {
            get { return idUser; }
            set 
            {
                idUser = value;
                OnPropertyChanged("IdUser");
            }
        }

        /// <summary>
        /// Тип счета
        /// </summary>
        private T2 accountType;

        /// <summary>
        /// Параметр типа счета
        /// </summary>
        public T2 AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                OnPropertyChanged("AccountType");
            }
        }

        public Accounts(T1 idUser, T2 accountType)
        {
            this.IdAccounts = NextStId();
            this.IdUser = idUser;
            this.AccountType = accountType;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
