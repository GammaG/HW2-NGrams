﻿namespace NGrams
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoadF = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrint = new System.Windows.Forms.Button();
            this.resultsText = new System.Windows.Forms.RichTextBox();
            this.languageBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadF
            // 
            this.btnLoadF.Location = new System.Drawing.Point(12, 12);
            this.btnLoadF.Name = "btnLoadF";
            this.btnLoadF.Size = new System.Drawing.Size(75, 23);
            this.btnLoadF.TabIndex = 0;
            this.btnLoadF.Text = "load Files";
            this.btnLoadF.UseVisualStyleBackColor = true;
            this.btnLoadF.Click += new System.EventHandler(this.btnLoadF_Click);
            // 
            // chart
            // 
            chartArea4.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart.Legends.Add(legend4);
            this.chart.Location = new System.Drawing.Point(307, 12);
            this.chart.Name = "chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(365, 340);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 50);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // resultsText
            // 
            this.resultsText.Location = new System.Drawing.Point(12, 123);
            this.resultsText.Name = "resultsText";
            this.resultsText.Size = new System.Drawing.Size(249, 229);
            this.resultsText.TabIndex = 3;
            this.resultsText.Text = "";
            // 
            // languageBox
            // 
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            "English"});
            this.languageBox.Location = new System.Drawing.Point(151, 12);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(121, 21);
            this.languageBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 390);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.resultsText);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.btnLoadF);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadF;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RichTextBox resultsText;
        private System.Windows.Forms.ComboBox languageBox;
    }
}

