using Microsoft.AspNetCore.Mvc;
using QuestApp.Models;
using System.Diagnostics;


namespace QuestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GuessingGameModel _gameModel;

        public HomeController()
        {
            _gameModel = new GuessingGameModel();
        }

        public IActionResult Index()
        {
            return View(_gameModel);
        }

        [HttpPost]
        public IActionResult Guess(GuessingGameModel model)
        {
            if (ModelState.IsValid)
            {
                _gameModel.UserGuess = model.UserGuess.ToLower().Trim();

                // Проверяем, угадал ли пользователь загаданное слово
                if (_gameModel.UserGuess == _gameModel.SecretWord)
                {
                    _gameModel.IsGameOver = true;
                    _gameModel.Feedback = "Поздравляем! Вы угадали слово!";
                }
                else
                {
                    // Добавляем введенную версию в список предыдущих версий
                    _gameModel.PreviousGuesses.Add(_gameModel.UserGuess);

                    // Логика подсказок и ответов системы
                    // ...

                    // Пример ответа системы
                    _gameModel.Feedback = "Нет, это не правильное слово. Попробуйте еще раз.";
                }
            }

            return View("Index", _gameModel);
        }
    }
}