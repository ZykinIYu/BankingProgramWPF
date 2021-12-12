using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankingProgram
{
    class ConsultantUsers : Users, INotifyPropertyChanged, ICommand
    {
        private ulong id;

        /// <summary>
        /// Свойство чтения и записи идентификатора
        /// </summary>
        public ulong Id 
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public static ulong staticId;

        static ConsultantUsers()
        {
            staticId = 0;
        }

        public static ulong NextId()
        {
            staticId++;
            return staticId;
        }

        private string surname;

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        public string Surname 
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string name;

        /// <summary>
        /// свойствр для чтения имени пользователя
        /// </summary>
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string middleName;

        /// <summary>
        /// Свойство для чтения отчества пользователя
        /// </summary>
        public string MiddleName 
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string phoneNumber;

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        public string PhoneNumber 
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string seriesNumberPassport;

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        public string SeriesNumberPassport 
        {
            get { return seriesNumberPassport; }
            set
            {
                seriesNumberPassport = value;
                OnPropertyChanged("SeriesNumberPassport");
            }
        }

        /// <summary>
        /// Свойство поля дата и время изменения записи
        /// </summary>
        public DateTime DateTimeEntryModified { get; set; }

        /// <summary>
        /// Свойство поля показывающее какие данные изменены
        /// </summary>
        public string WhatDataChanged { get; set; }

        /// <summary>
        /// Свойство поля показывающее тип изменения
        /// </summary>
        public string TypeChange { get; set; }

        /// <summary>
        /// Свойство поля показывающее кто изменил
        /// </summary>
        public string WhoChangedData { get; set; }

        /// <summary>
        /// Свойство поля временного хранения
        /// </summary>
        public string СhangedFields { get; set; }

        /// <summary>
        /// Конструктор пользователей
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">серия и номер паспорта</param>
        public ConsultantUsers(string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, DateTime DateTimeEntryModified, string WhatDataChanged, string TypeChange, string WhoChangedData, bool СonsultantСheck)
        {
            this.Id = NextId();
            staticId--;
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.PhoneNumber = PhoneNumber;
            this.SeriesNumberPassport = SeriesNumberPassport;
            this.DateTimeEntryModified = DateTimeEntryModified;
            this.WhatDataChanged = WhatDataChanged;
            this.TypeChange = TypeChange;
            this.WhoChangedData = WhoChangedData;

            if (СonsultantСheck == true)
            {
                this.SeriesNumberPassport = HidingSeriesAndNumberPassport();
            }           
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public virtual string Print()
        {
            return $"{Id}\t{Surname}\t{Name}\t{MiddleName}\t{PhoneNumber}\t{HidingSeriesAndNumberPassport()}\t{DateTimeEntryModified}\t{WhatDataChanged}\t{TypeChange}\t{WhoChangedData}";
        }

        /// <summary>
        /// Метод скрывающий серию и номер паспорта
        /// </summary>
        /// <returns></returns>
        private string HidingSeriesAndNumberPassport()
        {
            if (SeriesNumberPassport.Length != 0)
            {
                return $"**********";
            }
            else
            {
                return Convert.ToString(SeriesNumberPassport);
            }
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
        public virtual void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user)
        {
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.DateTimeEntryModified = DateTime.Now);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhatDataChanged = "Изменено: phoneNumber");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.TypeChange = "Изменена запись");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhoChangedData = "Консультант");
        }

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        public virtual void AddEntry(string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<Users> user)
        {
            var data = DateTime.Now;
            user.Add(new ConsultantUsers(Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, data, "-", "Добавлена новая запись", "Менеджер", true));
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        public virtual void RemoveEntry(ulong id, List<Users> user)
        {
            MessageBox.Show("Консультанту запрещено удалять пользователей пользователей");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
