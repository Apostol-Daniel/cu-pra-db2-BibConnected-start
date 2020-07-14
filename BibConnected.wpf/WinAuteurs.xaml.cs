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

namespace BibConnected.wpf
{
    /// <summary>
    /// Interaction logic for WinAuteurs.xaml
    /// </summary>
    public partial class WinAuteurs : Window
    {
        public WinAuteurs()
        {
            InitializeComponent();
        }

        private void VulDeAuteurs()
        {
            VulDeAuteurs(Enumeraties.SortOrder.ASC);
        }

        private void VulDeAuteurs(Enumeraties.SortOrder volgorde)
        {
            lstAuteurs.Items.Clear();
            DataTable dtAuteurs = Auteur.GeefAlleAuteurs("naam", volgorde);
            ListBoxItem itm;
            for(int r = 0; r < dtAuteurs.Rows.Count; r++)
            {
                itm = new ListBoxItem();
                itm.Content = dtAuteurs.Rows[r]["naam"].ToString();
                itm.Tag = dtAuteurs.Rows[r]["auteur_id"].ToString();
                lstAuteurs.Items.Add(itm);
            }
        }

        private void ViewStandaard()
        {
            grpKnoppen.IsEnabled = true;
            grpBewerken.IsEnabled = false;
            lstAuteurs.IsEnabled = true;
            grpBewerken.Header = "";
        }

        private void ViewBewerking()
        {
            grpKnoppen.IsEnabled = false;
            grpBewerken.IsEnabled = true;
            lstAuteurs.IsEnabled = false;
        }

        bool nieuweAuteur;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeAuteurs();
            ViewStandaard();
        }
        private void lstAuteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstAuteurs.SelectedIndex >= 0) 
            {
                ListBoxItem itm = (ListBoxItem)lstAuteurs.SelectedItem;
                int auteur_id = int.Parse(itm.Tag.ToString());
                txtNaam.Text = Auteur.ZoekNaam(auteur_id);
            }
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
