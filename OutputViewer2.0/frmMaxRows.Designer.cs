namespace OutputViewer2._0
{
    partial class frmMaxRows
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
            btnSubmit = new Button();
            btnCancel = new Button();
            txtMax = new TextBox();
            frmMax = new Label();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(56, 123);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(170, 123);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtMax
            // 
            txtMax.Location = new Point(103, 70);
            txtMax.Name = "txtMax";
            txtMax.Size = new Size(100, 23);
            txtMax.TabIndex = 2;
            // 
            // frmMax
            // 
            frmMax.AutoSize = true;
            frmMax.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            frmMax.Location = new Point(37, 30);
            frmMax.Name = "frmMax";
            frmMax.Size = new Size(237, 21);
            frmMax.TabIndex = 3;
            frmMax.Text = "Set Maximum Number of Rows";
            // 
            // frmMaxRows
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 192);
            Controls.Add(frmMax);
            Controls.Add(txtMax);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Name = "frmMaxRows";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Maximum Rows";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private Button btnCancel;
        private TextBox txtMax;
        private Label frmMax;
    }
}