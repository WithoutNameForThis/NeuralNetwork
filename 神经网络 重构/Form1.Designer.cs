namespace 神经网络
{
    partial class frm_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.img_input = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_train = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_reg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_dec = new System.Windows.Forms.TextBox();
            this.text_rate = new System.Windows.Forms.TextBox();
            this.text_time = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.pro_pro = new System.Windows.Forms.ProgressBar();
            this.tim_keeper = new System.Windows.Forms.Timer(this.components);
            this.list_acc = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_reg_plus = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_error = new System.Windows.Forms.Button();
            this.btn_error_train = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img_input)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // img_input
            // 
            this.img_input.BackColor = System.Drawing.Color.White;
            this.img_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_input.Location = new System.Drawing.Point(12, 12);
            this.img_input.Name = "img_input";
            this.img_input.Size = new System.Drawing.Size(840, 840);
            this.img_input.TabIndex = 1;
            this.img_input.TabStop = false;
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_clear.Location = new System.Drawing.Point(778, 12);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(74, 32);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "清除";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_train
            // 
            this.btn_train.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_train.Location = new System.Drawing.Point(858, 187);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(97, 80);
            this.btn_train.TabIndex = 3;
            this.btn_train.Text = "训练";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_test.Location = new System.Drawing.Point(858, 273);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(97, 80);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "测试";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_reg
            // 
            this.btn_reg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reg.Location = new System.Drawing.Point(858, 12);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(97, 80);
            this.btn_reg.TabIndex = 3;
            this.btn_reg.Text = "识别";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(856, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "递除";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(856, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "训练";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(856, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 39;
            this.label2.Text = "次数";
            // 
            // text_dec
            // 
            this.text_dec.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_dec.Location = new System.Drawing.Point(891, 152);
            this.text_dec.Name = "text_dec";
            this.text_dec.Size = new System.Drawing.Size(64, 29);
            this.text_dec.TabIndex = 34;
            this.text_dec.Text = "1.41";
            this.text_dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_rate
            // 
            this.text_rate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_rate.Location = new System.Drawing.Point(891, 125);
            this.text_rate.Name = "text_rate";
            this.text_rate.Size = new System.Drawing.Size(64, 29);
            this.text_rate.TabIndex = 35;
            this.text_rate.Text = "0.1";
            this.text_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_time
            // 
            this.text_time.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_time.Location = new System.Drawing.Point(891, 98);
            this.text_time.Name = "text_time";
            this.text_time.Size = new System.Drawing.Size(64, 29);
            this.text_time.TabIndex = 36;
            this.text_time.Text = "10";
            this.text_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_load.Location = new System.Drawing.Point(858, 359);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(97, 80);
            this.btn_load.TabIndex = 40;
            this.btn_load.Text = "读取";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.Location = new System.Drawing.Point(858, 445);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(97, 80);
            this.btn_save.TabIndex = 41;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // pro_pro
            // 
            this.pro_pro.Location = new System.Drawing.Point(12, -1);
            this.pro_pro.Name = "pro_pro";
            this.pro_pro.Size = new System.Drawing.Size(840, 23);
            this.pro_pro.TabIndex = 42;
            this.pro_pro.Click += new System.EventHandler(this.pro_pro_Click);
            // 
            // tim_keeper
            // 
            this.tim_keeper.Tick += new System.EventHandler(this.tim_keeper_Tick);
            // 
            // list_acc
            // 
            this.list_acc.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_acc.FormattingEnabled = true;
            this.list_acc.ItemHeight = 25;
            this.list_acc.Location = new System.Drawing.Point(6, 20);
            this.list_acc.Name = "list_acc";
            this.list_acc.Size = new System.Drawing.Size(94, 479);
            this.list_acc.TabIndex = 43;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_acc);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(958, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 513);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "每轮准确度";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_add.Location = new System.Drawing.Point(858, 531);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(97, 80);
            this.btn_add.TabIndex = 45;
            this.btn_add.Text = "添加一层10节点神经网络";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_reg_plus
            // 
            this.btn_reg_plus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reg_plus.Location = new System.Drawing.Point(1064, 12);
            this.btn_reg_plus.Name = "btn_reg_plus";
            this.btn_reg_plus.Size = new System.Drawing.Size(97, 80);
            this.btn_reg_plus.TabIndex = 46;
            this.btn_reg_plus.Text = "识别++";
            this.btn_reg_plus.UseVisualStyleBackColor = true;
            this.btn_reg_plus.Click += new System.EventHandler(this.btn_reg_plus_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(1069, 101);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(367, 508);
            this.listBox1.TabIndex = 47;
            // 
            // btn_error
            // 
            this.btn_error.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_error.Location = new System.Drawing.Point(858, 617);
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(97, 80);
            this.btn_error.TabIndex = 48;
            this.btn_error.Text = "测试(测试集中错误)";
            this.btn_error.UseVisualStyleBackColor = true;
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_error_train
            // 
            this.btn_error_train.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_error_train.Location = new System.Drawing.Point(858, 703);
            this.btn_error_train.Name = "btn_error_train";
            this.btn_error_train.Size = new System.Drawing.Size(97, 80);
            this.btn_error_train.TabIndex = 48;
            this.btn_error_train.Text = "测试(訓練集中错误)";
            this.btn_error_train.UseVisualStyleBackColor = true;
            this.btn_error_train.Click += new System.EventHandler(this.btn_error_train_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 858);
            this.Controls.Add(this.btn_error_train);
            this.Controls.Add(this.btn_error);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_reg_plus);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.text_dec);
            this.Controls.Add(this.text_rate);
            this.Controls.Add(this.text_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.btn_train);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.img_input);
            this.Controls.Add(this.pro_pro);
            this.Name = "frm_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_input)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_input;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_dec;
        private System.Windows.Forms.TextBox text_rate;
        private System.Windows.Forms.TextBox text_time;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ProgressBar pro_pro;
        private System.Windows.Forms.Timer tim_keeper;
        private System.Windows.Forms.ListBox list_acc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_reg_plus;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_error;
        private System.Windows.Forms.Button btn_error_train;
    }
}

