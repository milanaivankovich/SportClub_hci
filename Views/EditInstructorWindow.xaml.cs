using System.Windows;
using SportClub.Models;

namespace SportClub.Views
{
    public partial class EditInstructorWindow : Window
    {
        private Instructor _instructor;

        public EditInstructorWindow(Instructor instructor)
        {
            InitializeComponent();
            _instructor = instructor;

            ImeTextBox.Text = _instructor.FirstName;
            PrezimeTextBox.Text = _instructor.LastName;
            UsernameTextBox.Text = _instructor.Username;
            PasswordBox.Password = _instructor.Password; // Note: In production, handle passwords securely
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }

            _instructor.FirstName = ImeTextBox.Text;
            _instructor.LastName = PrezimeTextBox.Text;
            _instructor.Username = UsernameTextBox.Text;
            _instructor.Password = PasswordBox.Password; // Note: Hash in production

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