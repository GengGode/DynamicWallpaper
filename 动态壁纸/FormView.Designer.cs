namespace 动态壁纸
{
    partial class FormView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.panelView = new System.Windows.Forms.Panel();
            this.buttonBackGround = new System.Windows.Forms.Button();
            this.buttonOpenFileView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelView.Location = new System.Drawing.Point(12, 12);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(451, 258);
            this.panelView.TabIndex = 0;
            // 
            // buttonBackGround
            // 
            this.buttonBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackGround.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBackGround.Location = new System.Drawing.Point(388, 281);
            this.buttonBackGround.Name = "buttonBackGround";
            this.buttonBackGround.Size = new System.Drawing.Size(75, 23);
            this.buttonBackGround.TabIndex = 1;
            this.buttonBackGround.Text = "Install";
            this.buttonBackGround.UseVisualStyleBackColor = true;
            this.buttonBackGround.Click += new System.EventHandler(this.buttonBackGround_Click);
            // 
            // buttonOpenFileView
            // 
            this.buttonOpenFileView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFileView.Location = new System.Drawing.Point(307, 281);
            this.buttonOpenFileView.Name = "buttonOpenFileView";
            this.buttonOpenFileView.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFileView.TabIndex = 2;
            this.buttonOpenFileView.Text = "OpenFile";
            this.buttonOpenFileView.UseVisualStyleBackColor = true;
            this.buttonOpenFileView.Click += new System.EventHandler(this.buttonOpenFileView_Click);
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 316);
            this.Controls.Add(this.buttonOpenFileView);
            this.Controls.Add(this.buttonBackGround);
            this.Controls.Add(this.panelView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormView";
            this.Text = "FormView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button buttonBackGround;
        private System.Windows.Forms.Button buttonOpenFileView;
    }
}