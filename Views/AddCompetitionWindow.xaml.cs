using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class AddCompetitionWindow : Window
    {
        public Competition NewCompetition { get; private set; }

        public AddCompetitionWindow()
        {
            InitializeComponent();
            DatumDatePicker.SelectedDate = DateTime.Now;
            VrijemeTextBox.Text = DateTime.Now.ToString("HH:mm");
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

            NewCompetition = new Competition
            {
                Name = NazivTextBox.Text,
                Location = MjestoTextBox.Text,
                Date = selectedDateTime
            };

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