using System;
using System.Runtime.InteropServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using PokeDex.Core.Utils;

namespace PokeDex.UwpApp.Utils.Converter
{
    public class TypeToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var pokeType = value.ToString();
            if (pokeType.IsNeitherNullNorEmpty())
            {
                switch (pokeType)
                {
                    case "grass":
                        return Application.Current.Resources["GrassTypeBrush"] as SolidColorBrush;
                    case "water":
                        return Application.Current.Resources["WaterTypeBrush"] as SolidColorBrush;
                    case "posion":
                        return Application.Current.Resources["PosionTypeBrush"] as SolidColorBrush;
                    case "flying":
                        return Application.Current.Resources["FlyingTypeBrush"] as SolidColorBrush;
                    case "fire":
                        return Application.Current.Resources["FireTypeBrush"] as SolidColorBrush;
                    case "bug":
                        return Application.Current.Resources["BugTypeBrush"] as SolidColorBrush;
                    case "normal":
                        return Application.Current.Resources["NormalTypeBrush"] as SolidColorBrush;
                    case "electric":
                        return Application.Current.Resources["ElectricTypeBrush"] as SolidColorBrush;
                    case "ground":
                        return Application.Current.Resources["GroundTypeBrush"] as SolidColorBrush;
                    case "fairy":
                        return Application.Current.Resources["FairyTypeBrush"] as SolidColorBrush;
                    case "fighting":
                        return Application.Current.Resources["FightingTypeBrush"] as SolidColorBrush;
                    case "psychic":
                        return Application.Current.Resources["PsychicTypeBrush"] as SolidColorBrush;
                    case "rock":
                        return Application.Current.Resources["RockTypeBrush"] as SolidColorBrush;
                    case "steel":
                        return Application.Current.Resources["SteelTypeBrush"] as SolidColorBrush;
                    case "ice":
                        return Application.Current.Resources["IceTypeBrush"] as SolidColorBrush;
                    case "ghost":
                        return Application.Current.Resources["GhostTypeBrush"] as SolidColorBrush;
                    case "dragon":
                        return Application.Current.Resources["DragonTypeBrush"] as SolidColorBrush;
                }
            }

            return Application.Current.Resources["GrassTypeBrush"] as SolidColorBrush;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}