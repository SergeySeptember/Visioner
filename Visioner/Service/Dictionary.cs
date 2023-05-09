using System.Collections.Generic;

namespace Visioner.Dictionary
{
    public static class TranslateRusEng
    {
        public static string TranslateRus(string line)
        {
            return Russian[line];
        }
        public static string TranslateEng(string line)
        {
            return English[line];
        }

        public static Dictionary<string, string> Russian = new Dictionary<string, string>
        {
            ["Predict"] = "Предсказать",
            ["Initial Text"] = "Нажми на кнопку и я предскажу твоё будущее",
            ["Language"] = "Язык",
            ["Help"] = "Спарвка",
            ["Main Tab"] = "Основная вкладка",
            ["Edit"] = "Редактирование",
            ["Add"] = "Добавить",
            ["Delete"] = "Удалить",
            ["Help Message"] = "Тыкай на кнопку и программа предскажет тебе будущее. Нажав на вкладку редактировать, можешь внести изменения в предсказания.",
            ["Predict."] = "Гадаю...",
            ["Empty predicts"] = "Предсказания кончились, их нужно добавить"
        };

        public static Dictionary<string, string> English = new Dictionary<string, string>
        {
            ["Predict"] = "Predict",
            ["Initial Text"] = "Click on the button and i'll predict your future",
            ["Language"] = "Language",
            ["Help"] = "Help",
            ["Main Tab"] = "Main tab",
            ["Edit"] = "Edit",
            ["Add"] = "Add",
            ["Delete"] = "Delete",
            ["Help Message"] = "Click on the button and the program will predict your future. By clicking on the edit tab, you can make changes to the predictions.",
            ["Predict."] = "Predict...",
            ["Empty predicts"] = "Predictions are over, you need to add at least one"
        };
    }
}
