namespace Graphing_Demo
{
    partial class GraphControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button Last30Days;
            System.Windows.Forms.Button button1;
            System.Windows.Forms.Button button2;
            this.labelMinX = new System.Windows.Forms.Label();
            this.textBoxMinX = new System.Windows.Forms.TextBox();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.labelMaxX = new System.Windows.Forms.Label();
            this.textBoxMaxY = new System.Windows.Forms.TextBox();
            this.labelMaxY = new System.Windows.Forms.Label();
            this.textBoxMinY = new System.Windows.Forms.TextBox();
            this.labelMinY = new System.Windows.Forms.Label();
            this.checkBoxGridLines = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.numericUpDownGraphPenWidth = new System.Windows.Forms.NumericUpDown();
            this.labelGraphPenWidth = new System.Windows.Forms.Label();
            this.buttonGetFile = new System.Windows.Forms.Button();
            this.maxDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.minDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drawOption1 = new System.Windows.Forms.RadioButton();
            this.drawOption2 = new System.Windows.Forms.RadioButton();
            this.drawOption3 = new System.Windows.Forms.RadioButton();
            this.movingAverageBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.averageC = new System.Windows.Forms.RadioButton();
            this.average30 = new System.Windows.Forms.RadioButton();
            this.average10 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.averageDayCustom = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.quickBack = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            Last30Days = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphPenWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Last30Days
            // 
            Last30Days.Location = new System.Drawing.Point(408, 51);
            Last30Days.Name = "Last30Days";
            Last30Days.Size = new System.Drawing.Size(84, 37);
            Last30Days.TabIndex = 24;
            Last30Days.Text = "Last 30\r\nWorking Days";
            Last30Days.UseVisualStyleBackColor = true;
            Last30Days.Click += new System.EventHandler(this.Last30Days_Click);
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(408, 6);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(85, 37);
            button1.TabIndex = 26;
            button1.Text = "Last 10\r\nWorking Days";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(408, 94);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(84, 37);
            button2.TabIndex = 27;
            button2.Text = "Last 120\r\nWorking Days";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelMinX
            // 
            this.labelMinX.AutoSize = true;
            this.labelMinX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinX.Location = new System.Drawing.Point(11, 288);
            this.labelMinX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMinX.Name = "labelMinX";
            this.labelMinX.Size = new System.Drawing.Size(49, 20);
            this.labelMinX.TabIndex = 1;
            this.labelMinX.Text = "Min X";
            // 
            // textBoxMinX
            // 
            this.textBoxMinX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinX.Location = new System.Drawing.Point(64, 285);
            this.textBoxMinX.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMinX.Name = "textBoxMinX";
            this.textBoxMinX.Size = new System.Drawing.Size(46, 26);
            this.textBoxMinX.TabIndex = 2;
            this.textBoxMinX.Text = "0";
            this.textBoxMinX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxX.Location = new System.Drawing.Point(64, 298);
            this.textBoxMaxX.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(46, 26);
            this.textBoxMaxX.TabIndex = 4;
            this.textBoxMaxX.Text = "60";
            this.textBoxMaxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMaxX
            // 
            this.labelMaxX.AutoSize = true;
            this.labelMaxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxX.Location = new System.Drawing.Point(7, 311);
            this.labelMaxX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxX.Name = "labelMaxX";
            this.labelMaxX.Size = new System.Drawing.Size(53, 20);
            this.labelMaxX.TabIndex = 3;
            this.labelMaxX.Text = "Max X";
            // 
            // textBoxMaxY
            // 
            this.textBoxMaxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaxY.Location = new System.Drawing.Point(85, 8);
            this.textBoxMaxY.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMaxY.Name = "textBoxMaxY";
            this.textBoxMaxY.Size = new System.Drawing.Size(76, 26);
            this.textBoxMaxY.TabIndex = 6;
            this.textBoxMaxY.Text = "370";
            this.textBoxMaxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMaxY.TextChanged += new System.EventHandler(this.textBoxMaxY_TextChanged);
            // 
            // labelMaxY
            // 
            this.labelMaxY.AutoSize = true;
            this.labelMaxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxY.Location = new System.Drawing.Point(7, 11);
            this.labelMaxY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxY.Name = "labelMaxY";
            this.labelMaxY.Size = new System.Drawing.Size(77, 20);
            this.labelMaxY.TabIndex = 5;
            this.labelMaxY.Text = "Max Price";
            // 
            // textBoxMinY
            // 
            this.textBoxMinY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMinY.Location = new System.Drawing.Point(85, 51);
            this.textBoxMinY.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMinY.Name = "textBoxMinY";
            this.textBoxMinY.Size = new System.Drawing.Size(76, 26);
            this.textBoxMinY.TabIndex = 8;
            this.textBoxMinY.Text = "0";
            this.textBoxMinY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMinY
            // 
            this.labelMinY.AutoSize = true;
            this.labelMinY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinY.Location = new System.Drawing.Point(7, 46);
            this.labelMinY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMinY.Name = "labelMinY";
            this.labelMinY.Size = new System.Drawing.Size(72, 40);
            this.labelMinY.TabIndex = 7;
            this.labelMinY.Text = "Minimum\r\nPrice";
            this.labelMinY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBoxGridLines
            // 
            this.checkBoxGridLines.AutoSize = true;
            this.checkBoxGridLines.Checked = true;
            this.checkBoxGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGridLines.Location = new System.Drawing.Point(394, 315);
            this.checkBoxGridLines.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGridLines.Name = "checkBoxGridLines";
            this.checkBoxGridLines.Size = new System.Drawing.Size(103, 17);
            this.checkBoxGridLines.TabIndex = 9;
            this.checkBoxGridLines.Text = "Show Grid Lines";
            this.checkBoxGridLines.UseVisualStyleBackColor = true;
            this.checkBoxGridLines.CheckedChanged += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(11, 94);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(140, 56);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "Update\r\nDisplayed Price";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.invalidaateGraphForm);
            // 
            // numericUpDownGraphPenWidth
            // 
            this.numericUpDownGraphPenWidth.CausesValidation = false;
            this.numericUpDownGraphPenWidth.DecimalPlaces = 1;
            this.numericUpDownGraphPenWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGraphPenWidth.Location = new System.Drawing.Point(15, 298);
            this.numericUpDownGraphPenWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownGraphPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGraphPenWidth.Name = "numericUpDownGraphPenWidth";
            this.numericUpDownGraphPenWidth.Size = new System.Drawing.Size(98, 20);
            this.numericUpDownGraphPenWidth.TabIndex = 13;
            this.numericUpDownGraphPenWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownGraphPenWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownGraphPenWidth.Visible = false;
            // 
            // labelGraphPenWidth
            // 
            this.labelGraphPenWidth.AutoSize = true;
            this.labelGraphPenWidth.Location = new System.Drawing.Point(21, 275);
            this.labelGraphPenWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGraphPenWidth.Name = "labelGraphPenWidth";
            this.labelGraphPenWidth.Size = new System.Drawing.Size(89, 13);
            this.labelGraphPenWidth.TabIndex = 14;
            this.labelGraphPenWidth.Text = "Graph Pen Width";
            this.labelGraphPenWidth.Visible = false;
            // 
            // buttonGetFile
            // 
            this.buttonGetFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetFile.Location = new System.Drawing.Point(6, 265);
            this.buttonGetFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGetFile.Name = "buttonGetFile";
            this.buttonGetFile.Size = new System.Drawing.Size(122, 66);
            this.buttonGetFile.TabIndex = 16;
            this.buttonGetFile.Text = "Load File";
            this.buttonGetFile.UseVisualStyleBackColor = true;
            this.buttonGetFile.Click += new System.EventHandler(this.buttonGetFile_Click);
            // 
            // maxDateTimePicker
            // 
            this.maxDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.maxDateTimePicker.ImeMode = System.Windows.Forms.ImeMode.On;
            this.maxDateTimePicker.Location = new System.Drawing.Point(289, 46);
            this.maxDateTimePicker.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.maxDateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.maxDateTimePicker.Name = "maxDateTimePicker";
            this.maxDateTimePicker.Size = new System.Drawing.Size(87, 20);
            this.maxDateTimePicker.TabIndex = 17;
            this.maxDateTimePicker.ValueChanged += new System.EventHandler(this.maxDateTimePicker_ValueChanged);
            // 
            // minDateTimePicker1
            // 
            this.minDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.minDateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.minDateTimePicker1.Location = new System.Drawing.Point(289, 12);
            this.minDateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.minDateTimePicker1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.minDateTimePicker1.Name = "minDateTimePicker1";
            this.minDateTimePicker1.Size = new System.Drawing.Size(87, 20);
            this.minDateTimePicker1.TabIndex = 18;
            this.minDateTimePicker1.ValueChanged += new System.EventHandler(this.minDateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Start Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "End Date";
            // 
            // drawOption1
            // 
            this.drawOption1.AutoSize = true;
            this.drawOption1.Checked = true;
            this.drawOption1.Location = new System.Drawing.Point(6, 8);
            this.drawOption1.Name = "drawOption1";
            this.drawOption1.Size = new System.Drawing.Size(85, 17);
            this.drawOption1.TabIndex = 21;
            this.drawOption1.TabStop = true;
            this.drawOption1.Text = "Candle Stick";
            this.drawOption1.UseVisualStyleBackColor = true;
            this.drawOption1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // drawOption2
            // 
            this.drawOption2.AutoSize = true;
            this.drawOption2.Location = new System.Drawing.Point(6, 31);
            this.drawOption2.Name = "drawOption2";
            this.drawOption2.Size = new System.Drawing.Size(121, 17);
            this.drawOption2.TabIndex = 22;
            this.drawOption2.Text = "Open-high-low-close";
            this.drawOption2.UseVisualStyleBackColor = true;
            this.drawOption2.CheckedChanged += new System.EventHandler(this.drawOption2_CheckedChanged);
            // 
            // drawOption3
            // 
            this.drawOption3.AutoSize = true;
            this.drawOption3.Location = new System.Drawing.Point(6, 54);
            this.drawOption3.Name = "drawOption3";
            this.drawOption3.Size = new System.Drawing.Size(73, 17);
            this.drawOption3.TabIndex = 23;
            this.drawOption3.Text = "Just Close";
            this.drawOption3.UseVisualStyleBackColor = true;
            this.drawOption3.CheckedChanged += new System.EventHandler(this.drawOption3_CheckedChanged);
            // 
            // movingAverageBox
            // 
            this.movingAverageBox.AutoSize = true;
            this.movingAverageBox.Location = new System.Drawing.Point(204, 305);
            this.movingAverageBox.Name = "movingAverageBox";
            this.movingAverageBox.Size = new System.Drawing.Size(134, 17);
            this.movingAverageBox.TabIndex = 25;
            this.movingAverageBox.Text = "Show Moving Average";
            this.movingAverageBox.UseVisualStyleBackColor = true;
            this.movingAverageBox.CheckedChanged += new System.EventHandler(this.movingAverageBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Graph Display Type";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // averageC
            // 
            this.averageC.AutoSize = true;
            this.averageC.Location = new System.Drawing.Point(0, 44);
            this.averageC.Name = "averageC";
            this.averageC.Size = new System.Drawing.Size(103, 17);
            this.averageC.TabIndex = 29;
            this.averageC.Text = "Custom Average";
            this.averageC.UseVisualStyleBackColor = true;
            this.averageC.CheckedChanged += new System.EventHandler(this.averageC_CheckedChanged);
            // 
            // average30
            // 
            this.average30.AutoSize = true;
            this.average30.Location = new System.Drawing.Point(0, 27);
            this.average30.Name = "average30";
            this.average30.Size = new System.Drawing.Size(102, 17);
            this.average30.TabIndex = 30;
            this.average30.Text = "30 Day Average";
            this.average30.UseVisualStyleBackColor = true;
            this.average30.CheckedChanged += new System.EventHandler(this.average30_CheckedChanged);
            // 
            // average10
            // 
            this.average10.AutoSize = true;
            this.average10.Checked = true;
            this.average10.Location = new System.Drawing.Point(0, 10);
            this.average10.Name = "average10";
            this.average10.Size = new System.Drawing.Size(102, 17);
            this.average10.TabIndex = 31;
            this.average10.TabStop = true;
            this.average10.Text = "10 Day Average";
            this.average10.UseVisualStyleBackColor = true;
            this.average10.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drawOption1);
            this.groupBox1.Controls.Add(this.drawOption2);
            this.groupBox1.Controls.Add(this.drawOption3);
            this.groupBox1.Location = new System.Drawing.Point(14, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.averageDayCustom);
            this.groupBox2.Controls.Add(this.averageC);
            this.groupBox2.Controls.Add(this.average30);
            this.groupBox2.Controls.Add(this.average10);
            this.groupBox2.Location = new System.Drawing.Point(204, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 69);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // averageDayCustom
            // 
            this.averageDayCustom.Location = new System.Drawing.Point(118, 41);
            this.averageDayCustom.Name = "averageDayCustom";
            this.averageDayCustom.Size = new System.Drawing.Size(39, 20);
            this.averageDayCustom.TabIndex = 32;
            this.averageDayCustom.Text = "60";
            this.averageDayCustom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 56);
            this.button3.TabIndex = 33;
            this.button3.Text = "Auto Adjust\r\nDisplayed Price";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // quickBack
            // 
            this.quickBack.Location = new System.Drawing.Point(289, 72);
            this.quickBack.Name = "quickBack";
            this.quickBack.Size = new System.Drawing.Size(87, 40);
            this.quickBack.TabIndex = 34;
            this.quickBack.Text = "Back 30\r\nBusiness days";
            this.quickBack.UseVisualStyleBackColor = true;
            this.quickBack.Click += new System.EventHandler(this.quickBack_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(289, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 39);
            this.button5.TabIndex = 35;
            this.button5.Text = "Forward 30 \r\nBusiness days";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GraphControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 340);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.quickBack);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(button2);
            this.Controls.Add(button1);
            this.Controls.Add(this.movingAverageBox);
            this.Controls.Add(Last30Days);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minDateTimePicker1);
            this.Controls.Add(this.maxDateTimePicker);
            this.Controls.Add(this.buttonGetFile);
            this.Controls.Add(this.labelGraphPenWidth);
            this.Controls.Add(this.numericUpDownGraphPenWidth);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.checkBoxGridLines);
            this.Controls.Add(this.textBoxMinY);
            this.Controls.Add(this.labelMinY);
            this.Controls.Add(this.textBoxMaxY);
            this.Controls.Add(this.labelMaxY);
            this.Controls.Add(this.textBoxMaxX);
            this.Controls.Add(this.labelMaxX);
            this.Controls.Add(this.textBoxMinX);
            this.Controls.Add(this.labelMinX);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Location = new System.Drawing.Point(750, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphControlForm";
            this.Text = "Control Form";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphControlForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphPenWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMinX;
        private System.Windows.Forms.TextBox textBoxMinX;
        private System.Windows.Forms.TextBox textBoxMaxX;
        private System.Windows.Forms.Label labelMaxX;
        private System.Windows.Forms.TextBox textBoxMaxY;
        private System.Windows.Forms.Label labelMaxY;
        private System.Windows.Forms.TextBox textBoxMinY;
        private System.Windows.Forms.Label labelMinY;
        private System.Windows.Forms.CheckBox checkBoxGridLines;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NumericUpDown numericUpDownGraphPenWidth;
        private System.Windows.Forms.Label labelGraphPenWidth;
        private System.Windows.Forms.Button buttonGetFile;
        private System.Windows.Forms.DateTimePicker maxDateTimePicker;
        private System.Windows.Forms.DateTimePicker minDateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton drawOption1;
        private System.Windows.Forms.RadioButton drawOption2;
        private System.Windows.Forms.RadioButton drawOption3;
        private System.Windows.Forms.CheckBox movingAverageBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton averageC;
        private System.Windows.Forms.RadioButton average30;
        private System.Windows.Forms.RadioButton average10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox averageDayCustom;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button quickBack;
        private System.Windows.Forms.Button button5;

    }
}