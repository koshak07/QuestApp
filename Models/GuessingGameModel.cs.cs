using System.Collections.Generic;

namespace QuestApp.Models
{
    public class GuessingGameModel
    {
        public string SecretWord { get; set; }
        public List<string> PreviousGuesses { get; set; }
        public string UserGuess { get; set; }
        public string Feedback { get; set; }
        public int Attempt { get; set; }
        public bool IsGameOver { get; set; }

        public GuessingGameModel()
        {
            SecretWord = GetRandomWord();
            PreviousGuesses = new List<string>();
            Attempt = 0;
            UserGuess = string.Empty;
            Feedback = string.Empty;
            IsGameOver = false;
        }
        private string GetRandomWord()
        {
            // Генерация загаданных слов
            
            string[] words = { "apple", "banana", "orange", "grape", "pineapple" };
            Random random = new Random();
            int index = random.Next(words.Length);
            return words[index];
        }
    }
}