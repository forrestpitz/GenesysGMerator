using GenesysGMerator.Helpers;
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

namespace GenesysGMeratorUI
{
    /// <summary>
    /// Interaction logic for GetFlavor.xaml
    /// </summary>
    public partial class GetFlavor : Window
    {
        public GetFlavor()
        {
            InitializeComponent();
        }

        private void DungeonFlavor_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetDungeonFlavor();
        }

        private void Forest_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetForestFlavor();
        }

        private void OffRoadTravel_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetOffRoadTravel();
        }

        private void RoadEncounters_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetRoadEncounter();
        }

        private void RottingCity_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetRottingCityFlavor();
        }

        private void ShittyPlotHooks_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetShittyPlotHook();
        }

        private void ShipFlavor_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetShipFlavor();
        }

        private void RoadTravel_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetRoadTravelEvent();
        }

        private void GoodPlotHooks_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetGoodPlotHook();
        }

        private void UrbanEncounters_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetUrbanEncounter();
        }

        private void VillageFlavor_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetVillageFlavor();
        }

        private void TravelFlavor_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetTravelEncounters();
        }

        private void DumbItem_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetDumbItem();
        }

        private void Insult_Click(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetInsult();
        }

        private void NPC_Name(object sender, RoutedEventArgs e)
        {
            Flavor.Text = DomainDataHelper.GetName();
        }
    }
}
