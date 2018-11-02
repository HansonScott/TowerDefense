using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDefense
{
    public class TDTowerCreator: Form
    {
        int totalCost = 1;

        #region UI Controls
        private Button btnCancel;
        private Button btnCreate;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private NumericUpDown nudDamage;
        private NumericUpDown nudHP;
        private Label label3;
        private NumericUpDown nudRange;
        private Label label4;
        private NumericUpDown nudBulletSpeed;
        private Label label5;
        private NumericUpDown nudFireRate;
        private Label label6;
        private Label label7;
        private Label lblCost;
        private NumericUpDown nud_SplashRadius;
        private Label label8;
        private NumericUpDown nudSlowTime;
        private Label label10;
        private NumericUpDown nudSlowPercentage;
        private Label label11;
        private CheckBox chk_Seeking;

        private Label label9;
        private ComboBox cb_Premades;
        #endregion

        #region Cost Multipliers
        public static decimal CostMultiplier_BulletSpeed = 0.2M;
        public static decimal CostMultiplier_Damage = 2.0M;
        public static decimal CostMultiplier_FireRate = 1.1M;
        public static decimal CostMultiplier_HP = 0.1M;
        public static decimal CostMultiplier_Range = 0.3M;
        public static decimal CostMultiplier_SplashRadius = 2.0M;
        public static decimal CostMultiplier_Seeking = 2.0M;
        public static decimal CostMultiplier_Slow = 0.5M;
        public static decimal CostMultiplier_Chaining = 0.5M;
        #endregion
        private NumericUpDown nud_ChainDist;
        private Label label12;
        private NumericUpDown nud_ChainCount;
        private Label label13;

        public TDTower Tower = null;

        #region Constructor and Setup
        public TDTowerCreator()
        {
            InitializeComponent();
            CalculateCost();
            PopulatePremadesCombo();
        }

        private void PopulatePremadesCombo()
        {
            cb_Premades.Items.Add(PremadeTowerSettings.BasicTurret);
            cb_Premades.Items.Add(PremadeTowerSettings.ScoutTurret);
            cb_Premades.Items.Add(PremadeTowerSettings.BasicCannon);
            cb_Premades.Items.Add(PremadeTowerSettings.Mortar);
            cb_Premades.Items.Add(PremadeTowerSettings.MissleTurret);
            cb_Premades.Items.Add(PremadeTowerSettings.SlowTurret);
            cb_Premades.Items.Add(PremadeTowerSettings.ChainTurret);
        }
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDamage = new System.Windows.Forms.NumericUpDown();
            this.nudHP = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRange = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBulletSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudFireRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.nud_SplashRadius = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.chk_Seeking = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_Premades = new System.Windows.Forms.ComboBox();
            this.nudSlowTime = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudSlowPercentage = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nud_ChainDist = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nud_ChainCount = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBulletSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFireRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SplashRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChainDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChainCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(218, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(142, 266);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Tower Name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Tower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Damage";
            // 
            // nudDamage
            // 
            this.nudDamage.Location = new System.Drawing.Point(89, 79);
            this.nudDamage.Name = "nudDamage";
            this.nudDamage.Size = new System.Drawing.Size(58, 20);
            this.nudDamage.TabIndex = 3;
            this.nudDamage.ThousandsSeparator = true;
            this.nudDamage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDamage.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nudHP
            // 
            this.nudHP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHP.Location = new System.Drawing.Point(89, 53);
            this.nudHP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHP.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudHP.Name = "nudHP";
            this.nudHP.Size = new System.Drawing.Size(58, 20);
            this.nudHP.TabIndex = 2;
            this.nudHP.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudHP.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "HP";
            // 
            // nudRange
            // 
            this.nudRange.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRange.Location = new System.Drawing.Point(89, 105);
            this.nudRange.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRange.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(58, 20);
            this.nudRange.TabIndex = 4;
            this.nudRange.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudRange.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Range";
            // 
            // nudBulletSpeed
            // 
            this.nudBulletSpeed.Location = new System.Drawing.Point(89, 159);
            this.nudBulletSpeed.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudBulletSpeed.Name = "nudBulletSpeed";
            this.nudBulletSpeed.Size = new System.Drawing.Size(58, 20);
            this.nudBulletSpeed.TabIndex = 6;
            this.nudBulletSpeed.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudBulletSpeed.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Bullet Speed";
            // 
            // nudFireRate
            // 
            this.nudFireRate.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFireRate.Location = new System.Drawing.Point(89, 187);
            this.nudFireRate.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFireRate.Name = "nudFireRate";
            this.nudFireRate.Size = new System.Drawing.Size(58, 20);
            this.nudFireRate.TabIndex = 7;
            this.nudFireRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFireRate.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Fire Rate";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Prototype Cost:";
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(191, 215);
            this.lblCost.Name = "lblCost";
            this.lblCost.Padding = new System.Windows.Forms.Padding(2);
            this.lblCost.Size = new System.Drawing.Size(76, 31);
            this.lblCost.TabIndex = 99;
            this.lblCost.Text = "0";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nud_SplashRadius
            // 
            this.nud_SplashRadius.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_SplashRadius.Location = new System.Drawing.Point(89, 131);
            this.nud_SplashRadius.Name = "nud_SplashRadius";
            this.nud_SplashRadius.Size = new System.Drawing.Size(58, 20);
            this.nud_SplashRadius.TabIndex = 5;
            this.nud_SplashRadius.ValueChanged += new System.EventHandler(this.nud_SplashRadius_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "Splash Radius";
            // 
            // chk_Seeking
            // 
            this.chk_Seeking.AutoSize = true;
            this.chk_Seeking.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_Seeking.Location = new System.Drawing.Point(180, 166);
            this.chk_Seeking.Name = "chk_Seeking";
            this.chk_Seeking.Size = new System.Drawing.Size(97, 17);
            this.chk_Seeking.TabIndex = 12;
            this.chk_Seeking.Text = "Seeking Missle";
            this.chk_Seeking.UseVisualStyleBackColor = true;
            this.chk_Seeking.CheckedChanged += new System.EventHandler(this.chk_Seeking_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Premade Tower Settings";
            // 
            // cb_Premades
            // 
            this.cb_Premades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_Premades.FormattingEnabled = true;
            this.cb_Premades.Location = new System.Drawing.Point(15, 268);
            this.cb_Premades.Name = "cb_Premades";
            this.cb_Premades.Size = new System.Drawing.Size(121, 21);
            this.cb_Premades.TabIndex = 13;
            this.cb_Premades.SelectedIndexChanged += new System.EventHandler(this.cb_Premades_SelectedIndexChanged);
            // 
            // nudSlowTime
            // 
            this.nudSlowTime.Location = new System.Drawing.Point(233, 79);
            this.nudSlowTime.Name = "nudSlowTime";
            this.nudSlowTime.Size = new System.Drawing.Size(58, 20);
            this.nudSlowTime.TabIndex = 9;
            this.nudSlowTime.ValueChanged += new System.EventHandler(this.nudSlowTime_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Slow Time";
            // 
            // nudSlowPercentage
            // 
            this.nudSlowPercentage.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSlowPercentage.Location = new System.Drawing.Point(233, 53);
            this.nudSlowPercentage.Name = "nudSlowPercentage";
            this.nudSlowPercentage.Size = new System.Drawing.Size(58, 20);
            this.nudSlowPercentage.TabIndex = 8;
            this.nudSlowPercentage.ValueChanged += new System.EventHandler(this.nudSlowPercentage_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 99;
            this.label11.Text = "Slow%";
            // 
            // nud_ChainDist
            // 
            this.nud_ChainDist.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_ChainDist.Location = new System.Drawing.Point(233, 131);
            this.nud_ChainDist.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_ChainDist.Name = "nud_ChainDist";
            this.nud_ChainDist.Size = new System.Drawing.Size(58, 20);
            this.nud_ChainDist.TabIndex = 11;
            this.nud_ChainDist.ValueChanged += new System.EventHandler(this.nud_ChainDist_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(157, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "Chain Radius";
            // 
            // nud_ChainCount
            // 
            this.nud_ChainCount.Location = new System.Drawing.Point(233, 105);
            this.nud_ChainCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_ChainCount.Name = "nud_ChainCount";
            this.nud_ChainCount.Size = new System.Drawing.Size(58, 20);
            this.nud_ChainCount.TabIndex = 10;
            this.nud_ChainCount.ValueChanged += new System.EventHandler(this.nud_ChainCount_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(165, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 99;
            this.label13.Text = "Chain Hops";
            // 
            // TDTowerCreator
            // 
            this.ClientSize = new System.Drawing.Size(297, 289);
            this.ControlBox = false;
            this.Controls.Add(this.nud_ChainDist);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nud_ChainCount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudSlowTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudSlowPercentage);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cb_Premades);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chk_Seeking);
            this.Controls.Add(this.nud_SplashRadius);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudFireRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudBulletSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudRange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudHP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDamage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TDTowerCreator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Creator";
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBulletSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFireRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SplashRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlowPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChainDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ChainCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event Handlers
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void nudSlowPercentage_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void nudSlowTime_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void nud_ChainCount_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void nud_ChainDist_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        private void nud_SplashRadius_ValueChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void chk_Seeking_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }
        private void cb_Premades_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedPremadeTowerSettings(cb_Premades.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateNewTower();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Private functions
        private void CalculateCost()
        {
            totalCost = 0;

            
            // calculate cost based on variables
            totalCost += (int)((nudBulletSpeed.Value - nudBulletSpeed.Minimum) * CostMultiplier_BulletSpeed);
            totalCost += (int)((int)Math.Pow(2.0,(double)nudDamage.Value) * CostMultiplier_Damage);
            totalCost += (int)((int)Math.Pow(2.0, (double)((nudFireRate.Value - nudFireRate.Minimum) / 3)) * CostMultiplier_FireRate);
            totalCost += (int)((nudHP.Value - nudHP.Minimum) * CostMultiplier_HP);
            totalCost += (int)((nudRange.Value - nudRange.Minimum) * CostMultiplier_Range);

            // slow is a combination of time and rate
            totalCost += (int)(nudSlowPercentage.Value * nudSlowTime.Value * CostMultiplier_Slow);

            if (nud_SplashRadius.Value > 0)
            {
                totalCost += 1 + (int)(nud_SplashRadius.Value * CostMultiplier_SplashRadius);
            }

            if(chk_Seeking.Checked)
            {
                // seeking costs damage  *multiplier (the more damage, the costlier the seeking)
                totalCost += (int)(nudDamage.Value * CostMultiplier_Seeking);
            }

            if (nud_ChainCount.Value > 0)
            {
                // chain cost is composite of hops and distance
                totalCost += (int)(nud_ChainCount.Value * nud_ChainDist.Value * CostMultiplier_Chaining);
            }

            // display total cost
            int gold = 100;
            if (TDSession.thisSession != null)
            {
                gold = TDSession.thisSession.gold;
            }
            if (totalCost > gold)
            {
                lblCost.ForeColor = Color.Red;
            }
            else
            {
                lblCost.ForeColor = Color.Black;
            }

            lblCost.Text = totalCost.ToString();
        }
        private void LoadSelectedPremadeTowerSettings(string premadeName)
        {
            textBox1.Text = premadeName;

            switch (premadeName)
            {
                case PremadeTowerSettings.BasicTurret:
                    nudHP.Value = 50;
                    nudDamage.Value = 2;
                    nudBulletSpeed.Value = 50;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 16;
                    nudRange.Value = 35;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.ScoutTurret:
                    nudHP.Value = 50;
                    nudDamage.Value = 2;
                    nudBulletSpeed.Value = 100;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 10;
                    nudRange.Value = 150;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.BasicCannon:
                    nudHP.Value = 80;
                    nudDamage.Value = 5;
                    nudBulletSpeed.Value = 50;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 5;
                    nudRange.Value = 60;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.MissleTurret:
                    nudHP.Value = 90;
                    nudDamage.Value = 4;
                    nudBulletSpeed.Value = 60;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 10;
                    nudRange.Value = 100;
                    chk_Seeking.Checked = true;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.Mortar:
                    nudHP.Value = 80;
                    nudDamage.Value = 6;
                    nudBulletSpeed.Value = 40;
                    nud_SplashRadius.Value = 50;
                    nudFireRate.Value = 5;
                    nudRange.Value = 100;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.SlowTurret:
                    nudHP.Value = 50;
                    nudDamage.Value = 0;
                    nudBulletSpeed.Value = 40;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 5;
                    nudRange.Value = 50;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 30;
                    nudSlowTime.Value = 4;
                    nud_ChainDist.Value = 0;
                    nud_ChainCount.Value = 0;
                    break;
                case PremadeTowerSettings.ChainTurret:
                    nudHP.Value = 50;
                    nudDamage.Value = 4;
                    nudBulletSpeed.Value = 40;
                    nud_SplashRadius.Value = 0;
                    nudFireRate.Value = 5;
                    nudRange.Value = 50;
                    chk_Seeking.Checked = false;
                    nudSlowPercentage.Value = 0;
                    nudSlowTime.Value = 0;
                    nud_ChainDist.Value = 50;
                    nud_ChainCount.Value = 4;
                    break;
                default:
                    break;
            }
        }
        private void CreateNewTower()
        {
            TDTower t = new TDTower();
            t.BulletDamage = (int)nudDamage.Value;
            t.BulletSpeed = (int)nudBulletSpeed.Value;
            t.HPMax = (int)nudHP.Value;
            t.HPCurrent = t.HPMax;
            t.Name = textBox1.Text;
            t.Range = (int)nudRange.Value;
            t.SpashRadius = (int)nud_SplashRadius.Value;
            t.ChainDist = (int)nud_ChainDist.Value;
            t.ChainHops = (int)nud_ChainCount.Value;
            t.SeekingMissle = chk_Seeking.Checked;
            t.Cooldown = new TimeSpan(0, 0, 0, 0, (int)(500 / nudFireRate.Value));

            if (this.nudSlowPercentage.Value > 0 &&
                this.nudSlowTime.Value > 0)
            {
                t.Effects.Add(new TDEffect(TDEffectTypes.Slow, this.nudSlowPercentage.Value, new TimeSpan(0, 0, 0, (int)this.nudSlowTime.Value), false));
            }

            t.Cost = totalCost / 2; // prototype is full cost, each implementation is only half.

            t.IsHighlighted = true;

            this.Tower = t;

            TDSession.thisSession.gold -= totalCost;
        }
        #endregion

        public class PremadeTowerSettings
        {
            public const string BasicTurret = "Basic Turret";
            public const string BasicCannon = "Basic Cannon";
            public const string ScoutTurret = "Scout";
            public const string Mortar = "Mortar";
            public const string MissleTurret = "Missle Turret";
            public const string SlowTurret = "Slow Turret";
            public const string ChainTurret = "Chain Turret";
        }
    }
}
