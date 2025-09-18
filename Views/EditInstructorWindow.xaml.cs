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

        // Username validation regex (alphanumeric, underscore, dot, min 3 chars)
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

            // For existing instructors, show placeholder for password
            if (!string.IsNullOrEmpty(_instructor.Password))
            {
                PasswordBox.Password = "********"; // Placeholder for existing password
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
                // Force update of all dynamic resources
                this.UpdateDefaultStyle();

                // Apply background brush if available
                if (Application.Current.Resources.Contains("BackgroundBrush"))
                {
                    this.Background = (System.Windows.Media.Brush)Application.Current.Resources["BackgroundBrush"];
                }

                // Refresh all child elements
                InvalidateVisual();
            }
            catch (Exception ex)
            {
                // Log error if needed
                System.Diagnostics.Debug.WriteLine($"Theme application error: {ex.Message}");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate required fields
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

            // Validate name lengths
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

            // Validate username format
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

            // Validate password strength (only if password was changed)
            if (_isPasswordChanged && PasswordBox.Password.Length < 4)
            {
                MessageBox.Show("Lozinka mora imati najmanje 4 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                PasswordBox.Focus();
                return;
            }

            // Check for name format (no numbers in names)
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
                // Update instructor data
                _instructor.FirstName = CapitalizeFirstLetter(ImeTextBox.Text.Trim());
                _instructor.LastName = CapitalizeFirstLetter(PrezimeTextBox.Text.Trim());
                _instructor.Username = UsernameTextBox.Text.Trim().ToLower();

                // Only update password if it was changed
                if (_isPasswordChanged)
                {
                    // In production, hash the password here
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
            // Handle Enter key to save
            if (e.Key == Key.Enter && !e.Handled)
            {
                SaveButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }
            // Handle Escape key to cancel
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            // Unsubscribe from theme changes to prevent memory leaks
            ThemeService.Instance.ThemeChanged -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}