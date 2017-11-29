using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RegisterCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public INavigation Navigation;
        public string login;
        public string password;
        public string firstName;
        public string secondName;
        public string patronomyc;
        public string address;
        public string bornDate;
        public string number;
        public string mail;

        public bool passLogVisible;
        public bool tableVisible;

        public string Login
        {
            get { return login; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {

            get { return password; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    secondName = value;
                    OnPropertyChanged("SecondName");
                }
            }
        }

        public string Patronomyc
        {
            get { return patronomyc; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    patronomyc = value;
                    OnPropertyChanged("Patronomyc");
                }
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public string BornDate
        {
            get { return bornDate; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    bornDate = value;
                    OnPropertyChanged("BornDate");
                }
            }
        }

        public string Number
        {
            get { return number; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    mail = value;
                    OnPropertyChanged("Mail");
                }
            }
        }



        public bool PassLogVisible
        {
            get { return passLogVisible; }
            set
            {
                passLogVisible = value;
                OnPropertyChanged("PassLogVisible");
            }
        }

        public bool TableVisible
        {
            get { return tableVisible; }
            set
            {
                tableVisible = value;
                OnPropertyChanged("TableVisible");
            }
        }

        public RegistrationViewModel()
        {
            TableVisible = false;
            PassLogVisible = true;
            RegisterCommand = new Command(Registration);
            NextCommand = new Command(Next);
           
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void Next()
        {
            if(!String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password))
            {
                if (PassLogVisible != false)
                    PassLogVisible = false;

                if (TableVisible != true)
                    TableVisible = true;
            }
        }
        
        public async void Registration()
        {
            if (IsNullOrWhiteSpaceExtension.AllIsNullOrWhiteSpace(false,FirstName,SecondName,Address,BornDate,Mail,Number))
            {
                PharmacyService service = new PharmacyService();
                UserInfo user = new UserInfo
                {
                    Login = login,
                    Password = password,
                    FirstName = firstName,
                    SecondName = secondName,
                    Patronomyc = patronomyc,
                    Address = address,
                    BornDate = bornDate,
                    Mail = mail,
                    Number = number

                };
                await service.Add(user);
                await Navigation.PopToRootAsync();
            }
        }
    }
}
