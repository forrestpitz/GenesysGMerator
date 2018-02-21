namespace GenesysGMeratorUI
{
    using System;
    using GenesysGMerator.Helpers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ArchetypeSelector.xaml
    /// </summary>
    public partial class Archetype : Window
    {
        private List<GenesysGMerator.CharacterCreation.Archetype> domainArchetype { get; set; }

        public GenesysGMerator.CharacterCreation.Archetype selectedArchetype;
        public Archetype()
        {
            InitializeComponent();
            ObservableCollection<string> archetypes = new ObservableCollection<string>();
            domainArchetype = DomainDataHelper.GetArchitypes();
            foreach(GenesysGMerator.CharacterCreation.Archetype a in domainArchetype)
            {
                archetypes.Add(a.Name);
            }

            ArchetypePicker.ItemsSource = archetypes;
            ArchetypePicker.SelectedIndex = 0;
            selectedArchetype = domainArchetype[0];
        }

        private void ArchetypePicker_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (GenesysGMerator.CharacterCreation.Archetype arch in domainArchetype)
            {
                if (arch.Name == (sender as ComboBox).SelectedItem as string)
                {
                    Brawn.Content = arch.BaseCharacteristics.Brawn;
                    Agility.Content = arch.BaseCharacteristics.Agility;
                    Intelect.Content = arch.BaseCharacteristics.Intelect;
                    Cunning.Content = arch.BaseCharacteristics.Cunning;
                    Willpower.Content = arch.BaseCharacteristics.Willpower;
                    Presence.Content = arch.BaseCharacteristics.Presence;

                    this.selectedArchetype = arch;
                    break;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
