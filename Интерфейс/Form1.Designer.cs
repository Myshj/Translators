namespace Интерфейс
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathTableKeyWords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectTableKeyWords = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectTableIdentifiers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pathTableIdentifiers = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.selectTableConstants = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pathTableConstants = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.selectTableSymbols = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pathTableSymbols = new System.Windows.Forms.TextBox();
            this.startLexAnalysis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.selectProgram = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pathProgram = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startSintAnalysis = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.startCodeGen = new System.Windows.Forms.Button();
            this.errorsTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathTableKeyWords
            // 
            this.pathTableKeyWords.Location = new System.Drawing.Point(3, 28);
            this.pathTableKeyWords.Name = "pathTableKeyWords";
            this.pathTableKeyWords.Size = new System.Drawing.Size(679, 20);
            this.pathTableKeyWords.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таблица ключевых слов";
            // 
            // selectTableKeyWords
            // 
            this.selectTableKeyWords.Location = new System.Drawing.Point(688, 26);
            this.selectTableKeyWords.Name = "selectTableKeyWords";
            this.selectTableKeyWords.Size = new System.Drawing.Size(75, 23);
            this.selectTableKeyWords.TabIndex = 2;
            this.selectTableKeyWords.Text = "Выбрать";
            this.selectTableKeyWords.UseVisualStyleBackColor = true;
            this.selectTableKeyWords.Click += new System.EventHandler(this.selectTableKeyWords_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectTableKeyWords);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pathTableKeyWords);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 48);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectTableIdentifiers);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pathTableIdentifiers);
            this.panel2.Location = new System.Drawing.Point(12, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 48);
            this.panel2.TabIndex = 4;
            // 
            // selectTableIdentifiers
            // 
            this.selectTableIdentifiers.Location = new System.Drawing.Point(688, 26);
            this.selectTableIdentifiers.Name = "selectTableIdentifiers";
            this.selectTableIdentifiers.Size = new System.Drawing.Size(75, 23);
            this.selectTableIdentifiers.TabIndex = 2;
            this.selectTableIdentifiers.Text = "Выбрать";
            this.selectTableIdentifiers.UseVisualStyleBackColor = true;
            this.selectTableIdentifiers.Click += new System.EventHandler(this.selectTableIdentifiers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Таблица идентификаторов";
            // 
            // pathTableIdentifiers
            // 
            this.pathTableIdentifiers.Location = new System.Drawing.Point(3, 28);
            this.pathTableIdentifiers.Name = "pathTableIdentifiers";
            this.pathTableIdentifiers.Size = new System.Drawing.Size(679, 20);
            this.pathTableIdentifiers.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.selectTableConstants);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pathTableConstants);
            this.panel3.Location = new System.Drawing.Point(12, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 48);
            this.panel3.TabIndex = 5;
            // 
            // selectTableConstants
            // 
            this.selectTableConstants.Location = new System.Drawing.Point(688, 26);
            this.selectTableConstants.Name = "selectTableConstants";
            this.selectTableConstants.Size = new System.Drawing.Size(75, 23);
            this.selectTableConstants.TabIndex = 2;
            this.selectTableConstants.Text = "Выбрать";
            this.selectTableConstants.UseVisualStyleBackColor = true;
            this.selectTableConstants.Click += new System.EventHandler(this.selectTableConstants_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Таблица констант";
            // 
            // pathTableConstants
            // 
            this.pathTableConstants.Location = new System.Drawing.Point(3, 28);
            this.pathTableConstants.Name = "pathTableConstants";
            this.pathTableConstants.Size = new System.Drawing.Size(679, 20);
            this.pathTableConstants.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.selectTableSymbols);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.pathTableSymbols);
            this.panel4.Location = new System.Drawing.Point(12, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 48);
            this.panel4.TabIndex = 6;
            // 
            // selectTableSymbols
            // 
            this.selectTableSymbols.Location = new System.Drawing.Point(688, 26);
            this.selectTableSymbols.Name = "selectTableSymbols";
            this.selectTableSymbols.Size = new System.Drawing.Size(75, 23);
            this.selectTableSymbols.TabIndex = 2;
            this.selectTableSymbols.Text = "Выбрать";
            this.selectTableSymbols.UseVisualStyleBackColor = true;
            this.selectTableSymbols.Click += new System.EventHandler(this.selectTableSymbols_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Таблица символов";
            // 
            // pathTableSymbols
            // 
            this.pathTableSymbols.Location = new System.Drawing.Point(3, 28);
            this.pathTableSymbols.Name = "pathTableSymbols";
            this.pathTableSymbols.Size = new System.Drawing.Size(679, 20);
            this.pathTableSymbols.TabIndex = 0;
            // 
            // startLexAnalysis
            // 
            this.startLexAnalysis.Location = new System.Drawing.Point(9, 345);
            this.startLexAnalysis.Name = "startLexAnalysis";
            this.startLexAnalysis.Size = new System.Drawing.Size(75, 23);
            this.startLexAnalysis.TabIndex = 7;
            this.startLexAnalysis.Text = "Запустить";
            this.startLexAnalysis.UseVisualStyleBackColor = true;
            this.startLexAnalysis.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Лексический анализ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.selectProgram);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.pathProgram);
            this.panel5.Location = new System.Drawing.Point(12, 232);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(760, 48);
            this.panel5.TabIndex = 9;
            // 
            // selectProgram
            // 
            this.selectProgram.Location = new System.Drawing.Point(688, 26);
            this.selectProgram.Name = "selectProgram";
            this.selectProgram.Size = new System.Drawing.Size(75, 23);
            this.selectProgram.TabIndex = 2;
            this.selectProgram.Text = "Выбрать";
            this.selectProgram.UseVisualStyleBackColor = true;
            this.selectProgram.Click += new System.EventHandler(this.selectProgram_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Программа";
            // 
            // pathProgram
            // 
            this.pathProgram.Location = new System.Drawing.Point(3, 28);
            this.pathProgram.Name = "pathProgram";
            this.pathProgram.Size = new System.Drawing.Size(679, 20);
            this.pathProgram.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(232, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Синтаксический анализ";
            // 
            // startSintAnalysis
            // 
            this.startSintAnalysis.Enabled = false;
            this.startSintAnalysis.Location = new System.Drawing.Point(237, 345);
            this.startSintAnalysis.Name = "startSintAnalysis";
            this.startSintAnalysis.Size = new System.Drawing.Size(75, 23);
            this.startSintAnalysis.TabIndex = 11;
            this.startSintAnalysis.Text = "Запустить";
            this.startSintAnalysis.UseVisualStyleBackColor = true;
            this.startSintAnalysis.Click += new System.EventHandler(this.startSintAnalysis_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(491, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Генерация кода";
            // 
            // startCodeGen
            // 
            this.startCodeGen.Enabled = false;
            this.startCodeGen.Location = new System.Drawing.Point(496, 345);
            this.startCodeGen.Name = "startCodeGen";
            this.startCodeGen.Size = new System.Drawing.Size(75, 23);
            this.startCodeGen.TabIndex = 13;
            this.startCodeGen.Text = "Запустить";
            this.startCodeGen.UseVisualStyleBackColor = true;
            this.startCodeGen.Click += new System.EventHandler(this.startCodeGen_Click);
            // 
            // errorsTextBox
            // 
            this.errorsTextBox.Location = new System.Drawing.Point(12, 374);
            this.errorsTextBox.Name = "errorsTextBox";
            this.errorsTextBox.Size = new System.Drawing.Size(651, 176);
            this.errorsTextBox.TabIndex = 14;
            this.errorsTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.errorsTextBox);
            this.Controls.Add(this.startCodeGen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.startSintAnalysis);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startLexAnalysis);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTableKeyWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectTableKeyWords;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button selectTableIdentifiers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathTableIdentifiers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button selectTableConstants;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pathTableConstants;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button selectTableSymbols;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pathTableSymbols;
        private System.Windows.Forms.Button startLexAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button selectProgram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pathProgram;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button startSintAnalysis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button startCodeGen;
        private System.Windows.Forms.RichTextBox errorsTextBox;
    }
}

