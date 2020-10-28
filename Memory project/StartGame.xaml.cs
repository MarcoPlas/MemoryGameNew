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
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class StartGame : Page
	{

		public string player1;
		public string player2;

		public StartGame()
		{
			InitializeComponent();
		}
		public void Back_Home_Screen(object sender, RoutedEventArgs e)
		{
			Homescherm homescherm = new Homescherm();
			this.NavigationService.Navigate(homescherm);
		}
		public void To_Game_Screen(object sender, RoutedEventArgs e)
		{
			//Gamescreen gamescreen = new Gamescreen(player1, player2);

			player1 = Inputplayer1.Text;
			player2 = Inputplayer2.Text;

			if (player1 == "")
			{
				player1 = "Player 1";
			}
			if (player2 == "")
			{
				player2 = "Player 2";
			}
			
			this.NavigationService.Navigate(new Gamescreen(player1, player2));

		}



	}
}
