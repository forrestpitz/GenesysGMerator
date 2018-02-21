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

namespace GenesysGMeratorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GM : Window
    {
        public GM()
        {
            InitializeComponent();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            DiceRoller roller = new DiceRoller();
            roller.Show();
        }
        private void CreateCharacter_Click(object sender, RoutedEventArgs e)
        {
            CharacterCreator charCreator = new CharacterCreator();
            charCreator.Show();
        }

        private void GetFlavor_Click(object sender, RoutedEventArgs e)
        {
            GetFlavor flavor = new GetFlavor();
            flavor.Show();
        }
    }
}
