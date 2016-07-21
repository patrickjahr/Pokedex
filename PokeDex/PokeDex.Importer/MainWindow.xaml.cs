using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using PokeAPI;
using PokeAPI.Objects;
using PokeDex.Core.Utils;

namespace PokeDex.Importer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Import_OnClick(object sender, RoutedEventArgs e)
        {
            btnImport.IsEnabled = false;
            await ImportPokemonToJson();
            //await ImportItemsToJson();
            //await ImportLocationsToJson();
            //await ImportMovesnToJson();
            btnImport.IsEnabled = true;
        }

        private async Task ImportPokemonToJson()
        {
            var listOfPokemon = new List<ImportPokemon>();
            for (int i = 1; i < 150; i++)
            {
                try
                {
                    var currentPokemon = await DataFetcher.GetApiObject<Pokemon>(i);
                    var specie = await currentPokemon.Species.GetObject();
                    var pokeNames = specie.Names.ToDictionary(language => language.Language.Name,name => name.Name);
                    var pokemonDescription = new Dictionary<string, string>();
                    specie.FlavorTexts.ForEach(
                        item =>
                        {
                            var description =
                                String.Concat(
                                    specie.FlavorTexts.Where(s => s.Language.Name == item.Language.Name)
                                        .Select(s => s.FlavorText));
                            if(!pokemonDescription.ContainsKey(item.Language.Name))
                                pokemonDescription.Add(item.Language.Name, description);
                            
                        });

                    var pokemon = new ImportPokemon
                    {
                        Id = currentPokemon.ID,
                        Names = pokeNames,
                        ImageUrl = currentPokemon.Sprites.FrontMale,
                        Descriptions = pokemonDescription,
                        Types = currentPokemon.Types.Select(item => item.Type.Name).ToList()
                    };
                    listOfPokemon.Add(pokemon);
                    importInfo.Text += $"Add Pokemon {currentPokemon.ID}\r\n";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            importInfo.Text += "Finish";
            
            var jsonString = JsonConvert.SerializeObject(listOfPokemon);

            System.IO.File.WriteAllText(@"C:\temp\pokemon.json", jsonString, Encoding.UTF8);
        }
        private async Task ImportItemsToJson()
        {
            var listOfItems = new List<Item>();
            for (int i = 1; i < 722; i++)
            {
                try
                {
                    var currentItem = await DataFetcher.GetApiObject<Item>(i);
                    listOfItems.Add(currentItem);
                    importInfo.Text += $"Add Item {currentItem.ID} with the Name {currentItem.Name}\r\n";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            importInfo.Text += "Finish";

            var jsonString = JsonConvert.SerializeObject(listOfItems);

            System.IO.File.WriteAllText(@"C:\temp\items.json", jsonString, Encoding.UTF8);
        }

        private async Task ImportMovesnToJson()
        {
            var listOfMoves = new List<Move>();
            for (int i = 1; i < 722; i++)
            {
                try
                {
                    var currentMove = await DataFetcher.GetApiObject<Move>(i);
                    listOfMoves.Add(currentMove);
                    importInfo.Text += $"Add Move {currentMove.ID} with the Name {currentMove.Name}\r\n";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            importInfo.Text += "Finish";

            var jsonString = JsonConvert.SerializeObject(listOfMoves);

            System.IO.File.WriteAllText(@"C:\temp\moves.json", jsonString, Encoding.UTF8);
            btnImport.IsEnabled = true;
        }

        private async Task ImportLocationsToJson()
        {
            var listOfLoactions = new List<Location>();
            for (int i = 1; i < 722; i++)
            {
                try
                {
                    var currentLocation = await DataFetcher.GetApiObject<Location>(i);
                    listOfLoactions.Add(currentLocation);
                    importInfo.Text += $"Add Location {currentLocation.ID} with the Name {currentLocation.Name}\r\n";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            importInfo.Text += "Finish";

            var jsonString = JsonConvert.SerializeObject(listOfLoactions);

            System.IO.File.WriteAllText(@"C:\temp\loactions.json", jsonString, Encoding.UTF8);
            btnImport.IsEnabled = true;
        }
    }
}
