namespace OutputViewer2._0
{
    partial class frmViewer
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvSawOutput = new DataGridView();
            panel2 = new Panel();
            btnResetBoardFeet = new Button();
            brnResetPartCount = new Button();
            lblBoardFeet = new Label();
            label2 = new Label();
            lblDailyPartCount = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            tsmSetFilePath = new ToolStripMenuItem();
            tsmChangeFont = new ToolStripMenuItem();
            tsmMaxRows = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            fontDialog1 = new FontDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSawOutput).BeginInit();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvSawOutput);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1393, 806);
            panel1.TabIndex = 0;
            // 
            // dgvSawOutput
            // 
            dgvSawOutput.AllowUserToAddRows = false;
            dgvSawOutput.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvSawOutput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSawOutput.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSawOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSawOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSawOutput.Dock = DockStyle.Fill;
            dgvSawOutput.Location = new Point(0, 0);
            dgvSawOutput.MultiSelect = false;
            dgvSawOutput.Name = "dgvSawOutput";
            dgvSawOutput.ReadOnly = true;
            dgvSawOutput.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSawOutput.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvSawOutput.RowTemplate.Height = 25;
            dgvSawOutput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSawOutput.ShowCellToolTips = false;
            dgvSawOutput.Size = new Size(1393, 806);
            dgvSawOutput.TabIndex = 0;
            dgvSawOutput.DataBindingComplete += dgvSawOutput_DataBindingComplete;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnResetBoardFeet);
            panel2.Controls.Add(brnResetPartCount);
            panel2.Controls.Add(lblBoardFeet);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblDailyPartCount);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 730);
            panel2.Name = "panel2";
            panel2.Size = new Size(1393, 100);
            panel2.TabIndex = 0;
            // 
            // btnResetBoardFeet
            // 
            btnResetBoardFeet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetBoardFeet.Location = new Point(28, 55);
            btnResetBoardFeet.Name = "btnResetBoardFeet";
            btnResetBoardFeet.Size = new Size(116, 36);
            btnResetBoardFeet.TabIndex = 5;
            btnResetBoardFeet.Text = "Reset Feet";
            btnResetBoardFeet.UseVisualStyleBackColor = true;
            btnResetBoardFeet.Click += btnResetBoardFeet_Click;
            // 
            // brnResetPartCount
            // 
            brnResetPartCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            brnResetPartCount.Location = new Point(28, 10);
            brnResetPartCount.Name = "brnResetPartCount";
            brnResetPartCount.Size = new Size(116, 39);
            brnResetPartCount.TabIndex = 4;
            brnResetPartCount.Text = "Reset Count";
            brnResetPartCount.UseVisualStyleBackColor = true;
            brnResetPartCount.Click += brnResetPartCount_Click;
            // 
            // lblBoardFeet
            // 
            lblBoardFeet.AutoSize = true;
            lblBoardFeet.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBoardFeet.Location = new Point(269, 59);
            lblBoardFeet.Name = "lblBoardFeet";
            lblBoardFeet.Size = new Size(0, 21);
            lblBoardFeet.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(155, 59);
            label2.Name = "label2";
            label2.Size = new Size(98, 21);
            label2.TabIndex = 2;
            label2.Text = "Board Feet: ";
            // 
            // lblDailyPartCount
            // 
            lblDailyPartCount.AutoSize = true;
            lblDailyPartCount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDailyPartCount.Location = new Point(269, 19);
            lblDailyPartCount.Name = "lblDailyPartCount";
            lblDailyPartCount.Size = new Size(0, 21);
            lblDailyPartCount.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(162, 19);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 0;
            label1.Text = "Part Count:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1393, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmSetFilePath, tsmChangeFont, tsmMaxRows, tsmExit });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // tsmSetFilePath
            // 
            tsmSetFilePath.Name = "tsmSetFilePath";
            tsmSetFilePath.Size = new Size(142, 22);
            tsmSetFilePath.Text = "Set File Path";
            tsmSetFilePath.Click += tsmSetFilePath_Click;
            // 
            // tsmChangeFont
            // 
            tsmChangeFont.Name = "tsmChangeFont";
            tsmChangeFont.Size = new Size(142, 22);
            tsmChangeFont.Text = "Change Font";
            tsmChangeFont.Click += tsmChangeFont_Click;
            // 
            // tsmMaxRows
            // 
            tsmMaxRows.Name = "tsmMaxRows";
            tsmMaxRows.Size = new Size(142, 22);
            tsmMaxRows.Text = "Max Rows";
            tsmMaxRows.Click += maxRowsToolStripMenuItem_Click;
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(142, 22);
            tsmExit.Text = "Exit";
            tsmExit.Click += tsmExit_Click;
            // 
            // frmViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 830);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "frmViewer";
            StartPosition = FormStartPosition.Manual;
            Text = "Viewer";
            FormClosing += frmViewer_FormClosing;
            Load += frmViewer_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSawOutput).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvSawOutput;
        private Panel panel2;
        private Label lblBoardFeet;
        private Label label2;
        private Label lblDailyPartCount;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem tsmSetFilePath;
        private ToolStripMenuItem tsmChangeFont;
        private ToolStripMenuItem tsmExit;
        private ToolStripMenuItem tsmMaxRows;
        private FontDialog fontDialog1;
        private Button btnResetBoardFeet;
        private Button brnResetPartCount;
    }
}