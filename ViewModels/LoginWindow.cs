using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SportClub.Data;
using System.Linq;
using System.Windows;
using SportClub.Views;
using SportClub.Services;

namespace SportClub.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private string _username;
        private string _password;
        private bool _isLoggingIn;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isPasswordVisible;
        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));

                // Sinhronizuj password između TextBox-a i PasswordBox-a
                if (_isPasswordVisible && !string.IsNullOrEmpty(Password))
                {
                    PasswordText = Password;
                }
            }
        }

        private string _passwordText;
        public string PasswordText
        {
            get => _passwordText;
            set
            {
                _passwordText = value;
                Password = value; // Sinhronizuj sa Password propertijem
                OnPropertyChanged(nameof(PasswordText));
            }
        }
        public LoginViewModel()
        {
            _context = new SportClubContext();
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoggingIn
        {
            get => _isLoggingIn;
            set
            {
                _isLoggingIn = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !IsLoggingIn;
        }

        private void Login()
        {
            IsLoggingIn = true;
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (user != null)
                {
                    // Postaviti trenutnog korisnika
                    CurrentUserService.Instance.SetCurrentUser(user);

                    // Učitati tema korisnika
                    LoadUserTheme(user.IdUser);

                    if (_context.Admins.Any(a => a.IdUser == user.IdUser))
                    {
                        MessageBox.Show("Uspješno prijavljen kao Admin!");
                        OpenMainWindowAdmin();
                    }
                    else if (_context.Instructors.Any(i => i.IdUser == user.IdUser))
                    {
                        MessageBox.Show("Uspješno prijavljen kao Instructor!");
                        OpenMainWindowInstructor();
                    }
                    else
                    {
                        MessageBox.Show("Korisnik postoji, ali nije Admin ili Instructor!");
                    }
                }
                else
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri pristupu bazi: {ex.Message}\nInner: {ex.InnerException?.Message}");
            }
            finally
            {
                IsLoggingIn = false;
            }
        }

        private void LoadUserTheme(int userId)
        {
            var settings = _context.UserSettings.FirstOrDefault(us => us.UserId == userId);
            if (settings != null)
            {
                ThemeService.Instance.ApplyTheme(settings.Theme);
                ThemeService.Instance.ApplyFont(settings.FontFamily, settings.FontSize);
            }
            else
            {
                ThemeService.Instance.ApplyTheme("Default");
                ThemeService.Instance.ApplyFont("Segoe UI", 14);
            }
        }

        private void OpenMainWindowAdmin()
        {
            var mainWindow = new MainWindowAdmin();
            mainWindow.Show();
            Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
        }

        private void OpenMainWindowInstructor()
        {
            var mainWindow = new MainWindowInstructor();
            mainWindow.Show();
            Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault()?.Close();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Jednostavna implementacija RelayCommand (možeš koristiti MVVM Light umjesto ovoga)
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();
    }
}