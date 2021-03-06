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

        private void ViewStandaard()
        {
            grpKnoppen.IsEnabled = true;
            grpBewerken.IsEnabled = false;
            lstCategorieen.IsEnabled = true;
            grpBewerken.Header = "";
        }

        private void ViewBewerking ()
        {
            grpBewerken.IsEnabled = false;
            grpBewerken.IsEnabled = true;
            lstCategorieen.IsEnabled = false;
        }

        private void VulDeCategoirieen()
        {
            lstCategorieen.Items.Clear();
            ListBoxItem itm;
            string sql = "select categorie, cat_id from categorie order by 1";
            string constring = ConfigurationManager.ConnectionStrings["bibliotheek"].ToString();
            SqlConnection mijnVerbinding = new SqlConnection(constring);
            mijnVerbinding.Open();
            SqlCommand mijnOpdracht = new SqlCommand(sql, mijnVerbinding);
            SqlDataReader rdr = mijnOpdracht.ExecuteReader();
            while (rdr.Read())
            {
                itm = new ListBoxItem();
                itm.Content = rdr.GetString(0);
                itm.Tag = rdr.GetInt32(1);
                lstCategorieen.Items.Add(itm);
            }
            mijnVerbinding.Close();
        }

        bool nieuweCategorie;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeCategoirieen();
            ViewStandaard();
        }
        private void lstCategorieen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if(lstCategorieen.SelectedIndex >= 0)
            {
                ListBoxItem itm = (ListBoxItem)lstCategorieen.SelectedItem;
                int cat_id = int.Parse(itm.Tag.ToString());
                txtcategorie.Text = Categorie.ZoekCategorie(cat_id);
            }
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            grpBewerken.Header = "Een nieuwe categorie";
            nieuweCategorie = true;
            ViewBewerking();
            txtcategorie.Text="";
            txtcategorie.Focus();
        }
        private void btnWijzig_Click(object sender, RoutedEventArgs e)
        {
            if(lstCategorieen.SelectedIndex >= 0)
            {
                grpBewerken.Header = "Een categorie wijzigen";
                nieuweCategorie = false;
                ViewBewerking();
                txtcategorie.Focus();
            }
        }
        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            lstCategorieen_SelectionChanged(lstCategorieen, null);
            ViewStandaard();
        }
        private void btnBewaren_Click(object sender, RoutedEventArgs e)
        {
            if (nieuweCategorie)
            {
                if (Categorie.VoegCategorieToe(txtcategorie.Text))
                {
                    VulDeCategoirieen();
                }
                else
                {
                    MessageBox.Show("Er heeft zich een fout voorgedaan", "Categorie niet toegevoegd");
                }
            }
            else
            {
                ListBoxItem itm = (ListBoxItem)lstCategorieen.SelectedItem;
                int cat_id = int.Parse(itm.Tag.ToString());
                if(Categorie.WijzigCategorie(cat_id, txtcategorie.Text))
                {
                    VulDeCategoirieen();
                }
                else
                {
                    MessageBox.Show("Er heeft zich een fout voorgedaan", "Categorie niet gewijzigd");
                }
            }
            ViewStandaard();
            
        }
        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if(lstCategorieen.SelectedIndex >= 0)
            {
                if
                (MessageBox.Show("Zeker?","Categorie wissen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) 
                {
                    ListBoxItem itm = (ListBoxItem)lstCategorieen.SelectedItem;
                    int cat_id = int.Parse(itm.Tag.ToString());
                    if (Categorie.VerwijderCategorie(cat_id))
                    {
                        VulDeCategoirieen();
                    }
                    else
                    {
                        MessageBox.Show("Er heeft zich een fout voorgedaan", "Categorie werd niet verwijdered");
                    }
                }
            }
        }



    }
}
