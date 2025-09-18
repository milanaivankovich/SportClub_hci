using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SportClub.Models;
using SportClub.Services;

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

            
            ApplyTheme();

           
            ThemeService.Instance.ThemeChanged += OnThemeChanged;
        }

        private void ApplyTheme()
        {
           
            var backgroundBrush = TryFindResource("BackgroundBrush") as Brush;
            if (backgroundBrush != null)
            {
                this.Background = backgroundBrush;
            }

           
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
            
            if (string.IsNullOrWhiteSpace(NazivTextBox.Text) ||
                string.IsNullOrWhiteSpace(MjestoTextBox.Text) ||
                DatumDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(VrijemeTextBox.Text))
            {
                ShowThemedMessageBox("Upozorenje", "Sva polja su obavezna!", MessageBoxImage.Warning);
                return;
            }

            
            if (!DateTime.TryParseExact(VrijemeTextBox.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                ShowThemedMessageBox("Greška", "Unesite ispravan format vremena (HH:mm)!", MessageBoxImage.Error);
                return;
            }

            
            DateTime selectedDateTime = DatumDatePicker.SelectedDate.Value;
            selectedDateTime = selectedDateTime.Date + time.TimeOfDay;

           
            if (selectedDateTime < DateTime.Now)
            {
                ShowThemedMessageBox("Upozorenje", "Datum i vrijeme takmičenja ne mogu biti u prošlosti!", MessageBoxImage.Warning);
                return;
            }

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

        private void ShowThemedMessageBox(string title, string message, MessageBoxImage icon)
        {
            
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
            ThemeService.Instance.ThemeChanged -= OnThemeChanged;
            base.OnClosed(e);
        }
    }
}