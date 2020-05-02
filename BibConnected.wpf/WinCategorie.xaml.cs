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
using System.Windows.Shapes;
using BibConnected.Lib;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BibConnected.wpf
{
    /// <summary>
    /// Interaction logic for WinCategorie.xaml
    /// </summary>
    public partial class WinCategorie : Window
    {
        public WinCategorie()
        {
            InitializeComponent();
        }

        bool nieuweCategorie;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void lstCategorieen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnWijzig_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnBewaren_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
        }



    }
}
