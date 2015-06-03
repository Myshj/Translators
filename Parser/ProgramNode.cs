using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    class ProgramNode
    {
        // Дочірні вузли.
        public List<ProgramNode> childNodes;
        // Фрагмент тексту програми, що відповідає вузлу.
        public string text;
        public ProgramNode()
        {
            childNodes = new List<ProgramNode>();
            text = "";
        }
        public ProgramNode(string newText, List<ProgramNode> newChildNodes)
        {
            if (null == newChildNodes)
            {
                childNodes = new List<ProgramNode>();
            }
            text = newText;
        }
    }
}
