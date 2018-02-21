namespace GenesysGMeratorUI
{
    using GenesysGMerator.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CareerSelector.xaml
    /// </summary>
    public partial class CareerSelector : Window
    {
        private List<GenesysGMerator.CharacterCreation.Career> domainCareer { get; set; }

        public GenesysGMerator.CharacterCreation.Career selectedCareer;

        public List<GenesysGMerator.CharacterCreation.Skill> selectedSkills = new List<GenesysGMerator.CharacterCreation.Skill>();

        public CareerSelector()
        {
            InitializeComponent();

            ObservableCollection<string> careers = new ObservableCollection<string>();
            domainCareer = DomainDataHelper.GetCareers();
            foreach (GenesysGMerator.CharacterCreation.Career a in domainCareer)
            {
                careers.Add(a.Name);
            }

            CareerPicker.ItemsSource = careers;
            CareerPicker.SelectedIndex = 0;
            selectedCareer = domainCareer[0];
        }

        private void CareerPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear existing skill checkboxes
            for (int c = 1; c <= 8; c++)
            {
                for (int i = 0; i < MainGrid.Children.Count; i++)
                    if ((Grid.GetRow(MainGrid.Children[i]) == c)
                        && (Grid.GetColumn(MainGrid.Children[i]) == 0))
                    {
                        MainGrid.Children.Remove(MainGrid.Children[i]);
                        break;
                    }
            }

            foreach (GenesysGMerator.CharacterCreation.Career career in domainCareer)
            {
                if (career.Name == (sender as ComboBox).SelectedItem as string)
                {
                    for (int i = 1; i <= career.Skills.Count; i++)
                    {
                        CheckBox chk = new CheckBox();
                        chk.Name = string.Format("Skill_{0}", i);
                        chk.Content = career.Skills[i-1];

                        MainGrid.Children.Add(chk);
                        Grid.SetColumn(chk, 0);
                        Grid.SetRow(chk, i);
                        Grid.SetColumnSpan(chk, 2);
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            selectedSkills.Clear();

            for (int i = 1; i <= 8; i++)
            {
                for (int ii = 0; ii < MainGrid.Children.Count; ii++)
                {
                    CheckBox cb = MainGrid.Children[ii] as CheckBox;
                    if (cb != null && (string)cb.Name == string.Format("Skill_{0}", i))
                    {
                        if ((bool)cb.IsChecked)
                        {
                            GenesysGMerator.CharacterCreation.Skill skill = new GenesysGMerator.CharacterCreation.Skill();
                            skill.IsCareer = true;
                            skill.Name = (GenesysGMerator.CharacterCreation.SkillType)cb.Content;
                            skill.Rank = 1;
                            selectedSkills.Add(skill);
                        }
                    }
                }
            }

            if (selectedSkills.Count == 4)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You can only select 4 career skills");
            }
                
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (selectedSkills.Count != 4)
            {
                e.Cancel = true;
            }
        }
    }
}
