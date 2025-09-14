using System;
using System.Windows;
using System.Windows.Input;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class AddMembershipWindow : Window
    {
        public Membership NewMembership { get; private set; }

        public AddMembershipWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NazivTextBox.Text) ||
                string.IsNullOrWhiteSpace(CijenaTextBox.Text) ||
                string.IsNullOrWhiteSpace(TrajanjeTextBox.Text))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }

            if (!int.TryParse(CijenaTextBox.Text, out int cijena) || cijena <= 0)
            {
                MessageBox.Show("Unesite ispravnu cijenu!");
                return;
            }

            if (!int.TryParse(TrajanjeTextBox.Text, out int trajanjeDani) || trajanjeDani <= 0)
            {
                MessageBox.Show("Unesite ispravno trajanje u danima!");
                return;
            }

            NewMembership = new Membership
            {
                Type = NazivTextBox.Text,
                Price = cijena,
                Duration = TimeSpan.FromDays(trajanjeDani)
            };

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
    }
}