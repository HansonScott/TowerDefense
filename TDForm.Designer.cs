namespace TowerDefense
{
    partial class TDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TDForm));
            this.panelAction = new System.Windows.Forms.Panel();
            this.panelTools = new System.Windows.Forms.Panel();
            this.btnSpeed_Super = new System.Windows.Forms.Button();
            this.btnSpeed_Fast = new System.Windows.Forms.Button();
            this.btnSpeed_Normal = new System.Windows.Forms.Button();
            this.btnSpeed_Paused = new System.Windows.Forms.Button();
            this.lblNextWave = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_Detail_Speed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDetail_AI = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAIFar = new System.Windows.Forms.Button();
            this.btnAIClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAIWeak = new System.Windows.Forms.Button();
            this.btnAIStrong = new System.Windows.Forms.Button();
            this.btnAILast = new System.Windows.Forms.Button();
            this.btnAI_First = new System.Windows.Forms.Button();
            this.btn_Repair = new System.Windows.Forms.Button();
            this.lblDetailsSplashRadius = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpgrade = new System.Windows.Forms.Button();
            this.lblDetailsFireRate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDetailRange = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDetailsDamage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDetailsHP = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteTowerType = new System.Windows.Forms.Button();
            this.btnTower4 = new TowerDefense.TDTowerButton();
            this.btnTower3 = new TowerDefense.TDTowerButton();
            this.btnTower2 = new TowerDefense.TDTowerButton();
            this.btnNewTower = new System.Windows.Forms.Button();
            this.btnTower1 = new TowerDefense.TDTowerButton();
            this.lblHP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionSpeedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTools.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionSpeedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAction
            // 
            this.panelAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAction.AutoScroll = true;
            this.panelAction.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelAction.Location = new System.Drawing.Point(12, 32);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(853, 658);
            this.panelAction.TabIndex = 0;
            this.panelAction.Click += new System.EventHandler(this.panelAction_Click);
            this.panelAction.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelAction_MouseMove);
            // 
            // panelTools
            // 
            this.panelTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTools.Controls.Add(this.btnSpeed_Super);
            this.panelTools.Controls.Add(this.btnSpeed_Fast);
            this.panelTools.Controls.Add(this.btnSpeed_Normal);
            this.panelTools.Controls.Add(this.btnSpeed_Paused);
            this.panelTools.Controls.Add(this.lblNextWave);
            this.panelTools.Controls.Add(this.label16);
            this.panelTools.Controls.Add(this.lbl_Detail_Speed);
            this.panelTools.Controls.Add(this.label12);
            this.panelTools.Controls.Add(this.lblDetail_AI);
            this.panelTools.Controls.Add(this.label15);
            this.panelTools.Controls.Add(this.btnAIFar);
            this.panelTools.Controls.Add(this.btnAIClose);
            this.panelTools.Controls.Add(this.label8);
            this.panelTools.Controls.Add(this.label5);
            this.panelTools.Controls.Add(this.btnAIWeak);
            this.panelTools.Controls.Add(this.btnAIStrong);
            this.panelTools.Controls.Add(this.btnAILast);
            this.panelTools.Controls.Add(this.btnAI_First);
            this.panelTools.Controls.Add(this.btn_Repair);
            this.panelTools.Controls.Add(this.lblDetailsSplashRadius);
            this.panelTools.Controls.Add(this.label6);
            this.panelTools.Controls.Add(this.label14);
            this.panelTools.Controls.Add(this.btnDelete);
            this.panelTools.Controls.Add(this.btnUpgrade);
            this.panelTools.Controls.Add(this.lblDetailsFireRate);
            this.panelTools.Controls.Add(this.label13);
            this.panelTools.Controls.Add(this.lblDetailRange);
            this.panelTools.Controls.Add(this.label11);
            this.panelTools.Controls.Add(this.lblDetailsDamage);
            this.panelTools.Controls.Add(this.label9);
            this.panelTools.Controls.Add(this.lblDetailsHP);
            this.panelTools.Controls.Add(this.label7);
            this.panelTools.Controls.Add(this.lblDetailName);
            this.panelTools.Controls.Add(this.label3);
            this.panelTools.Controls.Add(this.lblGold);
            this.panelTools.Controls.Add(this.label4);
            this.panelTools.Controls.Add(this.btnDeleteTowerType);
            this.panelTools.Controls.Add(this.btnTower4);
            this.panelTools.Controls.Add(this.btnTower3);
            this.panelTools.Controls.Add(this.btnTower2);
            this.panelTools.Controls.Add(this.btnNewTower);
            this.panelTools.Controls.Add(this.btnTower1);
            this.panelTools.Controls.Add(this.lblHP);
            this.panelTools.Controls.Add(this.label2);
            this.panelTools.Location = new System.Drawing.Point(871, 32);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(181, 658);
            this.panelTools.TabIndex = 1;
            // 
            // btnSpeed_Super
            // 
            this.btnSpeed_Super.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed_Super.Location = new System.Drawing.Point(143, 6);
            this.btnSpeed_Super.Name = "btnSpeed_Super";
            this.btnSpeed_Super.Size = new System.Drawing.Size(37, 23);
            this.btnSpeed_Super.TabIndex = 4;
            this.btnSpeed_Super.Text = ">>>";
            this.btnSpeed_Super.UseVisualStyleBackColor = true;
            this.btnSpeed_Super.Click += new System.EventHandler(this.btnSpeed_Super_Click);
            // 
            // btnSpeed_Fast
            // 
            this.btnSpeed_Fast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed_Fast.Location = new System.Drawing.Point(100, 6);
            this.btnSpeed_Fast.Name = "btnSpeed_Fast";
            this.btnSpeed_Fast.Size = new System.Drawing.Size(37, 23);
            this.btnSpeed_Fast.TabIndex = 3;
            this.btnSpeed_Fast.Text = ">>";
            this.btnSpeed_Fast.UseVisualStyleBackColor = true;
            this.btnSpeed_Fast.Click += new System.EventHandler(this.btnSpeed_Fast_Click);
            // 
            // btnSpeed_Normal
            // 
            this.btnSpeed_Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed_Normal.Location = new System.Drawing.Point(58, 6);
            this.btnSpeed_Normal.Name = "btnSpeed_Normal";
            this.btnSpeed_Normal.Size = new System.Drawing.Size(38, 23);
            this.btnSpeed_Normal.TabIndex = 2;
            this.btnSpeed_Normal.Text = ">";
            this.btnSpeed_Normal.UseVisualStyleBackColor = true;
            this.btnSpeed_Normal.Click += new System.EventHandler(this.btnSpeed_Normal_Click);
            // 
            // btnSpeed_Paused
            // 
            this.btnSpeed_Paused.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeed_Paused.Location = new System.Drawing.Point(8, 6);
            this.btnSpeed_Paused.Name = "btnSpeed_Paused";
            this.btnSpeed_Paused.Size = new System.Drawing.Size(44, 23);
            this.btnSpeed_Paused.TabIndex = 1;
            this.btnSpeed_Paused.Text = "| |";
            this.btnSpeed_Paused.UseVisualStyleBackColor = true;
            this.btnSpeed_Paused.Click += new System.EventHandler(this.btnSpeed_Paused_Click);
            // 
            // lblNextWave
            // 
            this.lblNextWave.AutoSize = true;
            this.lblNextWave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextWave.ForeColor = System.Drawing.Color.Blue;
            this.lblNextWave.Location = new System.Drawing.Point(78, 67);
            this.lblNextWave.Name = "lblNextWave";
            this.lblNextWave.Size = new System.Drawing.Size(42, 13);
            this.lblNextWave.TabIndex = 99;
            this.lblNextWave.Text = "1 / 10";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 99;
            this.label16.Text = "Wave:";
            // 
            // lbl_Detail_Speed
            // 
            this.lbl_Detail_Speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Detail_Speed.AutoSize = true;
            this.lbl_Detail_Speed.Location = new System.Drawing.Point(147, 379);
            this.lbl_Detail_Speed.Name = "lbl_Detail_Speed";
            this.lbl_Detail_Speed.Size = new System.Drawing.Size(13, 13);
            this.lbl_Detail_Speed.TabIndex = 99;
            this.lbl_Detail_Speed.Tag = "First";
            this.lbl_Detail_Speed.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(90, 379);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "Speed:";
            // 
            // lblDetail_AI
            // 
            this.lblDetail_AI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetail_AI.AutoSize = true;
            this.lblDetail_AI.Location = new System.Drawing.Point(118, 405);
            this.lblDetail_AI.Name = "lblDetail_AI";
            this.lblDetail_AI.Size = new System.Drawing.Size(13, 13);
            this.lblDetail_AI.TabIndex = 99;
            this.lblDetail_AI.Tag = "First";
            this.lblDetail_AI.Text = "0";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(92, 405);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 99;
            this.label15.Text = "AI:";
            // 
            // btnAIFar
            // 
            this.btnAIFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIFar.Enabled = false;
            this.btnAIFar.Location = new System.Drawing.Point(95, 503);
            this.btnAIFar.Name = "btnAIFar";
            this.btnAIFar.Size = new System.Drawing.Size(83, 23);
            this.btnAIFar.TabIndex = 16;
            this.btnAIFar.Text = "Far";
            this.btnAIFar.UseVisualStyleBackColor = true;
            this.btnAIFar.Click += new System.EventHandler(this.btnAIFar_Click);
            // 
            // btnAIClose
            // 
            this.btnAIClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIClose.Enabled = false;
            this.btnAIClose.Location = new System.Drawing.Point(8, 503);
            this.btnAIClose.Name = "btnAIClose";
            this.btnAIClose.Size = new System.Drawing.Size(83, 23);
            this.btnAIClose.TabIndex = 15;
            this.btnAIClose.Text = "Close";
            this.btnAIClose.UseVisualStyleBackColor = true;
            this.btnAIClose.Click += new System.EventHandler(this.btnAIClose_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "Purchasing Options";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "AI Settings";
            // 
            // btnAIWeak
            // 
            this.btnAIWeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIWeak.Enabled = false;
            this.btnAIWeak.Location = new System.Drawing.Point(95, 474);
            this.btnAIWeak.Name = "btnAIWeak";
            this.btnAIWeak.Size = new System.Drawing.Size(83, 23);
            this.btnAIWeak.TabIndex = 14;
            this.btnAIWeak.Text = "Weak";
            this.btnAIWeak.UseVisualStyleBackColor = true;
            this.btnAIWeak.Click += new System.EventHandler(this.btnAIWeak_Click);
            // 
            // btnAIStrong
            // 
            this.btnAIStrong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIStrong.Enabled = false;
            this.btnAIStrong.Location = new System.Drawing.Point(8, 474);
            this.btnAIStrong.Name = "btnAIStrong";
            this.btnAIStrong.Size = new System.Drawing.Size(83, 23);
            this.btnAIStrong.TabIndex = 13;
            this.btnAIStrong.Text = "Strong";
            this.btnAIStrong.UseVisualStyleBackColor = true;
            this.btnAIStrong.Click += new System.EventHandler(this.btnAIStrong_Click);
            // 
            // btnAILast
            // 
            this.btnAILast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAILast.Enabled = false;
            this.btnAILast.Location = new System.Drawing.Point(95, 445);
            this.btnAILast.Name = "btnAILast";
            this.btnAILast.Size = new System.Drawing.Size(83, 23);
            this.btnAILast.TabIndex = 12;
            this.btnAILast.Text = "Last";
            this.btnAILast.UseVisualStyleBackColor = true;
            this.btnAILast.Click += new System.EventHandler(this.btnAILast_Click);
            // 
            // btnAI_First
            // 
            this.btnAI_First.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAI_First.Enabled = false;
            this.btnAI_First.Location = new System.Drawing.Point(8, 445);
            this.btnAI_First.Name = "btnAI_First";
            this.btnAI_First.Size = new System.Drawing.Size(83, 23);
            this.btnAI_First.TabIndex = 11;
            this.btnAI_First.Text = "First";
            this.btnAI_First.UseVisualStyleBackColor = true;
            this.btnAI_First.Click += new System.EventHandler(this.btnAI_First_Click);
            // 
            // btn_Repair
            // 
            this.btn_Repair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Repair.Enabled = false;
            this.btn_Repair.Location = new System.Drawing.Point(5, 555);
            this.btn_Repair.Name = "btn_Repair";
            this.btn_Repair.Size = new System.Drawing.Size(56, 23);
            this.btn_Repair.TabIndex = 17;
            this.btn_Repair.Text = "Repair";
            this.btn_Repair.UseVisualStyleBackColor = true;
            this.btn_Repair.Click += new System.EventHandler(this.btn_Repair_Click);
            // 
            // lblDetailsSplashRadius
            // 
            this.lblDetailsSplashRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsSplashRadius.AutoSize = true;
            this.lblDetailsSplashRadius.Location = new System.Drawing.Point(61, 405);
            this.lblDetailsSplashRadius.Name = "lblDetailsSplashRadius";
            this.lblDetailsSplashRadius.Size = new System.Drawing.Size(13, 13);
            this.lblDetailsSplashRadius.TabIndex = 99;
            this.lblDetailsSplashRadius.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Splash:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 317);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "Details of Selection";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(129, 555);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Sell";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpgrade.Enabled = false;
            this.btnUpgrade.Location = new System.Drawing.Point(67, 555);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(56, 23);
            this.btnUpgrade.TabIndex = 18;
            this.btnUpgrade.Text = "Upgrade";
            this.btnUpgrade.UseVisualStyleBackColor = true;
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // lblDetailsFireRate
            // 
            this.lblDetailsFireRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsFireRate.AutoSize = true;
            this.lblDetailsFireRate.Location = new System.Drawing.Point(61, 392);
            this.lblDetailsFireRate.Name = "lblDetailsFireRate";
            this.lblDetailsFireRate.Size = new System.Drawing.Size(13, 13);
            this.lblDetailsFireRate.TabIndex = 99;
            this.lblDetailsFireRate.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 392);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 99;
            this.label13.Text = "Fire Rate:";
            // 
            // lblDetailRange
            // 
            this.lblDetailRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailRange.AutoSize = true;
            this.lblDetailRange.Location = new System.Drawing.Point(61, 379);
            this.lblDetailRange.Name = "lblDetailRange";
            this.lblDetailRange.Size = new System.Drawing.Size(13, 13);
            this.lblDetailRange.TabIndex = 99;
            this.lblDetailRange.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 99;
            this.label11.Text = "Range";
            // 
            // lblDetailsDamage
            // 
            this.lblDetailsDamage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsDamage.AutoSize = true;
            this.lblDetailsDamage.Location = new System.Drawing.Point(61, 366);
            this.lblDetailsDamage.Name = "lblDetailsDamage";
            this.lblDetailsDamage.Size = new System.Drawing.Size(13, 13);
            this.lblDetailsDamage.TabIndex = 99;
            this.lblDetailsDamage.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Damage:";
            // 
            // lblDetailsHP
            // 
            this.lblDetailsHP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsHP.AutoSize = true;
            this.lblDetailsHP.Location = new System.Drawing.Point(61, 353);
            this.lblDetailsHP.Name = "lblDetailsHP";
            this.lblDetailsHP.Size = new System.Drawing.Size(30, 13);
            this.lblDetailsHP.TabIndex = 99;
            this.lblDetailsHP.Text = "0 / 0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "HP:";
            // 
            // lblDetailName
            // 
            this.lblDetailName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Location = new System.Drawing.Point(61, 340);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(45, 13);
            this.lblDetailName.TabIndex = 99;
            this.lblDetailName.Text = "<name>";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Name:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblGold.Location = new System.Drawing.Point(123, 44);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(28, 13);
            this.lblGold.TabIndex = 99;
            this.lblGold.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Gold:";
            // 
            // btnDeleteTowerType
            // 
            this.btnDeleteTowerType.Enabled = false;
            this.btnDeleteTowerType.Location = new System.Drawing.Point(3, 276);
            this.btnDeleteTowerType.Name = "btnDeleteTowerType";
            this.btnDeleteTowerType.Size = new System.Drawing.Size(175, 23);
            this.btnDeleteTowerType.TabIndex = 10;
            this.btnDeleteTowerType.Text = "Delete Tower Type";
            this.btnDeleteTowerType.UseVisualStyleBackColor = true;
            this.btnDeleteTowerType.Click += new System.EventHandler(this.btnDeleteTowerType_Click);
            // 
            // btnTower4
            // 
            this.btnTower4.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnTower4.Enabled = false;
            this.btnTower4.Location = new System.Drawing.Point(95, 200);
            this.btnTower4.Name = "btnTower4";
            this.btnTower4.Padding = new System.Windows.Forms.Padding(1);
            this.btnTower4.Size = new System.Drawing.Size(83, 70);
            this.btnTower4.TabIndex = 9;
            this.btnTower4.Text = "unknown tower";
            this.btnTower4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTower4.Tower = null;
            this.btnTower4.UseVisualStyleBackColor = true;
            // 
            // btnTower3
            // 
            this.btnTower3.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnTower3.Enabled = false;
            this.btnTower3.Location = new System.Drawing.Point(3, 200);
            this.btnTower3.Name = "btnTower3";
            this.btnTower3.Padding = new System.Windows.Forms.Padding(1);
            this.btnTower3.Size = new System.Drawing.Size(86, 70);
            this.btnTower3.TabIndex = 8;
            this.btnTower3.Text = "unknown tower";
            this.btnTower3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTower3.Tower = null;
            this.btnTower3.UseVisualStyleBackColor = true;
            // 
            // btnTower2
            // 
            this.btnTower2.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnTower2.Enabled = false;
            this.btnTower2.Location = new System.Drawing.Point(95, 124);
            this.btnTower2.Name = "btnTower2";
            this.btnTower2.Padding = new System.Windows.Forms.Padding(1);
            this.btnTower2.Size = new System.Drawing.Size(83, 70);
            this.btnTower2.TabIndex = 7;
            this.btnTower2.Text = "unknown tower";
            this.btnTower2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTower2.Tower = null;
            this.btnTower2.UseVisualStyleBackColor = true;
            // 
            // btnNewTower
            // 
            this.btnNewTower.Enabled = false;
            this.btnNewTower.Location = new System.Drawing.Point(3, 95);
            this.btnNewTower.Name = "btnNewTower";
            this.btnNewTower.Size = new System.Drawing.Size(175, 23);
            this.btnNewTower.TabIndex = 5;
            this.btnNewTower.Text = "Create Tower Type";
            this.btnNewTower.UseVisualStyleBackColor = true;
            this.btnNewTower.Click += new System.EventHandler(this.btnNewTower_Click);
            // 
            // btnTower1
            // 
            this.btnTower1.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnTower1.Enabled = false;
            this.btnTower1.Location = new System.Drawing.Point(3, 124);
            this.btnTower1.Name = "btnTower1";
            this.btnTower1.Padding = new System.Windows.Forms.Padding(1);
            this.btnTower1.Size = new System.Drawing.Size(86, 70);
            this.btnTower1.TabIndex = 6;
            this.btnTower1.Text = "unknown tower";
            this.btnTower1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTower1.Tower = null;
            this.btnTower1.UseVisualStyleBackColor = true;
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP.ForeColor = System.Drawing.Color.Red;
            this.lblHP.Location = new System.Drawing.Point(54, 44);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(28, 13);
            this.lblHP.TabIndex = 99;
            this.lblHP.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "HP:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // sessionSpeedBindingSource
            // 
            this.sessionSpeedBindingSource.DataSource = typeof(TowerDefense.TDSession.SessionSpeed);
            // 
            // TDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 702);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower Defense";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TDForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.TDForm_ResizeEnd);
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionSpeedBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource sessionSpeedBindingSource;
        public System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label label2;
        public TDTowerButton btnTower4;
        public TDTowerButton btnTower3;
        public TDTowerButton btnTower2;
        public System.Windows.Forms.Button btnNewTower;
        public TDTowerButton btnTower1;
        public System.Windows.Forms.Button btnDeleteTowerType;
        public System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label lblDetailsFireRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDetailRange;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDetailsDamage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDetailsHP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDetailsSplashRadius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Repair;
        private System.Windows.Forms.Button btnAI_First;
        private System.Windows.Forms.Button btnAIWeak;
        private System.Windows.Forms.Button btnAIStrong;
        private System.Windows.Forms.Button btnAILast;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAIFar;
        private System.Windows.Forms.Button btnAIClose;
        private System.Windows.Forms.Label lblDetail_AI;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_Detail_Speed;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblNextWave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSpeed_Super;
        private System.Windows.Forms.Button btnSpeed_Fast;
        private System.Windows.Forms.Button btnSpeed_Normal;
        private System.Windows.Forms.Button btnSpeed_Paused;
    }
}

