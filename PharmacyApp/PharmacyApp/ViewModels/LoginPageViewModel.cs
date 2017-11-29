using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PharmacyApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ICommand EnterCommand { get; set; }
        INavigation Navigation { get; set; }

        string login;
        string password;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

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
        public LoginPageViewModel()
        {
            EnterCommand = new Command(Enter);
        }

        public void Enter()
        {
            if (!String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password))
            {
                User user = new User
                {
                    login = Login,
                    password = Password
                };

                PharmacyService service = new PharmacyService();

                service.Login(user);

            }
        }
    }
}
