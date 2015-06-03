using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokens
{
    /*
     * Класс, представляющий собою список лексем.
     */
    public class TokenList
    {
        List<TokenInProgram> tokenList;

        /*
         * Конструктор по-умолчанию.
         * Создает пустой список лексем.
         */
        public TokenList()
        {
            tokenList = new List<TokenInProgram>();
        }

        /*Конструтор с копирования.*/
        public TokenList(TokenList other)
        {
            tokenList = new List<TokenInProgram>(other.tokenList);
        }

        /*Конструктор с параметрами.*/
        public TokenList(List<TokenInProgram> newTokenList)
        {
            tokenList = new List<TokenInProgram>(newTokenList);
        }

        /*
         * Возвращает ссылку на лексему, которая стоит на позиции tokenPosition.
         * Если такой лексемы нет (выход за границы списка), возвращает null.
         */
        public TokenInProgram GetTokenByPosition(int tokenPosition)
        {
            if(CheckTokenPosition(tokenPosition)){
                return tokenList[tokenPosition];
            }
            return null;
        }

        /*
         * Проверяет, существует ли лексема, стоящая на позиции tokenPosition.
         * Возвращает true, если такая лексема существует.
         * Иначе возвращает false.
         */
        bool CheckTokenPosition(int tokenPosition)
        {
            if(0 <= tokenPosition && tokenPosition < tokenList.Count){
                return true;
            }
            return false;
        }
    
        /*Добавляет новую лексему в список.*/
        public void AddToken(TokenInProgram token)
        {
            tokenList.Add(token);
        }

        /*
         * Создает новую лексему с известным текстом и добавляет ее в список.
         * Лексеме присваивается номер, следующий за максимальным номером лексемы в списке.
         */
        public void AddToken(TokenBase tokenBase, int tokenRow, int tokenColumn)
        {
            TokenInProgram toAdd = new TokenInProgram(tokenBase, tokenRow, tokenColumn);
            tokenList.Add(toAdd);
        }
    }
}
