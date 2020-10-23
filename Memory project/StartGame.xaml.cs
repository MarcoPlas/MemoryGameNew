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
			Gamescreen gamescreen = new Gamescreen();
			this.NavigationService.Navigate(gamescreen);
		}
	}
}
