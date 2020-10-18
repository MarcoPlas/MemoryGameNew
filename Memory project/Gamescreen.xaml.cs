using System;
using System.Collections.Generic;
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

        Random rnd = new Random();

        public Gamescreen()
        {
            InitializeComponent();
            AddImages();
            MyButton.FontSize = 22;
            Grid.SetColumn(MyButton, 7);
        }

        int turns = 0;

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
            turns++;
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
            if (turns == 2)
            {
                MessageBox.Show(Convert.ToString(turns));
                turns -= 2;
            }
        }

        public List<ImageSource> GetImageList()
        {
            List<ImageSource> result = new List<ImageSource>();

            for (int i = 0; i < 16; i++)
            {
                int nr = i % 8 + 1;
                Uri path = new Uri("Images/" + nr + ".png", UriKind.Relative);
                result.Add(new BitmapImage(path));

            }
            return result;
        }



        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hoi");

        }
    }
}
