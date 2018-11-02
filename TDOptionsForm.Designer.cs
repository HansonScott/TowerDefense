namespace TowerDefense
{
    partial class TDOptionsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nud_HP = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nud_Damage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_BulletSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_Range = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_SplashRadius = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_RateOfFire = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_Seeking = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nud_Chaining = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nud_Slow = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Damage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BulletSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SplashRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RateOfFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seeking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Chaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Slow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "HP";
            // 
            // nud_HP
            // 
            this.nud_HP.DecimalPlaces = 1;
            this.nud_HP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_HP.Location = new System.Drawing.Point(110, 43);
            this.nud_HP.Name = "nud_HP";
            this.nud_HP.Size = new System.Drawing.Size(63, 20);
            this.nud_HP.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(148, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.Location = new System.Drawing.Point(229, 189);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 11;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(310, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nud_Damage
            // 
            this.nud_Damage.DecimalPlaces = 1;
            this.nud_Damage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Damage.Location = new System.Drawing.Point(110, 69);
            this.nud_Damage.Name = "nud_Damage";
            this.nud_Damage.Size = new System.Drawing.Size(63, 20);
            this.nud_Damage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Damage";
            // 
            // nud_BulletSpeed
            // 
            this.nud_BulletSpeed.DecimalPlaces = 1;
            this.nud_BulletSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_BulletSpeed.Location = new System.Drawing.Point(110, 121);
            this.nud_BulletSpeed.Name = "nud_BulletSpeed";
            this.nud_BulletSpeed.Size = new System.Drawing.Size(63, 20);
            this.nud_BulletSpeed.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Bullet Speed";
            // 
            // nud_Range
            // 
            this.nud_Range.DecimalPlaces = 1;
            this.nud_Range.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Range.Location = new System.Drawing.Point(110, 95);
            this.nud_Range.Name = "nud_Range";
            this.nud_Range.Size = new System.Drawing.Size(63, 20);
            this.nud_Range.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Range";
            // 
            // nud_SplashRadius
            // 
            this.nud_SplashRadius.DecimalPlaces = 1;
            this.nud_SplashRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_SplashRadius.Location = new System.Drawing.Point(282, 43);
            this.nud_SplashRadius.Name = "nud_SplashRadius";
            this.nud_SplashRadius.Size = new System.Drawing.Size(63, 20);
            this.nud_SplashRadius.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Splash Radius";
            // 
            // nud_RateOfFire
            // 
            this.nud_RateOfFire.DecimalPlaces = 1;
            this.nud_RateOfFire.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_RateOfFire.Location = new System.Drawing.Point(110, 147);
            this.nud_RateOfFire.Name = "nud_RateOfFire";
            this.nud_RateOfFire.Size = new System.Drawing.Size(63, 20);
            this.nud_RateOfFire.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Rate of Fire";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "New Tower Creation Price";
            // 
            // nud_Seeking
            // 
            this.nud_Seeking.DecimalPlaces = 1;
            this.nud_Seeking.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Seeking.Location = new System.Drawing.Point(282, 69);
            this.nud_Seeking.Name = "nud_Seeking";
            this.nud_Seeking.Size = new System.Drawing.Size(63, 20);
            this.nud_Seeking.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "Seeking";
            // 
            // nud_Chaining
            // 
            this.nud_Chaining.DecimalPlaces = 1;
            this.nud_Chaining.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Chaining.Location = new System.Drawing.Point(282, 121);
            this.nud_Chaining.Name = "nud_Chaining";
            this.nud_Chaining.Size = new System.Drawing.Size(63, 20);
            this.nud_Chaining.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Chaining";
            // 
            // nud_Slow
            // 
            this.nud_Slow.DecimalPlaces = 1;
            this.nud_Slow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Slow.Location = new System.Drawing.Point(282, 95);
            this.nud_Slow.Name = "nud_Slow";
            this.nud_Slow.Size = new System.Drawing.Size(63, 20);
            this.nud_Slow.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Slow";
            // 
            // TDOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 224);
            this.Controls.Add(this.nud_Chaining);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nud_Slow);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nud_Seeking);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_SplashRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_RateOfFire);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nud_BulletSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_Range);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_Damage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nud_HP);
            this.Controls.Add(this.label1);
            this.Name = "TDOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Defense Options";
            ((System.ComponentModel.ISupportInitialize)(this.nud_HP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Damage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BulletSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SplashRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RateOfFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seeking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Chaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Slow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_HP;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nud_Damage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_BulletSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_Range;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_SplashRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_RateOfFire;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_Seeking;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nud_Chaining;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nud_Slow;
        private System.Windows.Forms.Label label10;
    }
}