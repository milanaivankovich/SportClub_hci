using System;
using System.Windows;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class AddClubMemberWindow : Window
    {
        public ClubMember NewClubMember { get; private set; }

        public AddClubMemberWindow()
        {
            InitializeComponent();
            DatumRodjenjaDatePicker.SelectedDate = DateTime.Now.AddYears(-18); // Default to 18 years ago
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                DatumRodjenjaDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Ime, prezime i datum rođenja su obavezna polja!");
                return;
            }

            NewClubMember = new ClubMember
            {
                FirstName = ImeTextBox.Text,
                LastName = PrezimeTextBox.Text,
                BirthDate = DatumRodjenjaDatePicker.SelectedDate.Value,
                Active = AktivanCheckBox.IsChecked ?? true
            };

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}