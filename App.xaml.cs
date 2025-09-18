using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace SportClub
{
    public partial class App : Application
    {
        public static void ChangeTheme(string themeName)
        {
            var app = (App)Current;

             
            var dictionariesToRemove = new List<ResourceDictionary>();
            foreach (ResourceDictionary dict in Current.Resources.MergedDictionaries)
            {
                if (dict.Source != null &&
                    (dict.Source.OriginalString.Contains("LightTheme.xaml") ||
                     dict.Source.OriginalString.Contains("DarkTheme.xaml") ||
                     dict.Source.OriginalString.Contains("DefaultTheme.xaml")))
                {
                    dictionariesToRemove.Add(dict);
                }
            }

            foreach (var dict in dictionariesToRemove)
            {
                Current.Resources.MergedDictionaries.Remove(dict);
            }

           
            ResourceDictionary newTheme;
            switch (themeName)
            {
                case "Dark":
                    newTheme = new ResourceDictionary { Source = new Uri("/Themes/DarkTheme.xaml", UriKind.Relative) };
                    break;
                case "Light":
                    newTheme = new ResourceDictionary { Source = new Uri("/Themes/LightTheme.xaml", UriKind.Relative) };
                    break;
                default:
                    newTheme = new ResourceDictionary { Source = new Uri("/Themes/DefaultTheme.xaml", UriKind.Relative) };
                    break;
            }

            Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}