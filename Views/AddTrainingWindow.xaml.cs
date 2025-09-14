using System;
using System.Windows;
using System.Windows.Controls;

namespace SportClub.Views
{
    public partial class AddTrainingWindow : Window
    {
        public string TrainingName { get; private set; }
        public string TrainingType { get; private set; }
        public DateTime TrainingDateTime { get; private set; }

        public AddTrainingWindow()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Today;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) ||
                TypeComboBox.SelectedItem == null ||
                DatePicker.SelectedDate == null ||
                string.IsNullOrEmpty(TimeTextBox.Text))
            {
                MessageBox.Show("Molimo popunite sva polja.");
                return;
            }

            if (TimeSpan.TryParse(TimeTextBox.Text, out TimeSpan time))
            {
                TrainingName = NameTextBox.Text;
                TrainingType = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                TrainingDateTime = DatePicker.SelectedDate.Value.Add(time);

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Molimo unesite validno vrijeme (HH:mm).");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}