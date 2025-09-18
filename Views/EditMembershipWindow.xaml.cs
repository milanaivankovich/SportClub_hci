using System;
using System.Windows;
using System.Windows.Input;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class EditMembershipWindow : Window
    {
        private Membership _membership;

        public EditMembershipWindow(Membership membership)
        {
            InitializeComponent();
            _membership = membership;
 
            ThemeService.Instance.ThemeChanged += OnThemeChanged;

             
            ApplyCurrentTheme();

            
            LoadMembershipData();

            
            NazivTextBox.Focus();
        }

        private void LoadMembershipData()
        {
            NazivTextBox.Text = _membership.Type;
            CijenaTextBox.Text = _membership.Price.ToString();
            TrajanjeTextBox.Text = _membership.Duration.Days.ToString();
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
            if (string.IsNullOrWhiteSpace(NazivTextBox.Text) ||
                string.IsNullOrWhiteSpace(CijenaTextBox.Text) ||
                string.IsNullOrWhiteSpace(TrajanjeTextBox.Text))
            {
                MessageBox.Show("Sva polja su obavezna!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(CijenaTextBox.Text, out int cijena) || cijena <= 0)
            {
                MessageBox.Show("Unesite ispravnu cijenu!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                CijenaTextBox.Focus();
                CijenaTextBox.SelectAll();
                return;
            }

            if (!int.TryParse(TrajanjeTextBox.Text, out int trajanjeDani) || trajanjeDani <= 0)
            {
                MessageBox.Show("Unesite ispravno trajanje u danima!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                TrajanjeTextBox.Focus();
                TrajanjeTextBox.SelectAll();
                return;
            }
            
            if (NazivTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Naziv članarine mora imati najmanje 3 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                NazivTextBox.Focus();
                return;
            }

            _membership.Type = NazivTextBox.Text.Trim();
            _membership.Price = cijena;
            _membership.Duration = TimeSpan.FromDays(trajanjeDani);

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CijenaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void TrajanjeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
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