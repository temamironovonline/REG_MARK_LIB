using System;
using System.Text.RegularExpressions;

namespace REG_MARK_LIB
{
    public class Marks
    {
        private char[] _markLetters = new char[] { 'A', 'В', 'E', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х' }; // Массив букв серии
        bool CheckMarks (string mark) // Метод для проверки корректности номера
        {
            Regex _checkMark = new Regex(@"^[АВЕКМНОРСTУХ][0-9][0-9][0-9][АВЕКМНОРСTУХ][АВЕКМНОРСTУХ][0-9][0-9][0-9]$"); // Регулярное выражение для проверки корректности номера
            if (_checkMark.IsMatch (mark))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string GetNextMarkAfter(string mark) // Метод для выдачи следующего номерного знака (либо следующего по номеру, либо следующего по серии)
        {
            int numberMark = Convert.ToInt32(mark.Substring(1, 4)); // Вынос цифр из номерного знака в отдельную переменную
            string seriesMark = "";
            if (numberMark < 999)
            {
                int newNumberMark = numberMark++;
                seriesMark = mark.Replace(Convert.ToString(numberMark), Convert.ToString(newNumberMark)); // Замена цифр в номерном знаке
            }
            else
            {
                int region = Convert.ToInt32(mark.Substring(6, 9)); // Вынос региона в отдельную переменную
                seriesMark = $"{mark[0] + mark[4] + mark[5]}"; // Вынос серии в отдельную переменную

                //for (int i = 0; i < _markLetters.Length; i++)
                //{
                //    if (_markLetters[i] == seriesMark[2])
                //    {
                //        if (i == _markLetters.Length-1)
                //        {
                //            if (seriesMark[1] == seriesMark[2] && seriesMark[0] == seriesMark[2])
                //            {
                //                return "Нет больше номеров";
                //            }
                //            else if (seriesMark[1] == seriesMark[2])
                //            {
                //                seriesMark.Replace(seriesMark[2], _markLetters[0]);
                //                seriesMark.Replace(seriesMark[1], _markLetters[0]);
                //                seriesMark.Replace(seriesMark)
                //            }
                           
                //        }
                //    }
                //}

                int positionFirstLetter = 0, positionSecondLetter = 0, positionLastLetter = 0;
                
                for (int i = 0; i < _markLetters.Length; i++)
                {
                    if (seriesMark[0] == _markLetters[i])
                    {
                        positionFirstLetter = i;
                    }
                    
                    if (seriesMark[1] == _markLetters[i])
                    {
                        positionSecondLetter = i;
                    }

                    if (seriesMark[2] == _markLetters[i])
                    {
                        positionLastLetter = i;
                    }
                }

                if (positionLastLetter == _markLetters)
            }
            return "";
        }

        string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            return "";
        }

        int GetCombinationsCountInRange(string mark1, string mark2)
        {
            return 0;
        }
    }
}
