using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokens
{
    /*
     * Класс, представляющий собою лексему.
     * Поле text - сама лексема. Доступно только для чтения.
     * Поле number - числовое представление лексемы. Доступно только для чтения.
     */
    public class TokenInProgram : TokenBase
    {
        /*Сама лексема.*/
        string name;
        
        /*
         * Номер строки, в которой находится лексема.
         * Начинается с 1.
         */
        int row;
        
        /*
         * Номер столбца, в котором находится первый символ лексемы.
         */
        int column;

        /*Числовое представление лексемы.*/
        int number;
        
        /*
         * Конструктор по-умолчанию.
         * Создает лексему с пустым именем и номером -1.
         */
        public TokenInProgram()
        {
            name = "";
            number = -1;
            row = -1;
            column = -1;
        }
        
        /*Конструктор с параметрами.*/
        public TokenInProgram(TokenBase tokenBase, int newRow, int newColumn)
        {
            name = tokenBase.Name;
            number = tokenBase.Number;
            row = newRow;
            column = newColumn;
        }
        
        /*Конструктор копирования.*/
        public TokenInProgram(TokenInProgram other)
        {
            name = String.Copy(other.name);
            number = other.number;
            row = other.row;
            column = other.column;
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать метод [int GetRow()].
         * Этому равносилен вызов [<экземпляр>.Row]
         */
        public int Row
        {
            get { return row; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать метод [int GetColumn()].
         * Этому равносилен вызов [<экземпляр>.Column]
         */
        public int Column
        {
            get { return column; }
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
