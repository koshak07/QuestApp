using Microsoft.AspNetCore.Mvc;
using QuestApp.Models;
using System.Diagnostics;


namespace QuestApp.Controllers
{
    public class HomeController : Controller
    {
        private static GuessingGameModel _gameModel = new GuessingGameModel();
     
        

        public IActionResult Index()
        {
            _gameModel = new GuessingGameModel();
            return View(_gameModel);
        }

        [HttpPost]
        public IActionResult Guess(GuessingGameModel model)
        {
            if (ModelState.IsValid)
            {
                _gameModel.UserGuess = model.UserGuess.ToLower().Trim();

                // Проверяем, угадал ли пользователь загаданное слово
                if (_gameModel.UserGuess == _gameModel.SecretWord.ToLower().Trim())
                {
                    _gameModel.IsGameOver = true;
                    _gameModel.Feedback = "Поздравляем! Вы угадали слово!";
                }
                else
                {
                    // Добавляем введенную версию в список предыдущих версий

                    _gameModel.PreviousGuesses.Add(_gameModel.UserGuess);


                    // Логика подсказок и ответов системы
                    if (_gameModel.UserGuess.Length > _gameModel.SecretWord.Length)
                    {

                        _gameModel.Feedback = "Загаданное слово короче";
                    }
                    else if (_gameModel.UserGuess.Length < _gameModel.SecretWord.Length)
                    {

                        _gameModel.Feedback = "Загаданное слово длинее";
                    }
                    if(_gameModel.PreviousGuesses.Count > 3)
                    {
                    _gameModel.Feedback = "Подсказка: Первая буква " + _gameModel.SecretWord[0];
                    }
                    


                   
                }
            }

            return View("Index", _gameModel);
        }
       
    }
}