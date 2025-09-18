using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class EditCompetitionWindow : Window
    {
        private Competition _competition;
        private readonly Regex _timeRegex = new Regex(@"^[0-9:]+$");

        public EditCompetitionWindow(Competition competition)
        {
            InitializeComponent();
            _competition = competition;

            
            ThemeService.Instance.ThemeChanged += OnThemeChanged;

            
            ApplyCurrentTheme();

            
            LoadCompetitionData();

            
            NazivTextBox.Focus();
        }

        private void LoadCompetitionData()
        {
            NazivTextBox.Text = _competition.Name;
            MjestoTextBox.Text = _competition.Location;
            DatumDatePicker.SelectedDate = _competition.Date;
            VrijemeTextBox.Text = _competition.Date.ToString("HH:mm");
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
                string.IsNullOrWhiteSpace(MjestoTextBox.Text) ||
                DatumDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(VrijemeTextBox.Text))
            {
                MessageBox.Show("Sva polja su obavezna!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

             
            if (!DateTime.TryParseExact(VrijemeTextBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                MessageBox.Show("Unesite ispravan format vremena (HH:mm)!\nPrimjer: 14:30",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                VrijemeTextBox.Focus();
                VrijemeTextBox.SelectAll();
                return;
            }

            
            DateTime selectedDateTime = DatumDatePicker.SelectedDate.Value;
            selectedDateTime = selectedDateTime.Date + time.TimeOfDay;

            if (selectedDateTime < DateTime.Now.AddMinutes(-30))  
            {
                var result = MessageBox.Show("Izabrano vrijeme je u prošlosti. Da li želite nastaviti?",
                                           "Potvrda",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            
            if (NazivTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Naziv takmičenja mora imati najmanje 3 karaktera!",
                               "Validacija",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                NazivTextBox.Focus();
                return;
            }

             
            _competition.Name = NazivTextBox.Text.Trim();
            _competition.Location = MjestoTextBox.Text.Trim();
            _competition.Date = selectedDateTime;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void VrijemeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
             
            e.Handled = !_timeRegex.IsMatch(e.Text);

             
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

                
                if (newText.Length > 5)
                {
                    e.Handled = true;
                    return;
                }

                 
                if (newText.Length == 2 && !newText.Contains(":"))
                {
                    textBox.Text = newText + ":";
                    textBox.SelectionStart = textBox.Text.Length;
                    e.Handled = true;
                }
            }
        }

        private void SetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            VrijemeTextBox.Text = DateTime.Now.ToString("HH:mm");
            VrijemeTextBox.Focus();
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