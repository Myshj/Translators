using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokens
{
    /*
     * Класс, представляющий собою таблицу лексем.
     * Унаследован от класса TokenList.
     */
    public class TokenTable
    {
        int startNumber;
        List<TokenBase> tokenList;

        /*Конструктор по-умолчанию.*/
        public TokenTable()
        {
            tokenList = new List<TokenBase>();
            startNumber = -1;
        }

        /*Конструктор копирования.*/
        public TokenTable(TokenTable other)
        {
            tokenList = new List<TokenBase>(other.tokenList);
            startNumber = other.startNumber;
        }

        /*Конструктор с параметрами.*/
        public TokenTable(List<TokenBase> newTokenList, int newStartNumber)
        {
            tokenList = new List<TokenBase>(newTokenList);
            startNumber = newStartNumber;
        }

        /*
         * Добавляет в таблицу запись про новую лексему.
         */
        public void AddToken(TokenBase token)
        {
            if(startNumber == -1){
                startNumber = token.Number;
            }
            tokenList.Add(token);
        }

        /*
         * Добавляет в таблицу запись про новую лексему.
         */
        public void AddToken(string tokenName)
        {
            if (tokenList.Count == 0)
            {
                tokenList.Add(new TokenBase(tokenName, startNumber));
            }
            else
            {
                tokenList.Add(new TokenBase(tokenName, tokenList.Last().Number + 1));
            }
        }

        /*
         * Возвращает ссылку на первое вхождение лексемы с именем tokenName.
         * Если такой лексемы нет, возвращает null.
         */
        public TokenBase GetTokenByName(string tokenName)
        {
            for (int i = 0; i < tokenList.Count; i++ )
            {
                if(tokenList[i].Name.Equals(tokenName)){
                    return tokenList[i];
                }
            }
            return new TokenBase(tokenName, -1);
        }

        /*
         * Возвращает ссылку на первое вхождение лексемы с номером tokenNumber.
         * Если такой лексемы нет, возвращает null.
         */
        public TokenBase GetTokenByNumber(int tokenNumber)
        {
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (tokenList[i].Number == tokenNumber)
                {
                    return tokenList[i];
                }
            }
            return null;
        }
    }
}
