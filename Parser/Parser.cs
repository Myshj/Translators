using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tokens;
using System.Xml;

namespace Parser
{
    public class Parser
    {
        /*Список лексем.*/
        TokenList tokenList;

        /*Список синтаксичних помилок.*/
        TokenList listErrors;

        public TokenList ListErrors
        {
            get { return listErrors; }
        }

        /*Дерево розбору.*/
        public XmlDocument programXML;
        ProgramNode programTree;
        
        /*Номер поточної лексеми в списку лексем.*/
        int tokenNumber;
        
        /*Лексема з таблиці лексем.*/
        TokenInProgram token;
        
        /*Конструктор.*/
        public Parser(TokenList newTokenList)
        {
            programXML = new XmlDocument();
            tokenList = newTokenList;
            listErrors = new TokenList();
            tokenNumber = 0;
            Scan();
            Program();
            System.IO.StreamWriter log = new System.IO.StreamWriter("Log.txt");
            ProgramTreeToString(programTree, 0, log);
            log.Close();
            log.Dispose();

            programXML.Save("LogXML.xml");

            XmlNodeList l = programXML.GetElementsByTagName("variable-identifier");
        }
        void Error()
        {
            listErrors.AddToken(tokenList.GetTokenByPosition(tokenNumber));
        }

        /*
         * Читає із списку лексем наступну лексему і записує її в token.
         * Інкрементує номер поточної лексеми.
         */
        void Scan()
        {
            token = tokenList.GetTokenByPosition(tokenNumber);
            tokenNumber++;
        }

        void Program() //ok
        {
            XmlNode element = programXML.CreateElement("program");
            

            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "PROCEDURE <procedure-identifier><parameters-list>;<block>;";
            element.Attributes.Append(attribute);

            programXML.AppendChild(element);




            programTree = new ProgramNode();
            programTree.text = "PROCEDURE <procedure-identifier><parameters-list>;<block>;";
            programTree.childNodes.Add(new ProgramNode());

            // Програма повинна починатися з PROCEDURE.
            if (token.Number != 401)
            {
                Error();
                return;
            }
            Scan();
            ProcedureIdentifier(programTree.childNodes[0], programXML.LastChild);
     

            programTree.childNodes.Add(new ProgramNode());
            ParametersList(programTree.childNodes[1], programXML.LastChild);
            if (token.Name != ";")
            {
                Error();
                return;
            }
            Scan();
            programTree.childNodes.Add(new ProgramNode());
            Block(programTree.childNodes[2], programXML.LastChild);
            // Програма повинна закінчуватись ';'.
            if (token.Name != ";")
            {
                Error();
                return;
            }
        }

        void ProcedureIdentifier(ProgramNode node,   XmlNode nodeXML) //ok
        {
            XmlNode element = programXML.CreateElement("procedure-identifier");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "identifier";
            element.Attributes.Append(attribute);
            nodeXML.AppendChild(element);




            node.text = "<procedure-identifier>";
            // Ідентифікатор процедури - це ідентифікатор.
            if (token.Number < 1001)
            {
                Error();
                return;
            }

            nodeXML.FirstChild.InnerText = token.Name;

            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<identifier>";
            node.childNodes[0].childNodes.Add(new ProgramNode());
            node.childNodes[0].childNodes[0].text = token.Name;
            Scan();
        }

        void ParametersList(ProgramNode node, XmlNode nodeXML) //ok
        {
            XmlNode element = programXML.CreateElement("parameters-list");
            XmlAttribute attribute = programXML.CreateAttribute("type");



            node.text = "<parameters-list>";
            node.childNodes.Add(new ProgramNode());
            // Список параметрів починається з '('.
            // Або його немає взагалі - стоїть ';'.
            if (token.Name == ";")
            {
                //Scan();
                attribute.Value = "<empty>";
                element.Attributes.Append(attribute);
                nodeXML.AppendChild(element);
                node.childNodes[0].text = "<empty>";
                return;
            }
            if (token.Name != "(")
            {
                Error();
                return;
            }
            attribute.Value = "(<declarations-list>)";
            element.Attributes.Append(attribute);
            nodeXML.AppendChild(element);
            node.childNodes[0].text = "(<declarations-list>)";
            node.childNodes[0].childNodes.Add(new ProgramNode());

            Scan();
            if (token.Name != ")")
            {
                DeclarationsList(node.childNodes[0].childNodes[0], nodeXML.LastChild);
            }
            else
            {
                element = programXML.CreateElement("declarations-list");
                nodeXML.AppendChild(element);
                node.childNodes[0].childNodes[0].text = "<declarations-list>";
                node.childNodes[0].childNodes[0].childNodes.Add(new ProgramNode());
                node.childNodes[0].childNodes[0].childNodes[0].text = "<empty>";
            }
            if (token.Name != ")")
            {
                Error();
                return;
            }
            Scan();

        }
        void DeclarationsList(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("declarations-list");
            

            node.text = "<declarations-list>";
            nodeXML.AppendChild(element);
            node.childNodes.Add(new ProgramNode());
            if (token.Name == ")")
            {
                //Scan();
                node.childNodes[0].text = "<empty>";
                return;
            }
            Declaration(node.childNodes[0], nodeXML.LastChild);
            node.childNodes.Add(new ProgramNode());
            element = programXML.CreateElement("declarations-list");
            nodeXML.AppendChild(element);
            DeclarationsList(node.childNodes[1], nodeXML.LastChild);
        }
        
        
        void Declaration(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("declaration");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "<variable-identifier>:<attribute>;";
            element.Attributes.Append(attribute);
            nodeXML.AppendChild(element);




            node.text = "<declaration>";
            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<variable-identifier>:<attribute>;";
            node.childNodes[0].childNodes.Add(new ProgramNode());
            VariableIdentifier(node.childNodes[0].childNodes[0], nodeXML.LastChild);
            if (token.Name != ":")
            {
                Error();
                return;
            }
            Scan();
            node.childNodes[0].childNodes.Add(new ProgramNode());
            Attribute(node.childNodes[0].childNodes[1], nodeXML.LastChild);
            if (token.Name != ";")
            {
                Error();
                return;
            }
            Scan();
        }
        void VariableIdentifier(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("variable-identifier");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "identifier";
            element.Attributes.Append(attribute);



            node.text = "<variable-identifier>";
            // Ідентифікатор змінної - ідентифікатор.
            if (token.Number < 1001)
            {
                Error();
                return;
            }

            element.InnerText = token.Name;
            
            nodeXML.AppendChild(element);

            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<identifier>";
            node.childNodes[0].childNodes.Add(new ProgramNode());
            node.childNodes[0].childNodes[0].text = token.Name;
            Scan();
        }
        void Attribute(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("attribute");




            node.text = "<attribute>";
            // Атрибут - це INTEGER або FLOAT.
            if (token.Number != 1001 && token.Number != 1002)
            {
                Error();
                return;
            }

            element.InnerText = token.Name;
            nodeXML.AppendChild(element);

            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = token.Name;
            Scan();
        }

        void Block(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("block");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "<declarations>BEGIN<statements-list>END";
            element.Attributes.Append(attribute);
            nodeXML.AppendChild(element);




            node.text = "<block>";
            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<declarations>BEGIN<statements-list>END";
            node.childNodes[0].childNodes.Add(new ProgramNode());
            Declarations(node.childNodes[0].childNodes[0], nodeXML.LastChild);
            // BEGIN
            if (token.Number != 403)
            {
                Error();
                return;
            }
            Scan();
            node.childNodes[0].childNodes.Add(new ProgramNode());
            StatementsList(node.childNodes[0].childNodes[1], nodeXML.LastChild);
            // END
            if (token.Number != 404)
            {
                Error();
                return;
            }
            Scan();
        }
        void Declarations(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("declarations");
            nodeXML.AppendChild(element);




            node.text = "<declarations>";
            node.childNodes.Add(new ProgramNode());
            ConstantDeclarations(node.childNodes[0], nodeXML.LastChild);
            //Scan();
        }
        void ConstantDeclarations(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("constant-declarations");
            nodeXML.AppendChild(element);




            node.text = "<constant-declarations>";
            node.childNodes.Add(new ProgramNode());
            // Оголошення константи починається зі слова CONST.
            // Або його немає взагалі.
            if (token.Number != 402)
            {
                node.childNodes[0].text = "<empty>";
                return;
            }
            Scan();
            ConstantDeclarationsList(node.childNodes[0], nodeXML.LastChild);
        }
        void ConstantDeclarationsList(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("constant-declarations-list");
            nodeXML.AppendChild(element);




            node.text = "<constant-declarations-list>";
            node.childNodes.Add(new ProgramNode());
            // Оголошення констант може бути відсутнім взагалі.
            // CONST
            if (token.Number == 403)
            {
                node.childNodes[0].text = "<empty>";
                return;
            }
            ConstantDeclaration(node.childNodes[0], nodeXML.LastChild);
            node.childNodes.Add(new ProgramNode());
            ConstantDeclarationsList(node.childNodes[1], nodeXML.LastChild);
        }
        
        
        void ConstantDeclaration(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("constant-declaration");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "<constant-identifier>=<constant>;";
            element.Attributes.Append(attribute);
            nodeXML.AppendChild(element);




            node.text = "<constant-declaration>";
            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<constant-identifier>=<constant>;";
            node.childNodes[0].childNodes.Add(new ProgramNode());
            ConstantIdentifier(node.childNodes[0].childNodes[0], nodeXML.LastChild);
            
            if (token.Name != "=")
            {
                Error();
                return;
            }
            Scan();

            element = programXML.CreateElement("constant");
            attribute = programXML.CreateAttribute("type");

            node.childNodes[0].childNodes.Add(new ProgramNode());
            node.childNodes[0].childNodes[1].text = "<constant>";
            node.childNodes[0].childNodes[1].childNodes.Add(new ProgramNode());
            if (token.Name == "-")
            {
                Scan();
                attribute.Value = "-<unsigned-integer>";
                node.childNodes[0].childNodes[1].childNodes[0].text = "-<unsigned-integer>";
            }
            else
            {
                attribute.Value = "<unsigned-integer>";
                node.childNodes[0].childNodes[1].childNodes[0].text = "<unsigned-integer>";
            }
            element.Attributes.Append(attribute);
            nodeXML.LastChild.AppendChild(element); ////////////////////////////////////////////////////
            node.childNodes[0].childNodes[1].childNodes[0].childNodes.Add(new ProgramNode());
            Constant(node.childNodes[0].childNodes[1].childNodes[0].childNodes[0], nodeXML.LastChild.LastChild);
            if (token.Name != ";")
            {
                Error();
                return;
            }
            Scan();
        }
        void ConstantIdentifier(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("constant-identifier");
            XmlAttribute attribute = programXML.CreateAttribute("type");
            attribute.Value = "<identifier>";
            element.Attributes.Append(attribute);




            node.text = "<constant-identifier>";
            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<identifier>";

            if (token.Number < 1001)
            {
                Error();
                return;
            }
            node.childNodes[0].childNodes.Add(new ProgramNode());
            element.InnerText = token.Name;
            nodeXML.AppendChild(element);
            node.childNodes[0].childNodes[0].text = token.Name;
            Scan();
        }
        void Constant(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("unsigned-integer");
           



            node.text = "<unsigned-integer>";
            if (token.Number < 501 || token.Number > 1000)
            {
                Error();
                return;
            }
            node.childNodes.Add(new ProgramNode());
            element.InnerText = token.Name;
            nodeXML.AppendChild(element);
            node.childNodes[0].text = token.Name;
            Scan();
        }
        void StatementsList(ProgramNode node, XmlNode nodeXML)
        {
            XmlNode element = programXML.CreateElement("statements-list");
            nodeXML.AppendChild(element);




            node.text = "<statements-list>";
            if (token.Number != 404)
            {
                Error();
                return;
            }
            node.childNodes.Add(new ProgramNode());
            node.childNodes[0].text = "<empty>";
        }

        /*
         * Виконує рекурсивний обхід дерева розбору.
         * Записує інформацію з нього у  потік.
         */
        void ProgramTreeToString(ProgramNode node, int depth, System.IO.StreamWriter streamWriter)
        {


            string ret = "";
            for (int j = 0; j < depth; j++)
            {
                ret += "\t";
            }
            ret += node.text;
            streamWriter.WriteLine(ret);
            for (int i = 0; i < node.childNodes.Count; i++)
            {
                ProgramTreeToString(node.childNodes[i], depth + 1, streamWriter);
            }
        }
    }
}
