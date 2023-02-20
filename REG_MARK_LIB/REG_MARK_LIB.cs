using System;
using System.Text.RegularExpressions;

namespace REG_MARK_LIB
{
    public class Marks
    {
        private char[] _markLetters = new char[] { 'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X' }; // Массив букв серии
        public bool CheckMarks (string mark) // Метод для проверки корректности номера
        {
            Regex checkMark = new Regex(@"^[ABEKMHOPCTYX][0-9][0-9][0-9][ABEKMHOPCTYX][ABEKMHOPCTYX][0-9][0-9][0-9]$"); // Регулярное выражение для проверки корректности номера
            if (checkMark.IsMatch (mark))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetNextMarkAfter(string mark) // Метод для выдачи следующего номерного знака (либо следующего по номеру, либо следующего по серии)
        {
            int numberMark = Convert.ToInt32(mark.Substring(1, 3)); // Вынос цифр из номерного знака в отдельную переменную
            int region = Convert.ToInt32(mark.Substring(6)); // Вынос региона в отдельную переменную
            string seriesMark = $"{mark[0]}{mark[4]}{mark[5]}"; // Вынос серии в отдельную переменную

            if (numberMark < 999)
            {
                int newNumberMark = numberMark + 1;
                mark = $"{seriesMark[0]}{newNumberMark}{seriesMark[1]}{seriesMark[2]}{region}";
            }
            else
            {
                int positionFirstLetter = 0, positionSecondLetter = 0, positionLastLetter = 0; // Позиции каждой буквы номерного знака в массиве разрешенных символов для серии
                
                for (int i = 0; i < _markLetters.Length; i++) // Присваивание номера позиции
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

                if (positionLastLetter == _markLetters.Length - 1) // Если последняя буква в номерном знаке имеет последний индекс в массиве символов
                {
                    if (positionSecondLetter == positionLastLetter) 
                    {
                        if (positionFirstLetter == positionLastLetter)
                        {
                            return "Нет больше номеров";
                        }
                        else
                        {
                            seriesMark = $"{_markLetters[positionFirstLetter + 1]}{_markLetters[0]}{_markLetters[0]}";
                        }
                    }
                    else
                    {
                        seriesMark = $"{_markLetters[positionFirstLetter]}{_markLetters[positionSecondLetter + 1]}{_markLetters[0]}";
                    }
                }
                else
                {
                    seriesMark = $"{_markLetters[positionFirstLetter]}{_markLetters[positionSecondLetter]}{_markLetters[positionLastLetter + 1]}";
                }
                
                mark = $"{seriesMark[0]}000{seriesMark[1]}{seriesMark[2]}{region}";
            }
            
            return mark;
        }

        public string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            /////////////////////////////////////
            return "";
        }

        public int GetCombinationsCountInRange(string mark1, string mark2)
        {

            string seriesMarkOne = $"{mark1[0]}{mark1[4]}{mark1[5]}";
            int numberMarkOne = Convert.ToInt32(mark1.Substring(1, 3));
            int regionMarkOne = Convert.ToInt32(mark1.Substring(6));

            string seriesMarkTwo = $"{mark2[0]}{mark2[4]}{mark2[5]}";
            int numberMarkTwo = Convert.ToInt32(mark2.Substring(1, 3));
            int regionMarkTwo = Convert.ToInt32(mark2.Substring(6));

            if (regionMarkOne != regionMarkTwo)
            {
                return 0;
            }

            int countCombitnations;

            if (seriesMarkOne == seriesMarkTwo)
            {
                countCombitnations = 1;
            }
            else
            {
                countCombitnations = 0;
            }

            string currentSeriesMark = seriesMarkOne;
            long currentNumberMark = numberMarkOne;

            int positionFirstLetter = 0, positionSecondLetter = 0, positionLastLetter = 0;

            for (int i = 0; i < _markLetters.Length; i++) // Присваивание номера позиции
            {
                if (currentSeriesMark[0] == _markLetters[i])
                {
                    positionFirstLetter = i;
                }

                if (currentSeriesMark[1] == _markLetters[i])
                {
                    positionSecondLetter = i;
                }

                if (currentSeriesMark[2] == _markLetters[i])
                {
                    positionLastLetter = i;
                }
            }

            string currentMark = "";

            while (true)
            {
                if (currentSeriesMark != seriesMarkTwo)
                {
                    for (long i = currentNumberMark; i <= 999; i++)
                    {
                        currentNumberMark++;
                        countCombitnations++;
                    }

                    currentNumberMark = 1;
                    
                    if (positionLastLetter == _markLetters.Length - 1) // Если последняя буква в номерном знаке имеет последний индекс в массиве символов
                    {
                        if (positionSecondLetter == positionLastLetter)
                        {
                            currentSeriesMark = $"{_markLetters[positionFirstLetter + 1]}{_markLetters[0]}{_markLetters[0]}";
                            positionFirstLetter++;
                            positionSecondLetter = 0;
                        }
                        else
                        {
                            currentSeriesMark = $"{_markLetters[positionFirstLetter]}{_markLetters[positionSecondLetter + 1]}{_markLetters[0]}";
                            positionSecondLetter++;
                            positionLastLetter = 0;
                        }
                    }
                    else
                    {
                        currentSeriesMark = $"{_markLetters[positionFirstLetter]}{_markLetters[positionSecondLetter]}{_markLetters[positionLastLetter + 1]}";
                        positionLastLetter++;
                    }
                    countCombitnations++;
                }
                else
                {
                    for (long i = currentNumberMark; i < numberMarkTwo; i++)
                    {
                        currentNumberMark++;
                        countCombitnations++;
                    }
                }

                string currentNumberMarkStroke = "";

                long numberMark = currentNumberMark;

                int counter = 0;
                while (numberMark != 0)
                {
                    numberMark /= 10;
                    counter++;
                }

                switch (counter)
                {
                    case 1:
                        currentNumberMarkStroke = $"00{currentNumberMark}";
                        break;
                    case 2:
                        currentNumberMarkStroke = $"0{currentNumberMark}";
                        break;
                    case 3:
                        currentNumberMarkStroke = $"{currentNumberMark}";
                        break;
                }

                currentMark = $"{currentSeriesMark[0]}{currentNumberMarkStroke}{currentSeriesMark[1]}{currentSeriesMark[2]}{regionMarkOne}";

                if (currentMark == mark2)
                {
                    break;
                }
            }

            return countCombitnations;
        }
    }
}
