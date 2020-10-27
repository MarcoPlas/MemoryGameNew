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


namespace Memory_project
{
	/// <summary>
	/// Interaction logic for Gamescreen.xaml
	/// </summary>
	public partial class Gamescreen : Page
	{

        List<int> imageNumber = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 }; //makes a list of numbers
        Random random = new Random(); //creates a variable called random

        public Gamescreen()
        {
            InitializeComponent();
            AddImages();
            Grid.SetColumn(MyButton, 7);
            Grid.SetColumn(MyButton_1, 7);
            Grid.SetRow(MyButton_1, 1);
        }

        public void AddImages()
        {
            List<ImageSource> images = GetImageList();
            for (int r = 1; r <= 4; r++)
            {
                for (int c = 2; c < 6; c++)
                {

                    Image BackgroundImage = new Image();
                    Uri path = new Uri("Images/Backside.png", UriKind.Relative);
                    BackgroundImage.Source = new BitmapImage(path);
                    BackgroundImage.Margin = new Thickness(4);
                    BackgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    BackgroundImage.MouseDown += new MouseButtonEventHandler(TurnCard);
                    Grid.SetColumn(BackgroundImage, c);
                    Grid.SetRow(BackgroundImage, r);
                    GameGrid.Children.Add(BackgroundImage);
                }
            }
        }

        //TODO: Randomise Kaarten
        //TODO: Kaarten weer terug draaien
        //TODO: Een 6x6 veld en 8x8 veld


        public void TurnCard(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }

        public List<ImageSource> GetImageList()
        {
            List<ImageSource> result = new List<ImageSource>();

            for (int a = 0; a < 16; a++)
            {
                for (int i = 0; i < imageNumber.Count;) //keeps going until list is empty
                {
                    int numberRandom = random.Next(0, imageNumber.Count); //selects a random number between 0 and the amount of numbers still in the list
                    int numberValue = imageNumber[numberRandom]; //converts numberRandom into a usable value
                    Console.WriteLine(numberValue); //writes the numberValue as a line for testing purposes
                    imageNumber.RemoveAt(numberRandom); //removes the selected number from the list so it can't be selected again
                    Uri path = new Uri("Images/" + numberValue + ".png", UriKind.Relative);
                    result.Add(new BitmapImage(path));
                }
            }
            return result;
        }


        public void Back_Start_Game(object sender, RoutedEventArgs e)
        {
            StartGame startgame = new StartGame();
            this.NavigationService.Navigate(startgame);
        }
        public void To_End_Screen(object sender, RoutedEventArgs e)
        {
            Endscreen endscreen = new Endscreen();
            this.NavigationService.Navigate(endscreen);
        }
    }
}
