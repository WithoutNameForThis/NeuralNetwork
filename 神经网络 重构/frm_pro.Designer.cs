namespace 神经网络
{
    partial class frm_pro
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
            this.pro_pro = new System.Windows.Forms.ProgressBar();
            this.tim_keeper = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pro_pro
            // 
            this.pro_pro.Location = new System.Drawing.Point(12, 12);
            this.pro_pro.Name = "pro_pro";
            this.pro_pro.Size = new System.Drawing.Size(412, 23);
            this.pro_pro.TabIndex = 0;
            // 
            // tim_keeper
            // 
            this.tim_keeper.Tick += new System.EventHandler(this.tim_keeper_Tick);
            // 
            // frm_pro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 96);
            this.Controls.Add(this.pro_pro);
            this.Name = "frm_pro";
            this.Text = "frm_pro";
            this.Load += new System.EventHandler(this.frm_pro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pro_pro;
        private System.Windows.Forms.Timer tim_keeper;
    }
}