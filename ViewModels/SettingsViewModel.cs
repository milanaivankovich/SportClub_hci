using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using SportClub.Data;
using SportClub.Services;
using System.Linq;
using SportClub.Models;

namespace SportClub.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private readonly SportClubContext _context;
        private int _currentUserId;

        private string _currentPassword;
        private string _newPassword;
        private string _confirmPassword;
        private string _selectedTheme;
        private string _selectedFont;
        private double _selectedFontSize;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentPassword
        {
            get => _currentPassword;
            set { _currentPassword = value; OnPropertyChanged(); }
        }

        public string NewPassword
        {
            get => _newPassword;
            set { _newPassword = value; OnPropertyChanged(); }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                _selectedTheme = value;
                OnPropertyChanged();
                ApplyTheme();
                SaveSettings(); // Automatski sačuvaj kad se promijeni tema
            }
        }

        public string SelectedFont
        {
            get => _selectedFont;
            set
            {
                _selectedFont = value;
                OnPropertyChanged();
                ApplyFont();
                SaveSettings(); // Automatski sačuvaj kad se promijeni font
            }
        }

        public double SelectedFontSize
        {
            get => _selectedFontSize;
            set
            {
                _selectedFontSize = value;
                OnPropertyChanged();
                ApplyFontSize();
                SaveSettings(); // Automatski sačuvaj kad se promijeni veličina fonta
            }
        }

        public List<string> AvailableThemes { get; } = new List<string> { "Default", "Light", "Dark" };
        public List<string> AvailableFonts { get; } = new List<string> { "Segoe UI", "Arial", "Times New Roman", "Verdana" };
        public List<double> AvailableFontSizes { get; } = new List<double> { 12, 14, 16, 18, 20 };

        public ICommand ChangePasswordCommand { get; }
        public ICommand SaveSettingsCommand { get; }

        public SettingsViewModel()
        {
            if (CurrentUserService.Instance.IsLoggedIn)
            {
                _currentUserId = CurrentUserService.Instance.CurrentUser.IdUser;
            }
            else
            {
                throw new InvalidOperationException("No logged-in user found. Please log in first.");
            }

            _context = new SportClubContext();
            ChangePasswordCommand = new RelayCommand(ChangePassword, CanChangePassword);
            SaveSettingsCommand = new RelayCommand(SaveSettings);
            LoadUserSettings();
        }

        public SettingsViewModel(int userId)
        {
            _context = new SportClubContext();
            _currentUserId = userId;

            ChangePasswordCommand = new RelayCommand(ChangePassword, CanChangePassword);
            SaveSettingsCommand = new RelayCommand(SaveSettings);

            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            var settings = _context.UserSettings.FirstOrDefault(us => us.UserId == _currentUserId);
            SelectedTheme = settings?.Theme ?? "Default";
            SelectedFont = settings?.FontFamily ?? "Segoe UI";
            SelectedFontSize = settings?.FontSize ?? 14;
        }

        private void ApplyTheme()
        {
            if (!string.IsNullOrEmpty(SelectedTheme))
            {
                ThemeService.Instance.ApplyTheme(SelectedTheme);
            }
        }

        private void ApplyFont()
        {
            if (!string.IsNullOrEmpty(SelectedFont))
            {
                ThemeService.Instance.ApplyFont(SelectedFont, SelectedFontSize);
            }
        }

        private void ApplyFontSize()
        {
            if (!string.IsNullOrEmpty(SelectedFont))
            {
                ThemeService.Instance.ApplyFont(SelectedFont, SelectedFontSize);
            }
        }

        private bool CanChangePassword()
        {
            return !string.IsNullOrEmpty(CurrentPassword) &&
                   !string.IsNullOrEmpty(NewPassword) &&
                   NewPassword == ConfirmPassword;
        }

        private void ChangePassword()
        {
            var user = _context.Users.FirstOrDefault(u => u.IdUser == _currentUserId);
            if (user != null && user.Password == CurrentPassword)
            {
                user.Password = NewPassword;
                _context.SaveChanges();
                MessageBox.Show("Lozinka uspješno promijenjena!");

                CurrentPassword = string.Empty;
                NewPassword = string.Empty;
                ConfirmPassword = string.Empty;
            }
            else
            {
                MessageBox.Show("Trenutna lozinka nije ispravna!");
            }
        }

        private void SaveSettings()
        {
            if (_context == null) return;

            try
            {
                var settings = _context.UserSettings.FirstOrDefault(us => us.UserId == _currentUserId);
                if (settings == null)
                {
                    settings = new UserSettings { UserId = _currentUserId };
                    _context.UserSettings.Add(settings);
                }

                settings.Theme = SelectedTheme ?? "Default";
                settings.FontFamily = SelectedFont ?? "Segoe UI";
                settings.FontSize = SelectedFontSize;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri snimanju podešavanja: {ex.Message}\nInner: {ex.InnerException?.Message}");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}