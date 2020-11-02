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
using System.IO;

namespace Memory_project
{
	/// <summary>
	/// Interaction logic for Highscores.xaml
	/// </summary>
	public partial class Highscores : Page
	{
		string highestscore;
		string lowestscores;
		int highest;
		int lowest;
		string highestscore1;
		string lowestscores1;
		int highest1;
		int lowest1;
		public Highscores()
		{
			InitializeComponent();
			using (StreamReader reader = new StreamReader(@".\SaveGames\savegame.sav"))
			{
				// Step 2: call ReadLine until null.


				highestscore = reader.ReadLine();
				highest = Convert.ToInt32(reader.ReadLine());
                if (highest != 0)
                {
					Highestscoresname.Content = highestscore;
					Highestscore.Content = highest;
				}
                
				lowestscores = reader.ReadLine();
				lowest = Convert.ToInt32(reader.ReadLine());

				if (lowest != 0)
				{
					lowestscoresname1.Content = lowestscores;
					lowestscore1.Content = lowest;
				}

				highestscore1 = reader.ReadLine();
				highest1 = Convert.ToInt32(reader.ReadLine());

				if (highest1 != 0)
				{
					Highestscoresname1.Content = highestscore1;
					hightscore1.Content = highest1;
				}

				lowestscores1 = reader.ReadLine();
				lowest1 = Convert.ToInt32(reader.ReadLine());
				
				if (lowest1 != 0)
				{
					lowestscore2.Content = lowest1;
					lowestscoresname2.Content = lowestscores1;
				}


			}
		}
		public void Back_Home_Screen(object sender, RoutedEventArgs e)
		{
			Homescherm homescherm = new Homescherm();
			this.NavigationService.Navigate(homescherm);
		}
	}
}
