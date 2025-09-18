using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class EditInstructorWindow : Window
    {
        private Instructor _instructor;
        private bool _isPasswordChanged = false;

         
        private readonly Regex _usernameRegex = new Regex(@"^[a-zA-Z0-9_.]{3,}$");

        public EditInstructorWindow(Instructor instructor)
        {
            InitializeComponent();
            _instructor = instructor;

            // Subscribe to theme changes
            ThemeService.Instance.ThemeChanged += OnThemeChanged;

            // Apply current theme to window
            ApplyCurrentTheme();

            // Load instructor data
            LoadInstructorData();

            // Set focus to first field
            ImeTextBox.Focus();
        }

        private void LoadInstructorData()
        {
            ImeTextBox.Text = _instructor.FirstName;
            PrezimeTextBox.Text = _instructor.LastName;
            UsernameTextBox.Text = _instructor.Username;

            
            if (!string.IsNullOrEmpty(_instructor.Password))
            {
                PasswordBox.Password = "********";  
                _isPasswordChanged = false;
            }
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
        }

        private void ApplyCurrentTheme()
        {
            try
            {
                 
                this.UpdateDefaultStyle();
 
                if (Application.Current.Resources.Contains("BackgroundBrush"))
                {
                    this.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundBrush"];
                }

                 
                InvalidateVisual();
            }
            catch (Exception ex)
            {
                 
                System.Diagnostics.Debug.WriteLine($"Theme application error: {ex.Message}");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Sva polja su obavezna!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

             
            if (ImeTextBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("Ime mora imati najmanje 2 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                ImeTextBox.Focus();
                return;
            }

            if (PrezimeTextBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("Prezime mora imati najmanje 2 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                PrezimeTextBox.Focus();
                return;
            }

            
            if (!_usernameRegex.IsMatch(UsernameTextBox.Text.Trim()))
            {
                MessageBox.Show("Korisničko ime mora imati najmanje 3 karaktera i može sadržavati samo slova, brojeve, tačku i podvlaku!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                UsernameTextBox.Focus();
                UsernameTextBox.SelectAll();
                return;
            }

            
            if (_isPasswordChanged && PasswordBox.Password.Length < 4)
            {
                MessageBox.Show("Lozinka mora imati najmanje 4 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                PasswordBox.Focus();
                return;
            }

             
            if (ContainsNumbers(ImeTextBox.Text) || ContainsNumbers(PrezimeTextBox.Text))
            {
                MessageBox.Show("Ime i prezime ne mogu sadržavati brojeve!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

            try
            {
                 
                _instructor.FirstName = CapitalizeFirstLetter(ImeTextBox.Text.Trim());
                _instructor.LastName = CapitalizeFirstLetter(PrezimeTextBox.Text.Trim());
                _instructor.Username = UsernameTextBox.Text.Trim().ToLower();

                 
                if (_isPasswordChanged)
                {   
                    _instructor.Password = PasswordBox.Password;
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri čuvanju podataka: {ex.Message}",
                               "Greška",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null && passwordBox.Password != "********")
            {
                _isPasswordChanged = true;
            }
        }

        private bool ContainsNumbers(string text)
        {
            return Regex.IsMatch(text, @"\d");
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter && !e.Handled)
            {
                SaveButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }
            
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            
            ThemeService.Instance.ThemeChanged -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}