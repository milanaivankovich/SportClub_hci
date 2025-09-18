using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SportClub.Services
{
    public class ThemeService
    {
        public static readonly ThemeService Instance = new ThemeService();

        public event EventHandler ThemeChanged;

        private ResourceDictionary _currentTheme;
        private readonly Dictionary<string, Uri> _themes;

        private ThemeService()
        {
            _themes = new Dictionary<string, Uri>
            {
                { "Light", new Uri("Themes/LightTheme.xaml", UriKind.Relative) },
                { "Dark", new Uri("Themes/DarkTheme.xaml", UriKind.Relative) },
                { "Default", new Uri("Themes/DefaultTheme.xaml", UriKind.Relative) }
            };
        }

        public void ApplyTheme(string themeName)
        {
            var app = Application.Current;
            if (app == null) return;

            try
            {
                
                RemoveCurrentTheme(app);

                if (_themes.TryGetValue(themeName, out Uri themeUri))
                {
                    _currentTheme = new ResourceDictionary { Source = themeUri };
                    app.Resources.MergedDictionaries.Add(_currentTheme);

                   
                    ApplyThemeToWindows();

                    
                    ThemeChanged?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Theme application error: {ex.Message}");
            }
        }

        private void RemoveCurrentTheme(Application app)
        {
            if (_currentTheme != null)
            {
                app.Resources.MergedDictionaries.Remove(_currentTheme);
            }

            
            var dictionariesToRemove = app.Resources.MergedDictionaries
                .Where(dict => dict.Source != null &&
                              (dict.Source.OriginalString.Contains("LightTheme.xaml") ||
                               dict.Source.OriginalString.Contains("DarkTheme.xaml") ||
                               dict.Source.OriginalString.Contains("DefaultTheme.xaml")))
                .ToList();

            foreach (var dict in dictionariesToRemove)
            {
                app.Resources.MergedDictionaries.Remove(dict);
            }
        }

        private void ApplyThemeToWindows()
        {
            var app = Application.Current;
            if (app?.Windows == null || _currentTheme == null) return;

            foreach (Window window in app.Windows)
            {
                try
                {
                    
                    if (_currentTheme.Contains("BackgroundBrush"))
                    {
                        var backgroundBrush = _currentTheme["BackgroundBrush"] as Brush;
                        if (backgroundBrush != null)
                        {
                            window.Background = backgroundBrush;
                        }
                    }

                   
                    window.UpdateDefaultStyle();
                    window.InvalidateVisual();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Window theme update error: {ex.Message}");
                }
            }
        }

        public void ApplyFont(string fontFamily, double fontSize)
        {
            var app = Application.Current;
            if (app == null) return;

            try
            {
                var font = new FontFamily(fontFamily);
                app.Resources["GlobalFontFamily"] = font;
                app.Resources["GlobalFontSize"] = fontSize;

               
                foreach (Window window in app.Windows)
                {
                    window.FontFamily = font;
                    window.FontSize = fontSize;
                }
            }
            catch (Exception)
            {
                
                app.Resources["GlobalFontFamily"] = new FontFamily("Segoe UI");
                app.Resources["GlobalFontSize"] = 14.0;
            }
        }

        public bool IsThemeAvailable(string themeName)
        {
            return _themes.ContainsKey(themeName);
        }

        public IEnumerable<string> GetAvailableThemes()
        {
            return _themes.Keys;
        }

        public string GetCurrentThemeName()
        {
            if (_currentTheme?.Source == null) return "Default";

            var currentUri = _currentTheme.Source.OriginalString;
            return _themes.FirstOrDefault(kvp => kvp.Value.OriginalString == currentUri).Key ?? "Default";
        }
    }
}