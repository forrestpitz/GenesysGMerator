namespace GenesysGMeratorUI
{
    using GenesysGMerator.CharacterCreation;
    using GenesysGMerator.Helpers;
    using Microsoft.Win32;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    /// <summary>
    /// Interaction logic for CharacterCreator.xaml
    /// </summary>
    public partial class CharacterCreator : Window
    {
        public Character character = new Character();
        public string saveFileName = string.Empty;
        public CharacterCreator()
        {
            InitializeComponent();

            var skills = Enum.GetValues(typeof(SkillType));

            foreach (SkillType skill in skills)
            {
                Skill s = new Skill();
                s.IsCareer = false;
                s.Name = skill;
                s.Rank = 0;
                this.character.Skills.Add(s);
            }

            // Default. Changes with archetype selection
            this.character.XPBalance = 100;
            this.character.PlayerName = string.Empty;
            this.character.Name = string.Empty;

            PopulateSkills();
        }

        public void PopulateSkills()
        {
            // Clear the skills
            for (int c = 0; c < 6; c++)
            {
                for (int r = 9; r < 17; r++)
                {
                    for (int i = 0; i < MainGrid.Children.Count; i++)
                    {
                        if ((Grid.GetRow(MainGrid.Children[i]) == r)
                            && (Grid.GetColumn(MainGrid.Children[i]) == c))
                        {
                            MainGrid.Children.Remove(MainGrid.Children[i]);
                            break;
                        }
                    }
                }
            }

            int row = Constants.CharacterCreation.SkillsStartingRow;
            int col = 0;
            foreach (Skill skill in character.Skills)
            {
                Label lable = new Label();
                lable.Content = skill.Name;
                lable.HorizontalAlignment = HorizontalAlignment.Left;

                Image img = new Image();
                img.Source = new BitmapImage(new Uri(string.Format(@"Symbols/skill_{0}.png", skill.Rank), UriKind.Relative));
                img.HorizontalAlignment = HorizontalAlignment.Right;
                img.Width = 100;

                Button btn = new Button();
                btn.IsAncestorOf(img);
                btn.Name = string.Format("{0}_btn", skill.Name);
                btn.Style = (Style)FindResource("NoChromeButton");
                btn.Click += Skill_Up;
                btn.MouseRightButtonUp += Skill_Down;

                MainGrid.Children.Add(lable);
                Grid.SetColumn(lable, col);
                Grid.SetRow(lable, row);

                MainGrid.Children.Add(img);
                Grid.SetColumn(img, col);
                Grid.SetRow(img, row);

                MainGrid.Children.Add(btn);
                Grid.SetColumn(btn, col);
                Grid.SetRow(btn, row);

                col++;
                if (col % 5 == 0)
                {
                    col = 0;
                    row++;
                }
            }

            XPBalance.Content = character.XPBalance;
            XPTotal.Content = character.XPToatal;
        }

        private void ArchetypeSelector_Click(object sender, RoutedEventArgs e)
        {
            Archetype archetype = new Archetype();
            archetype.ShowDialog();
            GenesysGMerator.CharacterCreation.Archetype arch = archetype.selectedArchetype;

            // Hard clone to avoid issues comparting them later
            character.Characteristics = JsonConvert.DeserializeObject<Characteristics>(JsonConvert.SerializeObject(arch.BaseCharacteristics));
            character.XPToatal = arch.StartingXP;
            character.XPBalance = arch.StartingXP;
            character.Arechetype = arch;
            character.StrainThreshold = arch.InitialStrain;
            character.WoundThreshold = arch.InitialWounds;
            character.WoundsCurrent = arch.InitialStrain;
            character.StrainCurrent = arch.InitialStrain;

            UpdateCharacteristics();
            Archetype.Content = arch.Name;
            

            Career_Btn.IsEnabled = true;
            Brawn_Button.IsEnabled = true;
            Agility_Button.IsEnabled = true;
            Intelect_Button.IsEnabled = true;
            Cunning_Button.IsEnabled = true;
            Willpower_Button.IsEnabled = true;
            Presence_Button.IsEnabled = true;
        }

        private void UpdateCharacteristics()
        {
            Brawn.Content = character.Characteristics.Brawn;
            Agility.Content = character.Characteristics.Agility;
            Intelect.Content = character.Characteristics.Intelect;
            Cunning.Content = character.Characteristics.Cunning;
            Willpower.Content = character.Characteristics.Willpower;
            Presence.Content = character.Characteristics.Presence;
            XPBalance.Content = character.XPBalance;
            XPTotal.Content = character.XPToatal;
            Wound_Current.Content = character.WoundsCurrent;
            Wound_Threshold.Content = character.WoundThreshold;
            Strain_Current.Content = character.StrainCurrent;
            Strain_Threshold.Content = character.StrainCurrent;
            Soak.Content = character.Characteristics.Brawn;
        }

        private void CareerSelector_Click(object sender, RoutedEventArgs e)
        {
            foreach(Skill s in character.Skills)
            {
                s.Rank = 0;
            }

            CareerSelector careerSelector = new CareerSelector();
            careerSelector.ShowDialog();
            Career career = careerSelector.selectedCareer;
            
            Career.Content = career.Name;

            int pos = 0;

            foreach(Skill s in character.Skills)
            {
                if (careerSelector.selectedSkills.Find(sk => sk.Name == s.Name) != null)
                {
                    character.Skills[pos].Rank = careerSelector.selectedSkills.Find(sk => sk.Name == s.Name).Rank;
                    character.Skills[pos].IsCareer = true;
                }

                pos++;
            }

            character.Career = career;

            PopulateSkills();
        }

        private void Characteristic_Up(object sender, RoutedEventArgs e)
        {
            string characteristic = ((Button)sender).Name.Split('_')[0];
            int charStat = (int)character.Characteristics.GetType().GetProperty(characteristic).GetValue(character.Characteristics);
            int archetypeStat = (int)character.Arechetype.BaseCharacteristics.GetType().GetProperty(characteristic).GetValue(character.Arechetype.BaseCharacteristics);
            if (charStat == 5)
            {
                MessageBox.Show("You can only have a max of 5 points in any one characteristic");
                return;
            }

            int purchasedPoints = charStat - archetypeStat;
            //30, 40, 50, 60 xp for each point above base
            int costOfNextPoint = 30 + (10 * purchasedPoints);

            if (character.XPBalance < costOfNextPoint)
            {
                MessageBox.Show("Insufficient XP to purchase the point");
                return;
            }

            character.XPBalance -= costOfNextPoint;
            character.Characteristics.GetType().GetProperty(characteristic).SetValue(character.Characteristics, charStat + 1);

            if (characteristic == "Brawn")
            {
                character.WoundThreshold++;
                character.WoundsCurrent++;
            }

            if (characteristic == "Willpower")
            {
                character.StrainCurrent++;
                character.StrainThreshold++;
            }

            UpdateCharacteristics();
        }

        private void Characteristic_Down(object sender, RoutedEventArgs e)
        {
            string characteristic = ((Button)sender).Name.Split('_')[0];
            int charStat = (int)character.Characteristics.GetType().GetProperty(characteristic).GetValue(character.Characteristics);
            int archetypeStat = (int)character.Arechetype.BaseCharacteristics.GetType().GetProperty(characteristic).GetValue(character.Arechetype.BaseCharacteristics);

            if (charStat == archetypeStat)
            {
                MessageBox.Show("You can't reduce a characteristic bellow it's archetype stat");
                return;
            }

            int purchasedPoints = charStat - archetypeStat;
            //30, 40, 50, 60 xp for each point above base
            int costOfNextPoint = 30 + (10 * purchasedPoints);

            character.XPBalance += costOfNextPoint;
            character.Characteristics.GetType().GetProperty(characteristic).SetValue(character.Characteristics, charStat - 1); ;

            if (characteristic == "Brawn")
            {
                character.WoundThreshold--;
                character.WoundsCurrent--;
            }
            if (characteristic == "Willpower")
            {
                character.StrainCurrent--;
                character.StrainThreshold--;
            }

            UpdateCharacteristics();
        }

        private void Skill_Up(object sender, RoutedEventArgs e)
        {
            // 10, 15, 20, 25, 30
            string skill = ((Button)sender).Name.Split('_')[0];
            foreach (Skill sk in character.Skills)
            {
                if (sk.Name == (SkillType)Enum.Parse(typeof(SkillType), skill))
                {
                    int xpCost = 5 + (5 * sk.Rank);
                    
                    if (character.XPBalance < xpCost)
                    {
                        MessageBox.Show("Insufficient XP to upgrade this skill");
                        return;
                    }

                    if (sk.Rank == 5)
                    {
                        MessageBox.Show(string.Format("{0} is maxed out", skill));
                        return;
                    }

                    character.XPBalance -= xpCost;
                    sk.Rank++;
                    break;
                }
            }

            PopulateSkills();
        }

        private void Skill_Down(object sender, RoutedEventArgs e)
        {
            string skill = ((Button)sender).Name.Split('_')[0];
            foreach (Skill sk in character.Skills)
            {
                if (sk.Name == (SkillType)Enum.Parse(typeof(SkillType), skill))
                {
                    if (sk.Rank == 0)
                    {
                        MessageBox.Show("You can't reduce a skill bellow 0 ranks");
                        return;
                    }

                    // refund xp for the point
                    int xpCost = 5 + (5 * sk.Rank);

                    character.XPBalance += xpCost;
                    sk.Rank--;
                    break;
                }
            }

            PopulateSkills();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsReadyToSave())
            {
                SaveCharacter();
            }
            else
            {
                MessageBox.Show("You haven't completed creating your character. Finish filling out the basics to save your progress.");
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsReadyToSave())
            {
                if (MessageBox.Show("Save?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SaveCharacter();
                }
            }
            else
            {
                if (MessageBox.Show("Quit with Unsaved Changes?", "Your character isn't to a point where you can save yet. Quit and discard any work?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SaveCharacter()
        {
            string serializedCharacter = JsonConvert.SerializeObject(character);
            if (this.saveFileName != string.Empty)
            {
                File.WriteAllText(this.saveFileName, serializedCharacter);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "gen";
            if (character.Name != string.Empty)
            {
                saveFileDialog.FileName = character.Name.Trim().Replace(" ", "_");
            }
            
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, serializedCharacter);
                this.saveFileName = saveFileDialog.FileName;
            }
        }

        private void CharacterName_TextChanged(object sender, TextChangedEventArgs e)
        {
            character.Name = ((TextBox)sender).Text;
        }

        private void PlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            character.PlayerName = ((TextBox)sender).Text;
        }

        private bool IsReadyToSave()
        {
            if (character.Name == null || character.Skills.Count == 0
                || character.WoundThreshold == 0 || character.StrainThreshold == 0
                || character.XPToatal == 0 || character.Arechetype == null
                || character.Career == null || character.Characteristics == null)
            {
                return false;
            }

            return true;
        }

        private void GenerateName_Click(object sender, RoutedEventArgs e)
        {
            CharacterNameTB.Text = DomainDataHelper.GetName();
        }
    }
}
