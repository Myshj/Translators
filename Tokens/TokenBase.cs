using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokens
{
    /*
     * Базовый класс для лексемы.
     * Поле name - сама лексема.
     * Поле number - числовое представление лексемы.
     */
    public class TokenBase
    {
        /*Сама лексема.*/
        string name;

        /*Числовое представление лексемы.*/
        int number;

        /*
         * Конструктор по-умолчанию.
         * Создает лексему с пустым именем и номером -1.
         */
        public TokenBase()
        {
            name = "";
            number = -1;
        }
        
        /*Конструктор с параметрами.*/
        public TokenBase(string newName, int newNumber)
        {
            name = newName;
            number = newNumber;
        }
        
        /*Конструктор копирования.*/
        public TokenBase(TokenBase other)
        {
            name = String.Copy(other.name);
            number = other.number;
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать метод [string GetName()].
         * Этому равносилен вызов [<экземпляр>.Name]
         */
        public string Name
        {
            get { return name; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать метод [string GetNumber()].
         * Этому равносилен вызов [<экземпляр>.Number]
         */
        public int Number
        {
            get { return number; }
        }
    }
}
