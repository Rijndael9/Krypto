namespace Lab1
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
            this.label2 = new System.Windows.Forms.Label();
            this.TB1 = new System.Windows.Forms.TextBox();
            this.kTB = new System.Windows.Forms.TextBox();
            this.TB2 = new System.Windows.Forms.TextBox();
            this.encB = new System.Windows.Forms.Button();
            this.decB = new System.Windows.Forms.Button();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.GB2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rlRB = new System.Windows.Forms.RadioButton();
            this.lrRB = new System.Windows.Forms.RadioButton();
            this.genB = new System.Windows.Forms.Button();
            this.dirPB = new System.Windows.Forms.PictureBox();
            this.formatCB = new System.Windows.Forms.CheckBox();
            this.algGB = new System.Windows.Forms.GroupBox();
            this.ecbRB = new System.Windows.Forms.RadioButton();
            this.cbcRB = new System.Windows.Forms.RadioButton();
            this.GB1.SuspendLayout();
            this.GB2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirPB)).BeginInit();
            this.algGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ключ:";
            // 
            // TB1
            // 
            this.TB1.Location = new System.Drawing.Point(6, 19);
            this.TB1.Multiline = true;
            this.TB1.Name = "TB1";
            this.TB1.Size = new System.Drawing.Size(214, 53);
            this.TB1.TabIndex = 3;
            // 
            // kTB
            // 
            this.kTB.Location = new System.Drawing.Point(88, 12);
            this.kTB.Name = "kTB";
            this.kTB.Size = new System.Drawing.Size(156, 20);
            this.kTB.TabIndex = 4;
            // 
            // TB2
            // 
            this.TB2.Location = new System.Drawing.Point(6, 19);
            this.TB2.Multiline = true;
            this.TB2.Name = "TB2";
            this.TB2.Size = new System.Drawing.Size(213, 53);
            this.TB2.TabIndex = 5;
            // 
            // encB
            // 
            this.encB.Location = new System.Drawing.Point(26, 200);
            this.encB.Name = "encB";
            this.encB.Size = new System.Drawing.Size(90, 25);
            this.encB.TabIndex = 6;
            this.encB.Text = "Зашифровать";
            this.encB.UseVisualStyleBackColor = true;
            this.encB.Click += new System.EventHandler(this.encB_Click);
            // 
            // decB
            // 
            this.decB.Location = new System.Drawing.Point(132, 200);
            this.decB.Name = "decB";
            this.decB.Size = new System.Drawing.Size(100, 25);
            this.decB.TabIndex = 7;
            this.decB.Text = "Расшифровать";
            this.decB.UseVisualStyleBackColor = true;
            this.decB.Click += new System.EventHandler(this.decB_Click);
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.TB1);
            this.GB1.Location = new System.Drawing.Point(12, 89);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(232, 85);
            this.GB1.TabIndex = 8;
            this.GB1.TabStop = false;
            this.GB1.Text = "Вход";
            // 
            // GB2
            // 
            this.GB2.Controls.Add(this.TB2);
            this.GB2.Location = new System.Drawing.Point(335, 89);
            this.GB2.Name = "GB2";
            this.GB2.Size = new System.Drawing.Size(238, 85);
            this.GB2.TabIndex = 9;
            this.GB2.TabStop = false;
            this.GB2.Text = "Выход";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rlRB);
            this.groupBox1.Controls.Add(this.lrRB);
            this.groupBox1.Location = new System.Drawing.Point(265, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Направление";
            // 
            // rlRB
            // 
            this.rlRB.AutoSize = true;
            this.rlRB.Location = new System.Drawing.Point(6, 42);
            this.rlRB.Name = "rlRB";
            this.rlRB.Size = new System.Drawing.Size(101, 17);
            this.rlRB.TabIndex = 12;
            this.rlRB.Text = "Справо налево";
            this.rlRB.UseVisualStyleBackColor = true;
            // 
            // lrRB
            // 
            this.lrRB.AutoSize = true;
            this.lrRB.Checked = true;
            this.lrRB.Location = new System.Drawing.Point(6, 19);
            this.lrRB.Name = "lrRB";
            this.lrRB.Size = new System.Drawing.Size(101, 17);
            this.lrRB.TabIndex = 11;
            this.lrRB.TabStop = true;
            this.lrRB.Text = "Слева направо";
            this.lrRB.UseVisualStyleBackColor = true;
            this.lrRB.CheckedChanged += new System.EventHandler(this.lrRB_CheckedChanged);
            // 
            // genB
            // 
            this.genB.Location = new System.Drawing.Point(26, 38);
            this.genB.Name = "genB";
            this.genB.Size = new System.Drawing.Size(98, 22);
            this.genB.TabIndex = 11;
            this.genB.Text = "Сгенерировать";
            this.genB.UseVisualStyleBackColor = true;
            this.genB.Click += new System.EventHandler(this.genB_Click);
            // 
            // dirPB
            // 
            this.dirPB.Image = global::Lab1.Properties.Resources.r;
            this.dirPB.Location = new System.Drawing.Point(265, 108);
            this.dirPB.Name = "dirPB";
            this.dirPB.Size = new System.Drawing.Size(50, 50);
            this.dirPB.TabIndex = 12;
            this.dirPB.TabStop = false;
            // 
            // formatCB
            // 
            this.formatCB.AutoSize = true;
            this.formatCB.Location = new System.Drawing.Point(129, 42);
            this.formatCB.Name = "formatCB";
            this.formatCB.Size = new System.Drawing.Size(45, 17);
            this.formatCB.TabIndex = 13;
            this.formatCB.Text = "Hex";
            this.formatCB.UseVisualStyleBackColor = true;
            this.formatCB.CheckedChanged += new System.EventHandler(this.formatCB_CheckedChanged);
            // 
            // algGB
            // 
            this.algGB.Controls.Add(this.cbcRB);
            this.algGB.Controls.Add(this.ecbRB);
            this.algGB.Location = new System.Drawing.Point(430, 13);
            this.algGB.Name = "algGB";
            this.algGB.Size = new System.Drawing.Size(123, 69);
            this.algGB.TabIndex = 14;
            this.algGB.TabStop = false;
            this.algGB.Text = "Тип алгоритма";
            // 
            // ecbRB
            // 
            this.ecbRB.AutoSize = true;
            this.ecbRB.Checked = true;
            this.ecbRB.Location = new System.Drawing.Point(15, 20);
            this.ecbRB.Name = "ecbRB";
            this.ecbRB.Size = new System.Drawing.Size(46, 17);
            this.ecbRB.TabIndex = 0;
            this.ecbRB.TabStop = true;
            this.ecbRB.Text = "ECB";
            this.ecbRB.UseVisualStyleBackColor = true;
            // 
            // cbcRB
            // 
            this.cbcRB.AutoSize = true;
            this.cbcRB.Location = new System.Drawing.Point(15, 43);
            this.cbcRB.Name = "cbcRB";
            this.cbcRB.Size = new System.Drawing.Size(46, 17);
            this.cbcRB.TabIndex = 1;
            this.cbcRB.Text = "CBC";
            this.cbcRB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 242);
            this.Controls.Add(this.algGB);
            this.Controls.Add(this.formatCB);
            this.Controls.Add(this.dirPB);
            this.Controls.Add(this.genB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GB2);
            this.Controls.Add(this.GB1);
            this.Controls.Add(this.decB);
            this.Controls.Add(this.encB);
            this.Controls.Add(this.kTB);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "DES";
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.GB2.ResumeLayout(false);
            this.GB2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirPB)).EndInit();
            this.algGB.ResumeLayout(false);
            this.algGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB1;
        private System.Windows.Forms.TextBox kTB;
        private System.Windows.Forms.TextBox TB2;
        private System.Windows.Forms.Button encB;
        private System.Windows.Forms.Button decB;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.GroupBox GB2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rlRB;
        private System.Windows.Forms.RadioButton lrRB;
        private System.Windows.Forms.Button genB;
        private System.Windows.Forms.PictureBox dirPB;
        private System.Windows.Forms.CheckBox formatCB;
        private System.Windows.Forms.GroupBox algGB;
        private System.Windows.Forms.RadioButton cbcRB;
        private System.Windows.Forms.RadioButton ecbRB;
    }
}

