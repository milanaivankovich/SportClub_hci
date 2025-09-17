using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SportClub.Models;
using SportClub.Services;

namespace SportClub.Views
{
    public partial class AddMembershipWindow : Window
    {
        public Membership NewMembership { get; private set; }

        public AddMembershipWindow()
        {
            InitializeComponent();

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
            if (string.IsNullOrWhiteSpace(NazivTextBox.Text) ||
                string.IsNullOrWhiteSpace(CijenaTextBox.Text) ||
                string.IsNullOrWhiteSpace(TrajanjeTextBox.Text))
            {
                ShowThemedMessageBox("Upozorenje", "Sva polja su obavezna!", MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(CijenaTextBox.Text, out int cijena) || cijena <= 0)
            {
                ShowThemedMessageBox("Greška", "Unesite ispravnu cijenu (cijeli broj veći od 0)!", MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(TrajanjeTextBox.Text, out int trajanjeDani) || trajanjeDani <= 0)
            {
                ShowThemedMessageBox("Greška", "Unesite ispravno trajanje u danima (cijeli broj veći od 0)!", MessageBoxImage.Error);
                return;
            }

            NewMembership = new Membership
            {
                Type = NazivTextBox.Text.Trim(),
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