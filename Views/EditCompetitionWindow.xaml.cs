using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class EditCompetitionWindow : Window
    {
        private Competition _competition;

        public EditCompetitionWindow(Competition competition)
        {
            InitializeComponent();
            _competition = competition;

            NazivTextBox.Text = _competition.Name;
            MjestoTextBox.Text = _competition.Location;
            DatumDatePicker.SelectedDate = _competition.Date;
            VrijemeTextBox.Text = _competition.Date.ToString("HH:mm");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NazivTextBox.Text) ||
                string.IsNullOrWhiteSpace(MjestoTextBox.Text) ||
                DatumDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(VrijemeTextBox.Text))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }

            // Parse time
            if (!DateTime.TryParseExact(VrijemeTextBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                MessageBox.Show("Unesite ispravan format vremena (HH:mm)!");
                return;
            }

            // Combine date and time
            DateTime selectedDateTime = DatumDatePicker.SelectedDate.Value;
            selectedDateTime = selectedDateTime.Date + time.TimeOfDay;

            _competition.Name = NazivTextBox.Text;
            _competition.Location = MjestoTextBox.Text;
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
            Regex regex = new Regex("^[0-9:]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void SetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            VrijemeTextBox.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}