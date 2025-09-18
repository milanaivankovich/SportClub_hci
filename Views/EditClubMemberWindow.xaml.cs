using System;
using System.Windows;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class EditClubMemberWindow : Window
    {
        private ClubMember _clubMember;

        public EditClubMemberWindow(ClubMember clubMember)
        {
            InitializeComponent();
            _clubMember = clubMember;

            
            ThemeService.Instance.ThemeChanged += OnThemeChanged;

             
            ApplyCurrentTheme();

             
            LoadMemberData();
        }

        private void LoadMemberData()
        {
            ImeTextBox.Text = _clubMember.FirstName;
            PrezimeTextBox.Text = _clubMember.LastName;
            DatumRodjenjaDatePicker.SelectedDate = _clubMember.BirthDate;
            AktivanCheckBox.IsChecked = _clubMember.Active;
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
                DatumRodjenjaDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Ime, prezime i datum rođenja su obavezna polja!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

             
            if (DatumRodjenjaDatePicker.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Datum rođenja ne može biti u budućnosti!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

             
            _clubMember.FirstName = ImeTextBox.Text.Trim();
            _clubMember.LastName = PrezimeTextBox.Text.Trim();
            _clubMember.BirthDate = DatumRodjenjaDatePicker.SelectedDate.Value;
            _clubMember.Active = AktivanCheckBox.IsChecked ?? true;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
             
            ThemeService.Instance.ThemeChanged -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}