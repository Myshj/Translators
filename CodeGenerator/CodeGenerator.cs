using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Tokens;

namespace CodeGenerator
{
    public class CodeGenerator
    {
        string assemblerCode = "";

        List<string> listErrors;

        public List<string> ListErrors
        {
            get { return listErrors; }
        }

        XmlDocument programTree;
        TokenTable tabKeyWords;
        TokenTable tabIdentifiers;
        TokenTable tabConstants;

        System.IO.StreamWriter sw;
        

        public CodeGenerator(XmlDocument newProgramTree,
                             TokenTable newTabKeyWords,
                             TokenTable newTabIdentifiers,
                             TokenTable newTabConstants)
        {
            listErrors = new List<string>();
            programTree = newProgramTree;
            tabKeyWords = newTabKeyWords;
            tabIdentifiers = newTabIdentifiers;
            tabConstants = newTabConstants;
            sw = new System.IO.StreamWriter("CodeGen.txt");
            Generate();
        }

        public void Generate()
        {
            List<string> checkedIdentifiers = new List<string>();

            assemblerCode = ".386\n";
            sw.WriteLine(assemblerCode);
            assemblerCode = ".CODE\n";
            sw.WriteLine(assemblerCode);

            string procedureName = programTree.GetElementsByTagName("procedure-identifier")[0].InnerText;
            if (-1 == tabKeyWords.GetTokenByName(procedureName).Number)
            {
                checkedIdentifiers.Add(procedureName);

                assemblerCode = procedureName + "\tPROC\n";
                sw.WriteLine(assemblerCode);

                assemblerCode = "\tPUSH EBP;\n";
                sw.WriteLine(assemblerCode);
                assemblerCode = "\tMOV EBP, ESP;\n";
                sw.WriteLine(assemblerCode);
                assemblerCode = "\tPUSH ESI;\n";
                sw.WriteLine(assemblerCode);

                CheckParameters(checkedIdentifiers);
                CheckConstantDeclarations(checkedIdentifiers);

                assemblerCode = "\t\tnop;\n";
                sw.WriteLine(assemblerCode);


                assemblerCode = "\tPOP ESI;\n";
                sw.WriteLine(assemblerCode);
                assemblerCode = "\tPOP EBP;\n";
                sw.WriteLine(assemblerCode);
                assemblerCode = "\tRET;\n";
                sw.WriteLine(assemblerCode);

                assemblerCode = procedureName + "\tENDP\n";
                sw.WriteLine(assemblerCode);
            }
            else
            {
                listErrors.Add("Запрещенное имя процедуры.\n;");
                return;
            }
            sw.Close();
        }


        private void CheckConstantDeclarations(List<string> checkedIdentifiers)
        {
            XmlNodeList constantDeclarations = programTree.GetElementsByTagName("constant-declaration");

            if (0 != constantDeclarations.Count)
            {
                foreach (XmlNode constantDeclaration in constantDeclarations)
                {
                    if (-1 == tabKeyWords.GetTokenByName(constantDeclaration.SelectSingleNode("constant-identifier").InnerText).Number)
                    {
                        if (!checkedIdentifiers.Contains(constantDeclaration.SelectSingleNode("constant-identifier").InnerText))
                        {
                            if (constantDeclaration.LastChild.Attributes[0].Value == "-<unsigned-integer>")
                            {
                                assemblerCode = "\t\t" +
                                                 constantDeclaration.SelectSingleNode("constant-identifier").InnerText +
                                                 " EQU -" +
                                                 constantDeclaration.LastChild.SelectSingleNode("unsigned-integer").InnerText +
                                                 ";\n";
                                sw.WriteLine(assemblerCode);
                            }
                            else if (constantDeclaration.LastChild.Attributes[0].Value == "<unsigned-integer>")
                            {
                                assemblerCode = "\t\t" +
                                                 constantDeclaration.SelectSingleNode("constant-identifier").InnerText +
                                                 " EQU " +
                                                 constantDeclaration.LastChild.SelectSingleNode("unsigned-integer").InnerText +
                                                 ";\n";
                                sw.WriteLine(assemblerCode);
                            }
                            checkedIdentifiers.Add(constantDeclaration.SelectSingleNode("constant-identifier").InnerText);
                        }
                        else
                        {
                            listErrors.Add("Дублирование идентификаторов.");
                            return;
                        }
                    }
                    else
                    {
                        listErrors.Add("Запрещенное имя константы.");
                        return;
                    }
                }
            }
        }


        private void CheckParameters(List<string> checkedIdentifiers)
        {
            XmlNodeList parameterDeclarations = programTree.GetElementsByTagName("declaration");
            
            if (0 != parameterDeclarations.Count)
            {
                int parameterOffset = 8;
                foreach (XmlNode parameterDeclaration in parameterDeclarations)
                {
                    if (-1 == tabKeyWords.GetTokenByName(parameterDeclaration.SelectSingleNode("variable-identifier").InnerText).Number)
                    {
                        if (!checkedIdentifiers.Contains(parameterDeclaration.SelectSingleNode("variable-identifier").InnerText))
                        {
                            assemblerCode = "\t\t" +
                                             parameterDeclaration.SelectSingleNode("variable-identifier").InnerText +
                                             " EQU [EBP + " +
                                             parameterOffset.ToString() +
                                             "];\n";
                            sw.WriteLine(assemblerCode);
                            checkedIdentifiers.Add(parameterDeclaration.SelectSingleNode("variable-identifier").InnerText);
                            switch (parameterDeclaration.SelectSingleNode("attribute").InnerText)
                            {
                                case "INTEGER":
                                    parameterOffset += 2;
                                    break;
                                case "FLOAT":
                                    parameterOffset += 4;
                                    break;
                                default:
                                    listErrors.Add("Неправильный тип параметра.");
                                    return;
                            }
                        }
                        else
                        {
                            listErrors.Add("Дублирование идентификаторов.");
                            return;
                        }
                    }
                    else
                    {
                        listErrors.Add("Запрещенное имя параметра процедуры.");
                        return;
                    }
                }
            }
        }
    }
}
