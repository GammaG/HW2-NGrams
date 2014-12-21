namespace NGrams
{
    partial class MainFrame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadF = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.resultsText = new System.Windows.Forms.RichTextBox();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btn_print_result = new System.Windows.Forms.Button();
            this.btn_abort = new System.Windows.Forms.Button();
            this.btnSearchByTerm = new System.Windows.Forms.Button();
            this.btnSeachForSimilar = new System.Windows.Forms.Button();
            this.btn_printSentenceByID = new System.Windows.Forms.Button();
            this.minNGrams = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minNGrams)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadF
            // 
            this.btnLoadF.Location = new System.Drawing.Point(12, 35);
            this.btnLoadF.Name = "btnLoadF";
            this.btnLoadF.Size = new System.Drawing.Size(121, 23);
            this.btnLoadF.TabIndex = 0;
            this.btnLoadF.Text = "Load Files";
            this.btnLoadF.UseVisualStyleBackColor = true;
            this.btnLoadF.Click += new System.EventHandler(this.btnLoadF_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(170, 88);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(181, 22);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print all sentences in the collection";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // resultsText
            // 
            this.resultsText.Location = new System.Drawing.Point(12, 116);
            this.resultsText.Name = "resultsText";
            this.resultsText.Size = new System.Drawing.Size(683, 262);
            this.resultsText.TabIndex = 3;
            this.resultsText.Text = "";
            // 
            // languageBox
            // 
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            "English"});
            this.languageBox.Location = new System.Drawing.Point(12, 11);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(121, 21);
            this.languageBox.TabIndex = 4;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(171, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(517, 20);
            this.searchBox.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(171, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(180, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search for NGram";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btn_print_result
            // 
            this.btn_print_result.Location = new System.Drawing.Point(357, 88);
            this.btn_print_result.Name = "btn_print_result";
            this.btn_print_result.Size = new System.Drawing.Size(158, 23);
            this.btn_print_result.TabIndex = 8;
            this.btn_print_result.Text = "Print found Sentences";
            this.btn_print_result.UseVisualStyleBackColor = true;
            this.btn_print_result.Click += new System.EventHandler(this.btn_print_result_Click);
            // 
            // btn_abort
            // 
            this.btn_abort.Location = new System.Drawing.Point(523, 89);
            this.btn_abort.Name = "btn_abort";
            this.btn_abort.Size = new System.Drawing.Size(165, 21);
            this.btn_abort.TabIndex = 9;
            this.btn_abort.Text = "Abort Printing";
            this.btn_abort.UseVisualStyleBackColor = true;
            this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
            // 
            // btnSearchByTerm
            // 
            this.btnSearchByTerm.Location = new System.Drawing.Point(357, 38);
            this.btnSearchByTerm.Name = "btnSearchByTerm";
            this.btnSearchByTerm.Size = new System.Drawing.Size(158, 23);
            this.btnSearchByTerm.TabIndex = 10;
            this.btnSearchByTerm.Text = "Search by Term";
            this.btnSearchByTerm.UseVisualStyleBackColor = true;
            this.btnSearchByTerm.Click += new System.EventHandler(this.btnSearchByTerm_Click);
            // 
            // btnSeachForSimilar
            // 
            this.btnSeachForSimilar.Location = new System.Drawing.Point(523, 38);
            this.btnSeachForSimilar.Name = "btnSeachForSimilar";
            this.btnSeachForSimilar.Size = new System.Drawing.Size(165, 23);
            this.btnSeachForSimilar.TabIndex = 11;
            this.btnSeachForSimilar.Text = "Search Similar Sentences";
            this.btnSeachForSimilar.UseVisualStyleBackColor = true;
            this.btnSeachForSimilar.Click += new System.EventHandler(this.btnSeachForSimilar_Click);
            // 
            // btn_printSentenceByID
            // 
            this.btn_printSentenceByID.Location = new System.Drawing.Point(171, 63);
            this.btn_printSentenceByID.Name = "btn_printSentenceByID";
            this.btn_printSentenceByID.Size = new System.Drawing.Size(180, 23);
            this.btn_printSentenceByID.TabIndex = 12;
            this.btn_printSentenceByID.Text = "Print Sentence by given ID";
            this.btn_printSentenceByID.UseVisualStyleBackColor = true;
            this.btn_printSentenceByID.Click += new System.EventHandler(this.btn_printSentenceByID_Click);
            // 
            // minNGrams
            // 
            this.minNGrams.Location = new System.Drawing.Point(652, 63);
            this.minNGrams.Name = "minNGrams";
            this.minNGrams.Size = new System.Drawing.Size(36, 20);
            this.minNGrams.TabIndex = 13;
            this.minNGrams.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Min NGram matches";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minNGrams);
            this.Controls.Add(this.btn_printSentenceByID);
            this.Controls.Add(this.btnSeachForSimilar);
            this.Controls.Add(this.btnSearchByTerm);
            this.Controls.Add(this.btn_abort);
            this.Controls.Add(this.btn_print_result);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.resultsText);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoadF);
            this.Name = "MainFrame";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.minNGrams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadF;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RichTextBox resultsText;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btn_print_result;
        private System.Windows.Forms.Button btn_abort;
        private System.Windows.Forms.Button btnSearchByTerm;
        private System.Windows.Forms.Button btnSeachForSimilar;
        private System.Windows.Forms.Button btn_printSentenceByID;
        private System.Windows.Forms.NumericUpDown minNGrams;
        private System.Windows.Forms.Label label1;
    }
}

