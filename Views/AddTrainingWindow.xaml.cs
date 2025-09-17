using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SportClub.Services;

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

            // Apply current theme to window
            ApplyTheme();

            // Subscribe to theme change events
            ThemeService.Instance.ThemeChanged += OnThemeChanged;
        }

        private void ApplyTheme()
        {
            // Ensure the window background is properly set from the theme
            var backgroundBrush = TryFindResource("BackgroundBrush") as Brush;
            if (backgroundBrush != null)
            {
                this.Background = backgroundBrush;
            }

            // Apply global font settings if they exist
            var fontFamily = Application.Current.Resources["GlobalFontFamily"] as FontFamily;
            var fontSize = Application.Current.Resources["GlobalFontSize"] as double?;

            if (fontFamily != null)
            {
                this.FontFamily = fontFamily;
            }

            if (fontSize.HasValue)
            {
                this.FontSize = fontSize.Value;
            }
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validation with themed message box
            if (string.IsNullOrEmpty(NameTextBox.Text) ||
                TypeComboBox.SelectedItem == null ||
                DatePicker.SelectedDate == null ||
                string.IsNullOrEmpty(TimeTextBox.Text))
            {
                ShowThemedMessageBox("Upozorenje", "Molimo popunite sva polja.", MessageBoxImage.Warning);
                return;
            }

            // Parse time with exact format
            if (DateTime.TryParseExact(TimeTextBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                TrainingName = NameTextBox.Text;
                TrainingType = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                TrainingDateTime = DatePicker.SelectedDate.Value.Date + time.TimeOfDay;

                DialogResult = true;
                Close();
            }
            else
            {
                ShowThemedMessageBox("Greška", "Molimo unesite validno vrijeme u formatu HH:mm.", MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ShowThemedMessageBox(string title, string message, MessageBoxImage icon)
        {
            // Create a custom themed message box window
            var messageWindow = new Window
            {
                Title = title,
                Width = 350,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this,
                Background = TryFindResource("BackgroundBrush") as Brush ?? Brushes.White
            };

            var grid = new System.Windows.Controls.Grid { Margin = new Thickness(20) };
            grid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = GridLength.Auto });

            var textBlock = new System.Windows.Controls.TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = TryFindResource("TextBrush") as Brush ?? Brushes.Black
            };
            System.Windows.Controls.Grid.SetRow(textBlock, 0);
            grid.Children.Add(textBlock);

            var button = new System.Windows.Controls.Button
            {
                Content = "OK",
                Width = 80,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Right,
                Background = TryFindResource("PrimaryBrush") as Brush ?? Brushes.DarkRed,
                Foreground = Brushes.White
            };
            button.Click += (s, e) => messageWindow.Close();
            System.Windows.Controls.Grid.SetRow(button, 1);
            grid.Children.Add(button);

            messageWindow.Content = grid;
            messageWindow.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            // Unsubscribe from theme change events
            ThemeService.Instance.ThemeChanged -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}