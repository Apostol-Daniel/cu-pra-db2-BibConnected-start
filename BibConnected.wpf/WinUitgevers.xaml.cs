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

namespace BibConnected.wpf
{
    /// <summary>
    /// Interaction logic for WinUitgevers.xaml
    /// </summary>
    public partial class WinUitgevers : Window
    {
        public WinUitgevers()
        {
            InitializeComponent();
        }
        bool nieuweUitgever;

        private void ViewStandaard()
        {
            grpKnoppen.IsEnabled = true;
            grpBewerken.IsEnabled = false;
            lstUitgevers.IsEnabled = true;
            grpBewerken.Header = "";
        }

        private void ViewBewerking()
        {
            grpKnoppen.IsEnabled = true;
            grpBewerken.IsEnabled = false;
            lstUitgevers.IsEnabled = true;
            grpBewerken.Header = "";
        }

         private void VulDeUitgevers()
        {
            lstUitgevers.Items.Clear();
            DataTable dtUitgevers = Uitgever.GeefAlleUitgevers();
            ListBoxItem itm;
            for (int r =0; r < dtUitgevers.Rows.Count;r++)
            {
                itm = new ListBoxItem();
                itm.Content = dtUitgevers.Rows[r]["uitgever"].ToString();
                itm.Tag = dtUitgevers.Rows[r]["uitg_id"].ToString();
                lstUitgevers.Items.Add(itm);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeUitgevers();
            ViewStandaard();
        }
        private void lstUitgevers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstUitgevers.SelectedIndex >= 0)
            {
                ListBoxItem itm = (ListBoxItem)lstUitgevers.SelectedItem;
                int uitg_id = int.Parse(itm.Tag.ToString());
                txtUitgever.Text = Uitgever.ZoekUitgever(uitg_id);
            }
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            grpBewerken.Header = "Een nieuwe uitgever";
            nieuweUitgever = true;
            ViewBewerking();
            txtUitgever.Text = "";
            txtUitgever.Focus();
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
