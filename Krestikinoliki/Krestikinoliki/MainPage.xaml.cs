using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Krestikinoliki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            FirstPlayer_manual();
            NewGame_Clicked();
        }
        BoxView box;
        Label stat;
        Button newGame, randomPlayer;
        public bool first_player;
        
        void NewGame_Clicked()
        {
            Grid grid = new Grid();
            for (int g = 0; g < 4; g++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int f = 0; f < 3; f++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box = new BoxView {Color=Color.FromRgb(0, 0, 0)};
                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    box.GestureRecognizers.Add(tap);
                    tap.Tapped += Tap_Tapped;
                }
            }
            newGame = new Button { Text = "Кто первый?" };
            
            grid.Children.Add(newGame, 0, 3);
            Grid.SetColumnSpan(newGame, 2);
            randomPlayer = new Button { Text = "Новая игра" };
            grid.Children.Add(randomPlayer, 2, 3);
            Grid.SetColumnSpan(randomPlayer, 2);
            randomPlayer.Clicked += Randomplayer_Clicked;
            Content = grid;

        }
        private void newGame_Clicked(object sender, EventArgs e)
        {
            FirstPlayer_manual();
            NewGame_Clicked();
        }
        private void Randomplayer_Clicked(object sender, EventArgs e)
        {
            FirstPlayer();
            NewGame_Clicked();
        }
        BoxView box_clik;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            {
                box_clik = sender as BoxView;
                if (box_clik.Color == Color.FromRgb(0, 0, 0) && first_player)
                {
                    box_clik.Color = Color.FromRgb(255, 0, 0);
                    first_player = false;
                }
                else if (box_clik.Color == Color.FromRgb(0, 0, 0) && !first_player)
                {
                    box_clik.Color = Color.FromRgb(0, 255, 0);
                    first_player = true;
                }
                else
                {
                    DisplayAlert("Сообщение", "Противник уже выбрал это поле", "Ok");
                }
            };
        }

        Random rnd = new Random();
        private bool FirstPlayer()
        {
            int player = rnd.Next(0, 2);
            if (player == 1)
            {
                first_player = true;
            }
            else
            {
                first_player = false;
            }
            return first_player;
        }

        public async void FirstPlayer_manual()
        {
            string first_player_manual = await DisplayPromptAsync("Кто первый?", "Красный -1, Зеленый -2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (first_player_manual == "1")
            {
                first_player = true;
            }
            else
            {
                first_player = false;
            }
        }
    }
}