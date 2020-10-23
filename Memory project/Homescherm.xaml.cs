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
    /// Interaction logic for Homescherm.xaml
    /// </summary>
    public partial class Homescherm : Page
    {
        public Homescherm()
        {
            InitializeComponent();
        }
        public void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            StartGame startgame = new StartGame();
            this.NavigationService.Navigate(startgame);
        }
        public void Highscores_Click(object sender, RoutedEventArgs e)
        {
            Highscores highscores = new Highscores();
            this.NavigationService.Navigate(highscores);
        }
    }
}
