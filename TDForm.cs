using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class TDForm: Form
    {
        public static TDForm ThisForm;
        public static Thread SessionThread;

        #region Cursor Stuff
        public enum CursorStates
        {
            Normal,
            PlaceTower,
            DeleteTower,
        }
        private CursorStates _CursorState;
        public CursorStates CursorState
        {
            get { return _CursorState; }
            set
            {
                _CursorState = value;
                switch(CursorState)
                {
                    case CursorStates.Normal:
                        Cursor.Current = Cursors.Default;
                        break;
                    case CursorStates.PlaceTower:
                        Cursor.Current = Cursors.Cross;
                        break;
                    case CursorStates.DeleteTower:
                        // only change to delete when over a button.
                        Cursor.Current = Cursors.Default;
                        break;
                }
            }
        }
        #endregion

        #region Public Fields
        public Panel panelAction;
        public Panel panelTools;
        public TDEntity CurrentlySelectedEntity;
        public Point CursorPosition;

        public static int MaxFPS = 50;
        public static int MessageDuration = 2000;
        public static TDTower placementTower = null;
        private System.Windows.Forms.Timer DrawTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer MessageTimer = new System.Windows.Forms.Timer();
        private BufferedGraphics bufferedGraphics;
        private Graphics ActionPanelGraphics;
        #endregion

        #region Constructor
        public TDForm()
        {
            ThisForm = this; // for component and cross thread references

            InitializeComponent();

            // read files
            TDResources.LoadResources();

            SetupNewSession();

            // setup drawing details
            ActionPanelGraphics = this.panelAction.CreateGraphics();
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            bufferedGraphics = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            DrawTimer.Enabled = true;
            DrawTimer.Tick += OnDrawTimer;
            DrawTimer.Interval = (1000/MaxFPS);
            DrawTimer.Start();

            MessageTimer.Tick += MessageTimer_Tick;
            MessageTimer.Interval = MessageDuration;
        }

        private void OnDrawTimer(object sender, System.EventArgs e)
        {
            DrawActionPanel(bufferedGraphics.Graphics);
            bufferedGraphics.Render(ActionPanelGraphics);
        }

        public void ResetActionGraphics()
        {
            if (TDSession.thisSession != null &&
                TDSession.thisSession.CurrentLevel != null &&
                TDSession.thisSession.CurrentLevel.Map != null)
            {
                TDSession.thisSession.CurrentLevel.Map.ResetBackGraphics();
            }
        }
        private void SetupNewSession()
        {
            // clear out old thread, if it exists
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.End();
                if (SessionThread != null)
                {
                    SessionThread.Join();
                }
            }

            ClearTowerButtons();
            ResetPurchaseButtons();
            ClearMessageDisplay();

            TDSession.thisSession = new TDSession();
            SessionThread = new Thread(new ThreadStart(TDSession.thisSession.Play));
            SessionThread.Start();
        }
        #endregion

        #region Event Handlers
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.Paused = true;
            }

            TDOptionsForm pop = new TDOptionsForm();
            pop.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tower Defense" + Environment.NewLine 
                            + "By Scott Hanson" + Environment.NewLine 
                            + "Version: " + Assembly.GetExecutingAssembly().GetName().Version);
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupNewSession();
        }
        private void ClearTowerButtons()
        {
            btnTower1.Tower = null;
            btnTower2.Tower = null;
            btnTower3.Tower = null;
            btnTower4.Tower = null;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.End();
            }
        }
        
        private void btnNewTower_Click(object sender, EventArgs e)
        {
            if (!ThereIsAnOpenTowerSlot())
            {
                MessageBox.Show("You have no open slots for new tower types.  Delete a tower type first.");
            }
            else
            {
                if (TDSession.thisSession != null)
                {
                    TDSession.thisSession.Paused = true;
                }

                TDTowerCreator pop = new TDTowerCreator();
                pop.FormClosed += pop_FormClosed;
                pop.Show();

                // clear selection and details when popup closes
                UnhighlightAll();
                ClearDetails();
                ResetPurchaseButtons();
                ResetAIButtons();
            }
        }
        void pop_FormClosed(object sender, FormClosedEventArgs e)
        {
            TDTower t = (sender as TDTowerCreator).Tower;
            if (t == null) { return; }

            // load thew newly created tower into one of the buttons.
            if (btnTower1.Tower == null)
            {
                btnTower1.Tower = t;
            }
            else if (btnTower2.Tower == null)
            {
                btnTower2.Tower = t;
            }
            else if (btnTower3.Tower == null)
            {
                btnTower3.Tower = t;
            }
            else if (btnTower4.Tower == null)
            {
                btnTower4.Tower = t;
            }
            else
            {
                // no more available tower types?
            }

            ResetPurchaseButtons();

            btnDeleteTowerType.Enabled = true;
        }
        private void btnDeleteTowerType_Click(object sender, EventArgs e)
        {
            this.CursorState = CursorStates.DeleteTower;
        }
        
        /// <summary>
        /// The main panel's action event handler.
        /// </summary>
        private void panelAction_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (e as MouseEventArgs);
            bool shiftPressed = Control.ModifierKeys.HasFlag(Keys.Shift);

            // placing a tower
            if (this._CursorState == CursorStates.PlaceTower)
            {
                TDTowerButton b = GetSelectedTowerButton();
                if (b == null) { return; }

                TDTower newTower = b.Tower;
                // if on path - no
                newTower.Location = new TDLocation(m.X, m.Y);

                if (TDSession.thisSession.CurrentLevel.CanPlaceTower(newTower))
                {
                    // actually place the tower
                    placeTower((e as MouseEventArgs).Location);

                    // and after we place the tower, unselect the tower if we did not have shift down (or right clicked)
                    if (m.Button == System.Windows.Forms.MouseButtons.Left &&
                        !shiftPressed)
                    {
                        this.CursorState = CursorStates.Normal;
                        GetSelectedTowerButton().Checked = false;
                    }
                }
            }
            // selecting something
            else
            {
                if (TDSession.thisSession == null) { return; }

                // attempt to highlight tower selected
                this.CurrentlySelectedEntity = GetTowerAtPoint((e as MouseEventArgs).Location);
                if (CurrentlySelectedEntity != null)
                {
                    UnhighlightAll();
                    CurrentlySelectedEntity.IsHighlighted = true;
                    LoadDetailsOfTower(CurrentlySelectedEntity as TDEntity);
                    if (CurrentlySelectedEntity is TDTower)
                    {
                        btnDelete.Enabled = true;
                        ResetPurchaseButtons();
                        ResetAIButtons();
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btn_Repair.Enabled = false;
                        btnUpgrade.Enabled = false;
                    }
                }
                else // nothing was clicked on
                {
                    UnhighlightAll();
                    ClearDetails();
                    ResetPurchaseButtons();
                    ResetAIButtons();
                }
            }
        }

        private void TDForm_ResizeEnd(object sender, EventArgs e)
        {
            ResetActionGraphics();
        }

        private void panelAction_MouseMove(object sender, MouseEventArgs e)
        {
            this.CursorPosition = e.Location;
        }

        #region Upgrade Buttons
        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            // pop upgrade box - idea rejected
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // confirm - sell tower
            DialogResult r = MessageBox.Show("Are you sure you want to sell this tower?", "Sell tower?", MessageBoxButtons.YesNo);
            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                TDSession.thisSession.gold += this.CurrentlySelectedEntity.Cost / 2;
                TDSession.thisSession.CurrentLevel.Towers.Remove(this.CurrentlySelectedEntity as TDTower);
                this.CurrentlySelectedEntity = null;
                RefreshDetailsOfSelection();
            }
        }
        private void btn_Repair_Click(object sender, EventArgs e)
        {
            TDSession.thisSession.gold -= this.CurrentlySelectedEntity.RepairCost();
            this.CurrentlySelectedEntity.HPCurrent = this.CurrentlySelectedEntity.HPMax;
        }
        #endregion

        #region AI Buttons
        private void btnAI_First_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.First;
        }
        private void btnAILast_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.Last;
        }
        private void btnAIStrong_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.Strong;
        }
        private void btnAIWeak_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.Weak;
        }
        private void btnAIClose_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.Close;
        }
        private void btnAIFar_Click(object sender, EventArgs e)
        {
            (this.CurrentlySelectedEntity as TDTower).AISetting = TDTower.AISettings.Far;
        }
        #endregion

        #region Speed Buttons
        private void btnSpeed_Paused_Click(object sender, EventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.Paused = true;
            }
        }
        private void btnSpeed_Normal_Click(object sender, EventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.Paused = false;
                TDSession.thisSession.Speed = TDSession.SessionSpeed.Normal;
            }
        }
        private void btnSpeed_Fast_Click(object sender, EventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.Paused = false;
                TDSession.thisSession.Speed = TDSession.SessionSpeed.Fast;
            }
        }
        private void btnSpeed_Super_Click(object sender, EventArgs e)
        {
            if (TDSession.thisSession != null)
            {
                TDSession.thisSession.Paused = false;
                TDSession.thisSession.Speed = TDSession.SessionSpeed.SuperFast;
            }
        }
        public void ResetSpeedButtonFont()
        {
            SetButtonBold(btnSpeed_Normal, false);
            SetButtonBold(btnSpeed_Fast, false);
            SetButtonBold(btnSpeed_Super, false);

            if (TDSession.thisSession != null)
            {
                SetButtonBold(btnSpeed_Paused, TDSession.thisSession.Paused);
                
                switch (TDSession.thisSession.Speed)
                {
                    case TDSession.SessionSpeed.Normal:
                        SetButtonBold(btnSpeed_Normal, true);
                        break;
                    case TDSession.SessionSpeed.Fast:
                        SetButtonBold(btnSpeed_Fast, true);
                        break;
                    case TDSession.SessionSpeed.SuperFast:
                        SetButtonBold(btnSpeed_Super, true);
                        break;
                    default:
                        break;
                }
            }
        }
        private void SetButtonBold(Button b, bool bold)
        {
            if (b.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    SetButtonBold(b, bold);
                }));
            }
            else
            {
                try
                {
                    if (b.Font.Bold != bold)
                    {
                        if (bold)
                        {
                            b.Font = new Font(b.Font, FontStyle.Bold);
                            b.ForeColor = Color.Green;
                        }
                        else
                        {
                            b.Font = new Font(b.Font, FontStyle.Regular);
                            b.ForeColor = Color.Black;
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

        #endregion

        #region Public Methods
        public void RefreshDetailsOfSelection()
        {
            LoadDetailsOfTower(CurrentlySelectedEntity);
            ResetPurchaseButtons();
            ResetAIButtons();
        }
        internal void DisplayLevelWin(int lvl)
        {
            DisplayMessage($"Level {lvl} passed!");
        }
        internal void DisplayLoss()
        {
            DisplayMessage("Game Over");

            TDSession.thisSession.End();
            TDSession.thisSession = null;
        }

        public void SetLabelText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        lbl.Text = text;
                    }));
                }
                catch { }
            }
            else
            {
                try
                {
                    lbl.Text = text;
                }
                catch { }
            }
        }
        public void SetControlState(Control c, bool State)
        {
            if (c.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        c.Enabled = State;
                    }));
                }
                catch { }
            }
            else
            {
                try
                {
                    c.Enabled = State;
                }
                catch { }
            }
        }
        public void SetControlVisibility(Control c, bool vis)
        {
            if (c.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        c.Visible = vis;
                    }));
                }
                catch { }
            }
            else
            {
                try
                {
                    c.Visible = vis;
                }
                catch { }
            }
        }
        #endregion

        #region Private Functions
        private void SetButtonText(Button b, string text)
        {
            if (b.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        b.Text = text;
                    }));
                }
                catch { }
            }
            else
            {
                try
                {
                    b.Text = text;
                }
                catch { }
            }
        }
        private void SetComboBoxText(ComboBox c, string text)
        {
            if (c.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        c.Text = text;
                    }));
                }
                catch { }
            }
            else
            {
                try
                {
                    c.Text = text;
                }
                catch { }
            }
        }
        private bool ThereIsAnOpenTowerSlot()
        {
            return (this.btnTower1.Tower == null ||
                    this.btnTower2.Tower == null ||
                    this.btnTower3.Tower == null ||
                    this.btnTower4.Tower == null);
        }
        private void LoadDetailsOfTower(TDEntity tde)
        {
            if (tde != null)
            {
                SetLabelText(this.lblDetailName, tde.Name);
                SetLabelText(this.lblDetailsDamage, tde.BulletDamage.ToString());
                SetLabelText(this.lblDetailRange, tde.Range.ToString());
                SetLabelText(this.lblDetailsHP, "" + Math.Max(0, tde.HPCurrent) + " / " + tde.HPMax);
                SetLabelText(this.lblDetailsFireRate, "" + (int)(500 / tde.Cooldown.TotalMilliseconds));
                SetLabelText(this.lblDetailsSplashRadius, tde.SpashRadius.ToString());

                if (tde is TDTower)
                {
                    SetLabelText(this.lblDetail_AI, Enum.GetName(typeof(TDTower.AISettings), (tde as TDTower).AISetting));
                    SetLabelText(this.lbl_Detail_Speed, tde.BulletSpeed.ToString());
                }
                else // TDAttacker
                {
                    SetLabelText(this.lbl_Detail_Speed, (tde.SpeedCurrent).ToString());
                }
            }
            else
            {
                SetLabelText(this.lblDetailName, String.Empty);
                SetLabelText(this.lblDetailsDamage, String.Empty);
                SetLabelText(this.lblDetailRange, String.Empty);
                SetLabelText(this.lbl_Detail_Speed, String.Empty);
                SetLabelText(this.lblDetailsHP, String.Empty);
                SetLabelText(this.lblDetailsFireRate, String.Empty);
                SetLabelText(this.lblDetailsSplashRadius, String.Empty);
                SetLabelText(this.lblDetail_AI, String.Empty);
            }
        }
        private void ClearDetails()
        {
            SetLabelText(this.lblDetailName, "<name>");
            SetLabelText(this.lblDetailsDamage, "0");
            SetLabelText(this.lblDetailsHP, "" + "0 / 0");
            SetLabelText(this.lblDetailsFireRate, "0");
            SetLabelText(this.lblDetailsSplashRadius, "0");
        }
        private void UnhighlightAll()
        {
            for (int i = 0; i < TDSession.thisSession.CurrentLevel.Attackers.Count; i++)
            {
                TDSession.thisSession.CurrentLevel.Attackers[i].IsHighlighted = false;
            }
            for (int i = 0; i < TDSession.thisSession.CurrentLevel.Towers.Count; i++)
            {
                TDSession.thisSession.CurrentLevel.Towers[i].IsHighlighted = false;
            }
        }
        private TDEntity GetTowerAtPoint(Point point)
        {
            if (TDSession.thisSession == null ||
                TDSession.thisSession.CurrentLevel == null)
            {
                return null;
            }

            TDLocation p = new TDLocation(point.X, point.Y);
            foreach (TDAttacker a in TDSession.thisSession.CurrentLevel.Attackers)
            {
                if (TDMath.PointOnPoint(a.Location, p, a.Size)) { return a; }
            }

            foreach (TDTower t in TDSession.thisSession.CurrentLevel.Towers)
            {
                if (TDMath.PointOnPoint(t.Location, p, t.Size)) { return t; }
            }

            // if not a tower or attacker, then nothing
            return null;
        }
        private void placeTower(Point point)
        {
            TDTower newTower = new TDTower(GetSelectedTowerType(), point);
            TDSession.thisSession.CurrentLevel.Towers.Add(newTower);
            TDSession.thisSession.gold -= newTower.Cost;
        }
        private TDTower GetSelectedTowerType()
        {
            return GetSelectedTowerButton().Tower;
        }
        private TDTowerButton GetSelectedTowerButton()
        {
            if (this.btnTower1.Checked) { return btnTower1; }
            else if (this.btnTower2.Checked) { return btnTower2; }
            else if (this.btnTower3.Checked) { return btnTower3; }
            else if (this.btnTower4.Checked) { return btnTower4; }
            else { return null; }
        }
        internal void ResetPurchaseButtons()
        {
            if (TDSession.thisSession == null) { return; }

            // based on current session gold, enable/disable buttons to purchase and/or repair towers

            SetTowerButtonState(btnTower1);
            SetTowerButtonState(btnTower2);
            SetTowerButtonState(btnTower3);
            SetTowerButtonState(btnTower4);

            // if selection is a tower, then reset detail buttons
            if (this.CurrentlySelectedEntity != null &&
                this.CurrentlySelectedEntity is TDTower &&
                this.CurrentlySelectedEntity.DeleteMe == false)
            {
                this.btnUpgrade.Enabled = true;

                SetButtonText(this.btnDelete,"Sell (" + (this.CurrentlySelectedEntity.Cost / 2) + ")");
                this.btnDelete.Enabled = true;

                // if selected tower is damaged
                if (this.CurrentlySelectedEntity.HPCurrent < this.CurrentlySelectedEntity.HPMax)
                {
                    // repair cost is % health missing / 2 (so it is cheaper to repair than to buy new).
                    SetButtonText(this.btn_Repair, "Repair (" + this.CurrentlySelectedEntity.RepairCost() + ")");
                    SetControlState(this.btn_Repair, TDSession.thisSession.gold >= this.CurrentlySelectedEntity.RepairCost());
                }
            }
            else // not a valid tower, don't allow anything.
            {
                SetControlState(this.btn_Repair,false);
                SetControlState(this.btnUpgrade,false);
                SetControlState(this.btnDelete,false);
            }
        }
        private void ClearMessageDisplay()
        {
            SetControlVisibility(lblLevelOutcome, false);
        }

        private void SetTowerButtonState(TDTowerButton b)
        {
            if (b.Tower != null)
            {
                bool state = TDSession.thisSession.gold >= b.Tower.Cost;
                
                if (!state && b.Checked)
                {
                    SetControlChecked(b, false);
                    if (TDForm.ThisForm._CursorState == CursorStates.PlaceTower)
                    {
                        TDForm.ThisForm._CursorState = CursorStates.Normal;
                        TDForm.ThisForm.Focus();
                    }
                }

                SetControlState(b, state);
            }
            else
            {
                SetControlChecked(b, false);
                SetControlState(b, false);
            }
        }
        private void SetControlChecked(CheckBox c, bool State)
        {
            if (c.InvokeRequired)
            {
                try
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        c.Checked = State;
                    }));
                }
                catch { }
            }
            else
            {
                c.Enabled = State;
            }
        }
        private void ResetAIButtons()
        {
            if (this.CurrentlySelectedEntity != null)
            {
                bool state = (this.CurrentlySelectedEntity is TDTower);
                SetControlState(btnAI_First, state);
                SetControlState(btnAILast, state);
                SetControlState(btnAIStrong, state);
                SetControlState(btnAIWeak, state);
                SetControlState(btnAIClose, state);
                SetControlState(btnAIFar, state);
            }
            else
            {
                SetControlState(btnAI_First, false);
                SetControlState(btnAILast, false);
                SetControlState(btnAIStrong, false);
                SetControlState(btnAIWeak, false);
                SetControlState(btnAIClose, false);
                SetControlState(btnAIFar, false);
            }
        }

        private void DisplayMessage(string msg)
        {
            SetControlVisibility(lblLevelOutcome, true);
            SetLabelText(lblLevelOutcome, msg);
            MessageTimer.Enabled = true;
            MessageTimer.Start();
        }
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("timer ticked, hiding lbl...");
            SetControlVisibility(lblLevelOutcome, false);
            MessageTimer.Stop(); // we only show the message once.
        }

        #endregion

        #region Drawing actionPanel
        private void DrawActionPanel(Graphics g)
        {
            // draw
            if (TDSession.thisSession != null &&
                TDSession.thisSession.CurrentLevel != null)
            {
                // tell the level to draw itself to the back graphics
                TDSession.thisSession.CurrentLevel.DrawSelf(g);

                // draw a tower on the cursor
                if (TDForm.ThisForm.CursorState == TDForm.CursorStates.PlaceTower &&
                    placementTower != null)
                {
                    if (TDSession.thisSession.CurrentLevel.CanPlaceTower(placementTower))
                    {
                        placementTower.MainColor = Color.Blue;
                    }
                    else
                    {
                        placementTower.MainColor = Color.Red;
                    }

                    placementTower.DrawSelf(g, TDForm.ThisForm.CursorPosition);
                }
            }
        }
        #endregion
    }
}
