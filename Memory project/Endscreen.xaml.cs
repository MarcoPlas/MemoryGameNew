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
using System.Xml;

namespace Memory_project
{
	/// <summary>
	/// Interaction logic for Endscreen.xaml
	/// </summary>
	public partial class Endscreen : Page
	{

		string playername1;
		string playername2;
		int player1score = 0;
		int player2score = 0;
		
		public Endscreen(int player1_score, int player2_score, string player1, string player2)
		{
			InitializeComponent();
			player1score = player1_score;
			player2score = player2_score;
			playername1 = player1;
			playername2 = player2;
            if (player1score >= player2score)
            {
				Winner.Content = playername1;
				Loser.Content = playername2;
				ScoreWinner.Content = player1score;
				ScoreLoser.Content = player2score;
            }
            else if (player2score > player1score)
            {
				ScoreWinner.Content = player2score;
				ScoreLoser.Content = player1score;
				Winner.Content = playername2;
				Loser.Content = playername1;
            }
			output();


		}
		public void Back_Home_Screen(object sender, RoutedEventArgs e)
		{
			Homescherm homescherm = new Homescherm();
			this.NavigationService.Navigate(homescherm);
		}
		public void Back_Start_Game(object sender, RoutedEventArgs e)
		{
			StartGame startgame = new StartGame();
			this.NavigationService.Navigate(startgame);
		}

		private void output()
        {
			Winner.Content = (playername1);
			Loser.Content = (playername2);
        }
		



	}
}