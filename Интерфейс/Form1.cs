using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Scanner;
using Parser;
using CodeGenerator;

namespace Интерфейс
{
    public partial class Form1 : Form
    {
        Scanner.Scanner scanner;
        Parser.Parser parser;
        CodeGenerator.CodeGenerator codeGenerator;

        public Form1()
        {
            InitializeComponent();
        }

        private void selectTableKeyWords_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                pathTableKeyWords.Text = filename;
            }
        }

        private void selectTableIdentifiers_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                pathTableIdentifiers.Text = filename;
            }
        }

        private void selectTableConstants_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                pathTableConstants.Text = filename;
            }
        }

        private void selectTableSymbols_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                pathTableSymbols.Text = filename;
            }
        }

        private void selectProgram_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                pathProgram.Text = filename;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scanner = Scanner.ScannerSetup.GetScanner(pathTableKeyWords.Text,
                                                      pathTableIdentifiers.Text,
                                                      pathTableConstants.Text,
                                                      pathTableSymbols.Text
                                                      );
            scanner.Scan(new StreamReader(pathProgram.Text).ReadToEnd());
            if (scanner.ListErrors.GetTokenByPosition(0) == null)
            {
                startSintAnalysis.Enabled = true;
            }
            else
            {
                errorsTextBox.Text = "Ошибки лексические:\n";
                int i = 0;
                while (null != scanner.ListErrors.GetTokenByPosition(i)){
                    errorsTextBox.Text = errorsTextBox.Text + scanner.ListErrors.GetTokenByPosition(i).Row + " : " +
                                         scanner.ListErrors.GetTokenByPosition(i).Column + "\n";
                    i++;
                }
            }
        }

        private void startSintAnalysis_Click(object sender, EventArgs e)
        {
            parser = new Parser.Parser(scanner.ListTokens);
            if (parser.ListErrors.GetTokenByPosition(0) == null)
            {
                startCodeGen.Enabled = true;
            }
            else
            {
                errorsTextBox.Text = "Ошибки синтаксические:\n";
                int i = 0;
                while (null != parser.ListErrors.GetTokenByPosition(i))
                {
                    errorsTextBox.Text = errorsTextBox.Text + parser.ListErrors.GetTokenByPosition(i).Row + " : " +
                                         parser.ListErrors.GetTokenByPosition(i).Column + "\n";
                    i++;
                }
            }
        }

        private void startCodeGen_Click(object sender, EventArgs e)
        {
            codeGenerator = new CodeGenerator.CodeGenerator(parser.programXML,
                                                            scanner.TabKeyWords,
                                                            scanner.TabIdentifiers,
                                                            scanner.TabConstants
                                                            );
            if (codeGenerator.ListErrors.Count > 0)
            {
                errorsTextBox.Text = "Ошибки семантические:\n";
                for (int i = 0; i < codeGenerator.ListErrors.Count; i++ )
                {
                    errorsTextBox.Text = errorsTextBox.Text + codeGenerator.ListErrors[i];
                }
            }
        }

        
    }
}
