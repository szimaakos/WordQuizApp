using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordQuizApp.Data;
using WordQuizApp.Models;

namespace WordQuizApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<(string ForeignWord, string Translation)> _words;
        private (string ForeignWord, string Translation) _currentWord;
        private Random _random = new Random();
        private int _score = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Adatbázis inicializálása
            DatabaseHelper.InitializeDatabase();

            // Szavak betöltése az adatbázisból
            _words = DatabaseHelper.GetWords();

            if (_words.Count < 4)
            {
                MessageBox.Show("Az adatbázisban nincs elegendő szó a kvízhez.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
                return;
            }

            LoadNewQuestion();
        }

        private void LoadNewQuestion()
        {
            // Véletlenszerű kérdés kiválasztása
            _currentWord = _words[_random.Next(_words.Count)];
            QuestionTextBlock.Text = $"Mit jelent: {_currentWord.ForeignWord}?";

            // Válaszlehetőségek előállítása
            var options = _words
                .Where(w => w != _currentWord)
                .OrderBy(x => _random.Next())
                .Take(3)
                .Select(w => w.Translation)
                .ToList();

            options.Add(_currentWord.Translation);
            options = options.OrderBy(x => _random.Next()).ToList();

            Option1Button.Content = options[0];
            Option2Button.Content = options[1];
            Option3Button.Content = options[2];
            Option4Button.Content = options[3];
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content.ToString() == _currentWord.Translation)
            {
                _score++;
            }

            ScoreTextBlock.Text = $"Pontszám: {_score}";
            LoadNewQuestion();
        }
    }
}