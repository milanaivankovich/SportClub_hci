using System;
using System.Windows;
using System.Windows.Media;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class AddClubMemberWindow : Window
    {
        public ClubMember NewClubMember { get; private set; }

        public AddClubMemberWindow()
        {
            InitializeComponent();
            DatumRodjenjaDatePicker.SelectedDate = DateTime.Now.AddYears(-18); // Default to 18 years ago

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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation with themed message box
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                DatumRodjenjaDatePicker.SelectedDate == null)
            {
                ShowThemedMessageBox("Upozorenje", "Ime, prezime i datum rođenja su obavezna polja!", MessageBoxImage.Warning);
                return;
            }

            // Additional validation for birth date
            if (DatumRodjenjaDatePicker.SelectedDate.Value > DateTime.Now)
            {
                ShowThemedMessageBox("Greška", "Datum rođenja ne može biti u budućnosti!", MessageBoxImage.Error);
                return;
            }

            NewClubMember = new ClubMember
            {
                FirstName = ImeTextBox.Text.Trim(),
                LastName = PrezimeTextBox.Text.Trim(),
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