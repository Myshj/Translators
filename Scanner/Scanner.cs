using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;

namespace Scanner
{
    /*
     * Класс, представляющий собою лексический анализатор.
     * 
     * Содержит таблицы:
     * 1. Ключевых слов
     * 2. Идентификаторов
     * 3. Констант
     * 
     * Содержит списки:
     * 1. Лексем
     * 2. Ошибок
     * 3. Разрешенных/запрещенных символов
     */
    public class Scanner
    {
        /*Таблицы.*/
        
        //Ключевых слов.
        TokenTable tabKeyWords;
        
        //Идентификаторов.
        TokenTable tabIdentifiers;
        
        //Констант.
        TokenTable tabConstants;

        //Разрешенных/запрещенных символов.
        TokenTable tabSymbols;
        
        /*Списки.*/
        
        //Ошибок.
        TokenList listErrors;
        
        //Лексем.
        TokenList listTokens;
        
        

        int row = 1;
        int column = 1;

        /*Конструктор по-умолчанию.*/
        public Scanner()
        {
            tabKeyWords = new TokenTable();
            tabIdentifiers = new TokenTable();
            tabConstants = new TokenTable();
            tabSymbols = new TokenTable();
            
            listErrors = new TokenList();
            listTokens = new TokenList();
            
        }

        /*Конструктор с параметрами.*/
        public Scanner(TokenTable newTabKeyWords,
                       TokenTable newTabIdentifiers,
                       TokenTable newTabConstants,
                       TokenTable newTabSymbols)
        {
            tabKeyWords = newTabKeyWords;
            tabIdentifiers = newTabIdentifiers;
            tabConstants = newTabConstants;
            tabSymbols = newTabSymbols;

            listErrors = new TokenList();
            listTokens = new TokenList();

        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenTable GetTabKeyWords()] и [void SetTabKeyWords(TokenTable value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.TabKeyWords] и [<экземпляр>.TabKeyWords(TokenTable value)].
         */
        public TokenTable TabKeyWords
        {
            get { return tabKeyWords; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenTable GetTabIdentifiers()] и [void SetTabIdentifiers(TokenTable value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.TabIdentifiers] и [<экземпляр>.TabIdentifiers(TokenTable value)].
         */
        public TokenTable TabIdentifiers
        {
            get { return tabIdentifiers; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenTable GetTabConstants()] и [void SetTabConstants(TokenTable value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.TabConstants] и [<экземпляр>.TabConstants(TokenTable value)].
         */
        public TokenTable TabConstants
        {
            get { return tabConstants; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenList GetListErrors()] и [void SetListErrors(TokenList value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.ListErrors] и [<экземпляр>.ListErrors(TokenList value)].
         */
        public TokenList ListErrors
        {
            get { return listErrors; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenList GetListTokens()] и [void SetListTokens(TokenList value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.ListTokens] и [<экземпляр>.ListTokens(TokenList value)].
         */
        public TokenList ListTokens
        {
            get { return listTokens; }
        }

        /*
         * Поле объявлено как свойство.
         * Текст ниже позволяет не писать методы [TokenTable GetTabSymbols()] и [void SetListSymbols(TokenList value)].
         * Этому равносильны вызовы соответственно [<экземпляр>.ListSymbols] и [<экземпляр>.ListSymbols(TokenList value)].
         */
        public TokenTable TabSymbols
        {
            get { return tabSymbols; }
        }

        /*
         * Выполняет лексический анализ текста программы.
         * Сохраняет результаты в таблицы лексем и ошибок.
         */
        public void Scan(string programText)
        {
            /*Основной цикл анализа.*/
            int i = 0;
            //for (int i = 0; i < programText.Length; i++ )
            while (i < programText.Length)
            {
                //Текущий символ текста программы.
                char currentSymbol = programText[i];
                //Аттрибут текущего символа.
                int currentSymbolAttribute = tabSymbols.GetTokenByName("" + currentSymbol).Number;
                //Проверка аттрибута текущего символа.
                switch (currentSymbolAttribute)
                {
                    //Проверка на пробельный символ.
                    case 0:
                        i = CheckWhitespace(programText, i);
                        break;
                    //Проверка на константу.
                    case 1:
                        i = CheckConstant(programText, i);
                        break;
                    //Проверка на идентификатор.
                    case 2:
                        i = CheckIdentifier(programText, i);
                        break;
                    //Проверка на односимвольную лексему.
                    case 3:
                        // Проверка на комментарий.
                        int tempPosition = CheckComment(programText, i);
                        
                        // Если комментарий не найден.
                        if (tempPosition == i)
                        {
                            i = CheckOneSymbolToken(programText, i);
                        }
                        else
                        {
                            i = tempPosition;
                        }
                        break;
                    case -1:
                        i = CheckForbiddenSymbol(programText, i);
                        break;
                }
            }
        }

        /*Проверка текущего символа в строке на соответствие пробельному символу.*/
        int CheckWhitespace(string text, int position)
        {
            /*Проверка на конец строки.*/
            if ('\n' == text[position])
            {
                row++;
                column = 1;
            }
            column++;
            return position + 1;
        }

        /*Выделение константы, первый символ которой стоит на заданной позиции.*/
        int CheckConstant(string text, int position)
        {
            /*Позиция первого символа лексемы в строке.*/
            int startColumn = column;

            int currentSymbolAttribute;
            string newConstant = "";
            do
            {
                newConstant += text[position];
                position++;
                column++;
                if(position >= text.Length){
                    break;
                }
                currentSymbolAttribute = tabSymbols.GetTokenByName("" + text[position]).Number;
            } while (currentSymbolAttribute == 1);

            if (-1 == tabConstants.GetTokenByName(newConstant).Number)
            {
                tabConstants.AddToken(newConstant);
            }
            listTokens.AddToken(tabConstants.GetTokenByName(newConstant), row, startColumn);

            return position;
        }

        /*Выделение идентификатора, первый символ которого стоит на заданной позиции.*/
        int CheckIdentifier(string text, int position)
        {
            /*Позиция первого символа лексемы в строке.*/
            int startColumn = column;

            int currentSymbolAttribute;
            string newIdentifier = "";
            do
            {
                newIdentifier += text[position];
                position++;
                column++;
                if (position >= text.Length)
                {
                    break;
                }
                currentSymbolAttribute = tabSymbols.GetTokenByName("" + text[position]).Number;
            } while (currentSymbolAttribute == 1 || currentSymbolAttribute == 2);

            if (-1 == tabKeyWords.GetTokenByName(newIdentifier).Number)
            {
                if (-1 == tabIdentifiers.GetTokenByName(newIdentifier).Number)
                {
                    tabIdentifiers.AddToken(newIdentifier);
                }
                listTokens.AddToken(tabIdentifiers.GetTokenByName(newIdentifier), row, startColumn);
            }
            else
            {
                listTokens.AddToken(tabKeyWords.GetTokenByName(newIdentifier), row, startColumn);
            }

            return position;
        }

        /*Выделение комментария, первый символ которого стоит на указанной позиции.*/
        int CheckComment(string text, int position)
        {
            /*Проверка на начало комментария.*/
            if (position < text.Length - 1)
            {
                if (text[position] == '(' && text[position + 1] == '*')
                {
                    column += 2;
                    position = position + 2;
                }
                else
                {
                    return position;
                }
            }
            else
            {
                return position;
            }


            do
            {
               

                /*Проверка на конец комментария или текста программы.*/
                if (position < text.Length - 1)
                {
                    /*Выход, если конец комментария найден.*/
                    if (text[position] == '*' && text[position + 1] == ')')
                    {
                        column += 2;
                        position = position + 2;
                        return position;
                    }
                    else
                    {
                        position = CheckWhitespace(text, position);
                    }
                }
                else
                {
                    position = CheckWhitespace(text, position);
                }

                if (position >= text.Length)
                {
                    listErrors.AddToken(new TokenBase("Unexpected end of file.", -2), row, column);
                    break;
                }
            } while (true);
            return position;
        }

        int CheckOneSymbolToken(string text, int position)
        {
            string newToken = "";
            newToken += text[position];
            listTokens.AddToken(tabSymbols.GetTokenByName(newToken), row, column);
            position++;
            column++;
            
            return position;
        }

        int CheckForbiddenSymbol(string text, int position)
        {
            string newToken = "";
            newToken += text[position];
            listErrors.AddToken(new TokenBase(newToken, -1), row, column - 1);
            position++;
            column++;
            
            return position;
        }
    }
}
