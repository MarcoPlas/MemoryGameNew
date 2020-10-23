﻿using System;
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
	/// Interaction logic for Endscreen.xaml
	/// </summary>
	public partial class Endscreen : Page
	{
		public Endscreen()
		{
			InitializeComponent();
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
	}
}