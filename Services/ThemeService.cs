using System.Windows;
using System.Windows.Media;

namespace SportClub.Services
{
    public class ThemeService
    {
        public static readonly ThemeService Instance = new ThemeService();

        public event EventHandler ThemeChanged;

        private ResourceDictionary _currentTheme;

        public void ApplyTheme(string themeName)
        {
            var app = Application.Current;

            // Ukloni postojeću temu ako postoji
            if (_currentTheme != null)
            {
                app.Resources.MergedDictionaries.Remove(_currentTheme);
            }

            // Učitaj novu temu
            var themeUri = themeName switch
            {
                "Light" => new Uri("Themes/LightTheme.xaml", UriKind.Relative),
                "Dark" => new Uri("Themes/DarkTheme.xaml", UriKind.Relative),
                _ => new Uri("Themes/DefaultTheme.xaml", UriKind.Relative)
            };

            _currentTheme = new ResourceDictionary { Source = themeUri };
            app.Resources.MergedDictionaries.Add(_currentTheme);

            // Primijeni pozadinsku boju na sve prozore
            ApplyBackgroundToWindows();

            ThemeChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ApplyFont(string fontFamily, double fontSize)
        {
            var app = Application.Current;

            try
            {
                app.Resources["GlobalFontFamily"] = new FontFamily(fontFamily);
                app.Resources["GlobalFontSize"] = fontSize;

                // Primijeni font na sve trenutno otvorene prozore
                foreach (Window window in app.Windows)
                {
                    window.FontFamily = new FontFamily(fontFamily);
                    window.FontSize = fontSize;
                }
            }
            catch (Exception)
            {
                // Fallback na default font
                app.Resources["GlobalFontFamily"] = new FontFamily("Segoe UI");
                app.Resources["GlobalFontSize"] = 14.0;
            }
        }

        private void ApplyBackgroundToWindows()
        {
            var app = Application.Current;
            if (_currentTheme != null && _currentTheme.Contains("BackgroundBrush"))
            {
                var backgroundBrush = _currentTheme["BackgroundBrush"] as Brush;
                if (backgroundBrush != null)
                {
                    foreach (Window window in app.Windows)
                    {
                        window.Background = backgroundBrush;
                    }
                }
            }
        }
    }
}