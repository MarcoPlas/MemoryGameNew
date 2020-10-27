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

		
		public Endscreen(string player1, string player2)
		{
			InitializeComponent();

			playername1 = player1;
			playername2 = player2;

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