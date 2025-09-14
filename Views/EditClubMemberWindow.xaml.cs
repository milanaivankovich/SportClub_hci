using System;
using System.Windows;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class EditClubMemberWindow : Window
    {
        private ClubMember _clubMember;

        public EditClubMemberWindow(ClubMember clubMember)
        {
            InitializeComponent();
            _clubMember = clubMember;

            ImeTextBox.Text = _clubMember.FirstName;
            PrezimeTextBox.Text = _clubMember.LastName;
            DatumRodjenjaDatePicker.SelectedDate = _clubMember.BirthDate;
            AktivanCheckBox.IsChecked = _clubMember.Active;
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

            _clubMember.FirstName = ImeTextBox.Text;
            _clubMember.LastName = PrezimeTextBox.Text;
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
    }
}