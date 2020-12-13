namespace 动态壁纸
{
    partial class FormBackGround
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
            this.components = new System.ComponentModel.Container();
            this.BackGroundVideoTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BackGroundVideoTimer
            // 
            this.BackGroundVideoTimer.Tick += new System.EventHandler(this.BackGroundVideoTimer_Tick);
            // 
            // FormBackGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::动态壁纸.Properties.Resources.G_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(528, 342);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBackGround";
            this.Text = "背景";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBackGround_FormClosing);
            this.Load += new System.EventHandler(this.FormBackGround_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer BackGroundVideoTimer;
    }
}