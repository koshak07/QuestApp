using System.Collections.Generic;

namespace QuestApp.Models
{
    public class GuessingGameModel
    {
        public string SecretWord { get; set; }
        public List<string> PreviousGuesses { get; set; }
        public string UserGuess { get; set; }
        public string Feedback { get; set; }
        public bool IsGameOver { get; set; }

        public GuessingGameModel()
        {
            SecretWord = "banana"; // Загаданное слово (можно заменить на свое)
            PreviousGuesses = new List<string>();
            UserGuess = string.Empty;
            Feedback = string.Empty;
            IsGameOver = false;
        }
    }
}