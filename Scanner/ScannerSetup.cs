using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Tokens;

namespace Scanner
{
    /*
     * Этот класс производит настройку лексического анализатора перед его использованием.
     */
    public static class ScannerSetup
    {
        /*
         * Функция получает строки-пути к следующим файлам предопределенных таблиц:
         * 1. Ключевых слов
         * 2. Идентификаторов
         * 3. Констант
         * 4. Символов
         * Возвращает готовый к работе лексический анализатор.
         */
        public static Scanner GetScanner(
                                          string fileKeyWords,
                                          string fileIdentifiers,
                                          string fileConstants,
                                          string fileSymbols
                                         )
        {
            TokenTable tabKeyWords = new TokenTable(GetTokenTableFromFile(fileKeyWords), 401);
            TokenTable tabIdentifiers = new TokenTable(GetTokenTableFromFile(fileIdentifiers), 1001);
            TokenTable tabConstants = new TokenTable(GetTokenTableFromFile(fileConstants), 501);
            TokenTable tabSymbols = new TokenTable(GetTableSymbolsFromFile(fileSymbols), 0);

            return new Scanner(tabKeyWords, tabIdentifiers, tabConstants, tabSymbols);
        }

        /*
         * На основе данных, полученных из XML-файла, строит таблицу разрешенных/запрещенных символов.
         */
        static List<TokenBase> GetTableSymbolsFromFile(string filePath)
        {
            

            XmlDocument tableXML = new XmlDocument();
            tableXML.Load(filePath);

            List<TokenBase> table = new List<TokenBase>();
            table.Add(new TokenBase(" ", 0));
            table.Add(new TokenBase("\r", 0));
            table.Add(new TokenBase("\n", 0));
            table.Add(new TokenBase("\t", 0));

            foreach (XmlNode tokenXML in tableXML.SelectSingleNode("table").SelectNodes("token"))
            {
                string tokenText = tokenXML.SelectSingleNode("name").InnerText;
                int tokenNumber = Convert.ToInt32(tokenXML.SelectSingleNode("number").InnerText);

                for (int i = 0; i < tokenText.Length; i++ )
                {
                    table.Add(new TokenBase("" + tokenText[i], tokenNumber));
                }                
            }
           
            return table;
        }

        /*
         * На основе данных, полученных из XML-файла, строит таблицу лексем.
         */
        static List<TokenBase> GetTokenTableFromFile(string filePath)
        {
            XmlDocument tableXML = new XmlDocument();
            tableXML.Load(filePath);

            List<TokenBase> table = new List<TokenBase>();

            foreach (XmlNode tokenXML in tableXML.SelectSingleNode("table").SelectNodes("token"))
            {
                TokenBase token = new TokenBase(tokenXML.SelectSingleNode("name").InnerText,
                                                Convert.ToInt32(tokenXML.SelectSingleNode("number").InnerText));
                table.Add(token);
            }

            return table;
        }
    }
}
