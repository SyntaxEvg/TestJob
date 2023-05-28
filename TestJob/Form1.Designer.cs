namespace TestJob
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            combo = new ComboBox();
            lBinance = new Label();
            lBybit = new Label();
            lkucoin = new Label();
            refreshButton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // combo
            // 
            combo.FormattingEnabled = true;
            combo.Location = new Point(24, 24);
            combo.Name = "combo";
            combo.Size = new Size(121, 23);
            combo.TabIndex = 0;
            combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            // 
            // lBinance
            // 
            lBinance.AutoSize = true;
            lBinance.Location = new Point(254, 55);
            lBinance.Name = "lBinance";
            lBinance.Size = new Size(75, 15);
            lBinance.TabIndex = 1;
            lBinance.Text = "BinancePrice";
            // 
            // lBybit
            // 
            lBybit.AutoSize = true;
            lBybit.Location = new Point(354, 55);
            lBybit.Name = "lBybit";
            lBybit.Size = new Size(60, 15);
            lBybit.TabIndex = 2;
            lBybit.Text = "BybitPrice";
            // 
            // lkucoin
            // 
            lkucoin.AutoSize = true;
            lkucoin.Location = new Point(444, 55);
            lkucoin.Name = "lkucoin";
            lkucoin.Size = new Size(57, 15);
            lkucoin.TabIndex = 3;
            lkucoin.Text = "KoinPrice";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(42, 129);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 32);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 7;
            label2.Text = "BinancePrice";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(354, 32);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "BybitPrice";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(444, 32);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 9;
            label4.Text = "KoinPrice";
            // 
            // button1
            // 
            button1.Location = new Point(42, 170);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Stop Timer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 376);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(refreshButton);
            Controls.Add(lkucoin);
            Controls.Add(lBybit);
            Controls.Add(lBinance);
            Controls.Add(combo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox combo;
        private Label lBinance;
        private Label lBybit;
        private Label lkucoin;
        private Button refreshButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}