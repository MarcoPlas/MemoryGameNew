using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using System.Threading;

namespace Memory_project
{
	/// <summary>
	/// Interaction logic for Gamescreen.xaml
	/// </summary>
	public partial class Gamescreen : Page
	{
        public string player_1; //name of player 1
        public string player_2; //name of player 2
        object first = null;
        object second = null;
        object first_place = null;
        object second_place = null;
        List<ImageSource> images;
        List<int> imageNumber = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 }; //makes a list of numbers
        Random random = new Random(); //creates a variable called random
        bool player1turn = true;

        public Gamescreen(string player1, string player2)
        {
            InitializeComponent();
            player_1 = player1; 
            player_2 = player2;
            images = GetImageList(); //Goes to the function GetImageList. In that function the front of the cards will be added

            player01.Content = player_1; //set player name 1 on screen
            player02.Content = player_2; //set player name 2 on screen


            AddImages(images); 
            Grid.SetColumn(MyButton, 7); 
            Grid.SetColumn(MyButton_1, 7);
            Grid.SetRow(MyButton_1, 1);
        }



        public void AddImages(List<ImageSource> images)
        {
            for (int r = 1; r < 5; r++) //in which rows the images needed to be placed
            {
                for (int c = 2; c < 6; c++) //in which colums the images needed to be placed
                {
                    Image BackgroundImage = new Image(); //Make image as backside card 
                    Uri path = new Uri("Images/Backside.png", UriKind.Relative); //The uri of the backside card
                    BackgroundImage.Source = new BitmapImage(path); //Display the backside card
                    BackgroundImage.Margin = new Thickness(4); //margin of the backside card
                    BackgroundImage.Tag = images.First(); 
                    images.RemoveAt(0); 
                    BackgroundImage.MouseDown += new MouseButtonEventHandler(TurnCard); //when clicked on card it goes to the funtion TurnCard. TurnCard function will show the front
                    Grid.SetColumn(BackgroundImage, c); //Set the columns of the background images
                    Grid.SetRow(BackgroundImage, r); //Set the rows of the background images
                    GameGrid.Children.Add(BackgroundImage); //Adding the images to the grid. Gamegrid is the name of the grid
                }
            }
        }
        //TODO: Kaarten weer terug draaien
        //TODO: Een 6x6 veld en 8x8 veld


        public async void TurnCard(object sender, MouseButtonEventArgs e)
        {

            Image card = (Image)sender; //Looks which image is clicked
            ImageSource front = (ImageSource)card.Tag; //checking which is the front card
            card.Source = front; //displays the front cards



            if (first == null)
            {
                first = card.Tag;
                first_place = card;
            }
            else
            {
                second = card.Tag;
                second_place = card;
                if (second_place == first_place)
                {
                    second_place = null;
                    second = null;
                }
                else
                {
                    if (first.ToString() == second.ToString())
                    {
                        GameGrid.IsHitTestVisible = false;
                        await Task.Delay(800);
                        ((Image)first_place).Source = null;
                        ((Image)second_place).Source = null;
                        first = null;
                        second = null;
                        GameGrid.IsHitTestVisible = true;
						if (player1turn == true) //check which player's turn it is
						{
                            MessageBox.Show("It's still player 1's turn"); //This message box is for testing purposes, should be removed later
                            //add a point to player 1's score here
                        }
						else
						{
                            MessageBox.Show("It's still player 2's turn"); //This message box is for testing purposes, should be removed later
                            //add a point to player 2's score here
                        }
                    }
                    else
                    {
                        //MessageBox.Show("test");
                        Uri path = new Uri("Images/Backside.png", UriKind.Relative);
                        //MessageBox.Show("test");
                        GameGrid.IsHitTestVisible = false;
                        await Task.Delay(800);
                        
                        ((Image)second_place).Source = new BitmapImage(path);
                        ((Image)first_place).Source = new BitmapImage(path);
                        first = null;
                        second = null;
                        GameGrid.IsHitTestVisible = true;
						if (player1turn == true) //check which player's turn it is
                        {
                            player1turn = false; //switch turn to player 2
                            MessageBox.Show("It's player 2's turn"); //This message box is for testing purposes, should be removed later
						}
						else
						{
                            player1turn = true; //switch turn to player 1
                            MessageBox.Show("It's player 1's turn"); //This message box is for testing purposes, should be removed later
                        }
                    }
                }
               
            }

        }

        public List<ImageSource> GetImageList()
        {
            List<ImageSource> result = new List<ImageSource>(); //list with the images

            
                for (int i = 0; i < imageNumber.Count;) //keeps going until list is empty
                {
                    int numberRandom = random.Next(0, imageNumber.Count); //selects a random number between 0 and the amount of numbers still in the list
                    int numberValue = imageNumber[numberRandom]; //converts numberRandom into a usable value
                    imageNumber.RemoveAt(numberRandom); //removes the selected number from the list so it can't be selected again
                    Uri path = new Uri("Images/" + numberValue + ".png", UriKind.Relative); //Making an uri for the path of the card images
                    result.Add(new BitmapImage(path)); //Adding the image on it's place
                }
            
            return result; 
        }



        public void Back_Start_Game(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StartGame()); //navigate to the StartGame screen
        }
        public void To_End_Screen(object sender, RoutedEventArgs e) //Click function of the button
        {
            this.NavigationService.Navigate(new Endscreen(player_1, player_2)); //navigate to endscreen and send the name from the players
            //TODO: Send score
            //TODO: auto to endscreen when all cards are matched
        }

        
    }
}
