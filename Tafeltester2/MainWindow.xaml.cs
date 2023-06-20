using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tafeltester2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _score = 0;
        private string name = "";
        private List<SomModel> _sommen = new List<SomModel>();
        private int _teller = 0;
        private void NameInputButton_Click(object sender, RoutedEventArgs e)
        {
            name = MainTextBox.Text;
            Stap1.Visibility = Visibility.Hidden;
            Stap2.Visibility = Visibility.Visible;
            LabelName.Content = $"Hello, {name}";
            LevelKeuze.Visibility = Visibility.Visible;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MaakSommen()
        {
            SomGenerator somGenerator = new SomGenerator();
            for (int index = 0; index < 10; index++)
            {
                SomModel som = somGenerator.MaakEasyRekensom();
                _sommen.Add(som);
            }
        }
        private void MaakSommenNormal()
        {
            SomGenerator somGenerator = new SomGenerator();
            for (int index = 0; index < 10; index++)
            {
                SomModel som = somGenerator.MaakNormalRekensom();
                _sommen.Add(som);
            }
        }
        private void MaakSommenHard()
        {
            SomGenerator somGenerator = new SomGenerator();
            for (int index = 0; index < 10; index++)
            {
                SomModel som = somGenerator.MaakHardRekensom();
                _sommen.Add(som);
            }
        }
        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            ButtonEasy.Visibility = Visibility.Hidden; //aan
            ButtonMedium.Visibility = Visibility.Hidden;
            ButtonHard.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Visible;
            //System.Diagnostics.Debug.WriteLine(_sommen[_teller].GetSom());
            //System.Diagnostics.Debug.WriteLine(_sommen[_teller].GetAntwoord());
            _sommen.Clear();
            MaakSommen();
            LabelVragen.Content = _sommen[_teller].GetSom();
        }
        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            ButtonEasy.Visibility = Visibility.Hidden;
            ButtonMedium.Visibility = Visibility.Hidden; //aan
            ButtonHard.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Visible;
            _sommen.Clear();
            MaakSommenNormal();
            LabelVragen.Content = _sommen[_teller].GetSom();
        }
        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            ButtonEasy.Visibility = Visibility.Hidden;
            ButtonMedium.Visibility = Visibility.Hidden;
            ButtonHard.Visibility = Visibility.Hidden; //aan
            Test.Visibility = Visibility.Visible;
            _sommen.Clear();
            MaakSommenHard();
            LabelVragen.Content = _sommen[_teller].GetSom();
        }
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            ControleerSom();
            //System.Diagnostics.Debug.WriteLine(_sommen[_teller].GetSom());
            //  System.Diagnostics.Debug.WriteLine(_sommen[_teller].GetAntwoord());
            _teller++;
            if (_teller <= 9)
            {
                LabelVragen.Content = _sommen[_teller].GetSom();
                Antwoord.Text = String.Empty;
            }
            else
            {
                ScorePlayer.Visibility = Visibility.Visible;
                Test.Visibility = Visibility.Hidden;
                ButtonEasy.Visibility = Visibility.Visible; 
                ButtonMedium.Visibility = Visibility.Visible;
                ButtonHard.Visibility = Visibility.Visible;
                ScorePlayer.Content = $"score van {name} is {_score} je hebt {_score} van de 10 vragen goed ";
                _teller = 0;
            }
        }
        private void ControleerSom()
        {
            string antwoord = Antwoord.Text;
            bool isNummer = double.TryParse(antwoord, out double antwoordAlsNummer);
            if (!isNummer)
            {
                JuisteAntwoord.Content = $"Fout, je hep een antwoord in text";
                // fout
                return;
            }
            SomModel huidigeSom = _sommen[_teller];
            if (antwoordAlsNummer == huidigeSom.GetAntwoord())
            {
                JuisteAntwoord.Content ="Goed";
                //plus 1 bij score
                _score++;
                // goed
            }
            else
            {
                JuisteAntwoord.Content = $"Fout, het antwoord is {huidigeSom.GetAntwoord()}";
                // fout
            }
            //JuisteAntwoord.Content = $"{isNummer}: {antwoordAlsNummer} - {huidigeSom.GetAntwoord()}";
        }
    }
}