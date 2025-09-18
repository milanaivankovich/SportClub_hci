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
            DatumRodjenjaDatePicker.SelectedDate = DateTime.Now.AddYears(-18); 

           
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
            
            if (string.IsNullOrWhiteSpace(ImeTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrezimeTextBox.Text) ||
                DatumRodjenjaDatePicker.SelectedDate == null)
            {
                ShowThemedMessageBox("Upozorenje", "Ime, prezime i datum rođenja su obavezna polja!", MessageBoxImage.Warning);
                return;
            }

            
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