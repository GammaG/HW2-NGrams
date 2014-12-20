namespace NGrams
{
    partial class Form1
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
            this.btnNGrams = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btn_print_result = new System.Windows.Forms.Button();
            this.btn_abort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadF
            // 
            this.btnLoadF.Location = new System.Drawing.Point(12, 35);
            this.btnLoadF.Name = "btnLoadF";
            this.btnLoadF.Size = new System.Drawing.Size(75, 23);
            this.btnLoadF.TabIndex = 0;
            this.btnLoadF.Text = "load Files";
            this.btnLoadF.UseVisualStyleBackColor = true;
            this.btnLoadF.Click += new System.EventHandler(this.btnLoadF_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(561, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 22);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "print all clean sentences";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // resultsText
            // 
            this.resultsText.Location = new System.Drawing.Point(12, 123);
            this.resultsText.Name = "resultsText";
            this.resultsText.Size = new System.Drawing.Size(683, 255);
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
            // btnNGrams
            // 
            this.btnNGrams.Location = new System.Drawing.Point(12, 64);
            this.btnNGrams.Name = "btnNGrams";
            this.btnNGrams.Size = new System.Drawing.Size(75, 23);
            this.btnNGrams.TabIndex = 5;
            this.btnNGrams.Text = "gen NGrams";
            this.btnNGrams.UseVisualStyleBackColor = true;
            this.btnNGrams.Click += new System.EventHandler(this.btnNGrams_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(171, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(344, 20);
            this.searchBox.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(171, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btn_print_result
            // 
            this.btn_print_result.Location = new System.Drawing.Point(252, 38);
            this.btn_print_result.Name = "btn_print_result";
            this.btn_print_result.Size = new System.Drawing.Size(142, 23);
            this.btn_print_result.TabIndex = 8;
            this.btn_print_result.Text = "print found sentences";
            this.btn_print_result.UseVisualStyleBackColor = true;
            this.btn_print_result.Click += new System.EventHandler(this.btn_print_result_Click);
            // 
            // btn_abort
            // 
            this.btn_abort.Location = new System.Drawing.Point(592, 40);
            this.btn_abort.Name = "btn_abort";
            this.btn_abort.Size = new System.Drawing.Size(103, 21);
            this.btn_abort.TabIndex = 9;
            this.btn_abort.Text = "abort printing";
            this.btn_abort.UseVisualStyleBackColor = true;
            this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 390);
            this.Controls.Add(this.btn_abort);
            this.Controls.Add(this.btn_print_result);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.btnNGrams);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.resultsText);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoadF);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadF;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RichTextBox resultsText;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.Button btnNGrams;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btn_print_result;
        private System.Windows.Forms.Button btn_abort;
    }
}

