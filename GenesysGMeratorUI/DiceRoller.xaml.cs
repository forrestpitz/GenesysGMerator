namespace GenesysGMeratorUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using GenesysGMerator.DiceRoller;

    /// <summary>
    /// Interaction logic for DiceRoller.xaml
    /// </summary>
    public partial class DiceRoller : Window
    {
        private List<Image> boosts = new List<Image>();
        private List<Image>  setback =  new List<Image>();
        private List<Image>  ability =  new List<Image>();
        private List<Image>  difficulty =  new List<Image>();
        private List<Image>  proficiency =  new List<Image>();
        private List<Image>  chalange =  new List<Image>();

        private int poolRow = 2;
        private int poolCol = 0;

        private int resultRow = 6;
        private int resultCol = 0;

        public DiceRoller()
        {
            InitializeComponent();
        }

        private void Boost_Click(object sender, RoutedEventArgs e)
        {
            Image boostDie = new Image();
            boostDie.Source = new BitmapImage(new Uri(@"Symbols/boost.png", UriKind.Relative));
            boosts.Add(boostDie);

            AddDieToPool(boostDie);
        }

        private void Setback_Click(object sender, RoutedEventArgs e)
        {
            Image setbackDie = new Image();
            setbackDie.Source = new BitmapImage(new Uri(@"Symbols/setback.png", UriKind.Relative));
            setback.Add(setbackDie);

            AddDieToPool(setbackDie);
        }

        private void Ability_Click(object sender, RoutedEventArgs e)
        {
            Image abilityDie = new Image();
            abilityDie.Source = new BitmapImage(new Uri(@"Symbols/ability.png", UriKind.Relative));
            ability.Add(abilityDie);

            AddDieToPool(abilityDie);
        }

        private void Difficulty_Click(object sender, RoutedEventArgs e)
        {
            Image difficultyDie = new Image();
            difficultyDie.Source = new BitmapImage(new Uri(@"Symbols/difficulty.png", UriKind.Relative));
            difficulty.Add(difficultyDie);
            
            AddDieToPool(difficultyDie);
        }

        private void Proficiency_Click(object sender, RoutedEventArgs e)
        {
            Image proficiencyDie = new Image();
            proficiencyDie.Source = new BitmapImage(new Uri(@"Symbols/proficiency.png", UriKind.Relative));
            proficiency.Add(proficiencyDie);

            AddDieToPool(proficiencyDie);
        }

        private void Chalange_Click(object sender, RoutedEventArgs e)
        {
            Image chalangeDie = new Image();
            chalangeDie.Source = new BitmapImage(new Uri(@"Symbols/chalange.png", UriKind.Relative));
            chalange.Add(chalangeDie);

            AddDieToPool(chalangeDie);
        }

        private void AddDieToPool(Image die)
        {
            MainGrid.Children.Add(die);
            Grid.SetColumn(die, poolCol);
            Grid.SetRow(die, poolRow);

            poolCol++;

            if (poolCol == 6)
            {
                poolRow += 1;
                poolCol = 0;
            }
        }

        private void AddResultToPool(Image result)
        {
            MainGrid.Children.Add(result);
            Grid.SetColumn(result, resultCol);
            Grid.SetRow(result, resultRow);

            resultCol++;

            if (resultCol == 6)
            {
                resultRow += 1;
                resultCol = 0;
            }
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            // remove last result
            for(int c = 0; c < 6; c++)
            {
                for (int i = 0; i < MainGrid.Children.Count; i++)
                if ((Grid.GetRow(MainGrid.Children[i]) == resultRow)
                    && (Grid.GetColumn(MainGrid.Children[i]) == c))
                {
                        MainGrid.Children.Remove(MainGrid.Children[i]);
                    break;
                }
            }


            resultRow = 5;
            resultCol = 0;

            RollResult result = GenesysDiceRoller.Roll(boosts.Count, setback.Count, ability.Count, difficulty.Count, proficiency.Count, chalange.Count);

            for(int i = 0; i < result.Successes; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\sucess.png", UriKind.Relative));
                AddResultToPool(img);
            }

            for (int i = 0; i < result.Advantages; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\advantage.png", UriKind.Relative));
                AddResultToPool(img);
            }

            for (int i = 0; i < result.Failures; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\failure.png", UriKind.Relative));
                AddResultToPool(img);
            }

            for (int i = 0; i < result.Threats; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\threat.png", UriKind.Relative));
                AddResultToPool(img);
            }

            for (int i = 0; i < result.Triumphs; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\triumph.png", UriKind.Relative));
                AddResultToPool(img);
            }

            for (int i = 0; i < result.Dispairs; i++)
            {
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"Symbols\dispair.png", UriKind.Relative));
                AddResultToPool(img);
            }
        }
    }
}
