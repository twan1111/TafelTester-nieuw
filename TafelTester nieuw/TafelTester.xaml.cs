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
using System.Media;
using System.Diagnostics;

namespace TafelTester_nieuw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        new UserInput UserName = new UserInput();
        new UserInput OwnAnswer = new UserInput();

        private int test1;
        private int level;
        private double lastAnswer;
        private int questionsLeft = 10;
        private int score = 0;
        private string[] rekenen = { "1", "x", ":", "-", "+" };
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NameScreen.Visibility = Visibility.Hidden;
            LevelChoice.Visibility = Visibility.Visible;
            UserInput.UserName = InputUserName.Text;
            Welcome.Content = $"Welkom {UserInput.UserName}";
        }

        private void generateSum()
        {
            if (questionsLeft == 0)
            {
                Level.Visibility = Visibility.Hidden;
                EndScreen.Visibility = Visibility.Visible;
                Highscore.Content = score;
            }
            else
            {
                Random randomgen = new Random();
                test1 = randomgen.Next(1, 5);
                //test1 = 4;
                int num01 = randomgen.Next(10);
                int num02 = randomgen.Next(10);
                Debug.WriteLine(lastAnswer);
                if (test1 == 1)
                {
                    Question.Content = $"Wat is {num01 * level} x {num02 * level}";
                    lastAnswer = ((num01 * level) * (num02 * level));
                    questionsLeft--;
                }
                if (test1 == 2) {
                    Question.Content = $"Wat is {num01 * level} : {num02 * level}";
                    Debug.WriteLine($"num01={num01}, num02={num02}");
                    lastAnswer = (Math.Floor(((double)num01 * level) / ((double)num02 * level) * 100) / 100);
                    questionsLeft--;
                }
                if (test1 == 3)
                {
                    if (level == 1)
                    {
                        int num03 = randomgen.Next(11, 99);
                        int num04 = randomgen.Next(11, 99);
                        Question.Content = $"Wat is {num03} - {num04}";
                        lastAnswer = (num03 - num04);
                        questionsLeft--;
                    }
                    if (level == 2)
                    {
                        int num03 = randomgen.Next(111, 999);
                        int num04 = randomgen.Next(111, 999);
                        Question.Content = $"Wat is {num03} - {num04}";
                        lastAnswer = (num03 - num04);
                        questionsLeft--;
                    }
                    if (level == 3)
                    {
                        int num03 = randomgen.Next(1111, 9999);
                        int num04 = randomgen.Next(1111, 9999);
                        Question.Content = $"Wat is {num03} - {num04}";
                        lastAnswer = (num03 - num04);
                        questionsLeft--;
                    }
                }
                if (test1 == 4)
                {
                    if (level == 1)
                    {
                        int num03 = randomgen.Next(11, 99);
                        int num04 = randomgen.Next(11, 99);
                        Question.Content = $"Wat is {num03} + {num04}";
                        lastAnswer = (num03 + num04);
                        questionsLeft--;
                    }
                    if (level == 2)
                    {
                        int num03 = randomgen.Next(111, 999);
                        int num04 = randomgen.Next(111, 999);
                        Question.Content = $"Wat is {num03} + {num04}";
                        lastAnswer = (num03 + num04);
                        questionsLeft--;
                    }
                    if (level == 3)
                    {
                        int num03 = randomgen.Next(1111, 9999);
                        int num04 = randomgen.Next(1111, 9999);
                        Question.Content = $"Wat is {num03} + {num04}";
                        lastAnswer = (num03 + num04);
                        questionsLeft--;
                    }
                }
                        
            }


        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (MathAnswer())
                 generateSum();
        }

        public bool MathAnswer()
        {
            try
            {
                double userAnt = double.Parse(Answer.Text);
                if (lastAnswer == userAnt)
                {
                    test.Content = "Goed";
                    test.Foreground = Brushes.Green;
                    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\twanv\Downloads\geluid\goed.wav");
                    soundPlayer.Play();
                    score++;
                }
                else
                {
                    test.Content = "Fout";
                    test.Foreground = Brushes.Red;
                    SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\twanv\Downloads\geluid\fout.wav");
                    soundPlayer.Play();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Je kan geen letters als antwoord invullen!\n");
                return false;
            }
        }


        private void startEasy(object sender, RoutedEventArgs e)
        {
            startLevel(1);
        }

        private void startMedium(object sender, RoutedEventArgs e)
        {
            startLevel(2);
        }

        private void startHard(object sender, RoutedEventArgs e)
        {
            startLevel(3);
        }

        private void startLevel(int level)
        {
            LevelChoice.Visibility = Visibility.Hidden;
            Level.Visibility = Visibility.Visible;
            this.level = level;
            generateSum();

        }

    }
}
