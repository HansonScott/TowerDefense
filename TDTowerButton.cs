using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public class TDTowerButton: System.Windows.Forms.CheckBox
    {
        private TDTower _Tower;
        public TDTower Tower
        {
            get { return _Tower; }
            set 
            {
                _Tower = value;
                if (value != null)
                {
                    this.Text = value.Name + " (" + value.Cost + ")";
                    this.Enabled = true;
                }
                else
                {
                    this.Text = "unknown tower";
                    this.Checked = false;
                    this.Enabled = false;
                }
            }
        }

        public TDTowerButton()
            : base()
        {
            this.Tower = null;
            this.Text = "unknown tower";

            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.Enabled = false;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tower = null;
            this.UseVisualStyleBackColor = true;

            this.MouseEnter += TDTowerButton_MouseEnter;
            this.MouseLeave += TDTowerButton_MouseLeave;

            this.Click += TDTowerButton_Click;

            this.Padding = new Padding(1);

        }

        void TDTowerButton_Click(object sender, EventArgs e)
        {
            if (this.Checked)
            {
                // then uncheck all the other towers
                UnCheckOtherPurchaseButtons();

                if (TDForm.ThisForm.CursorState == TDForm.CursorStates.DeleteTower)
                {
                    DialogResult r = MessageBox.Show("Are you sure you want to delete this tower type?", "Delete Tower?", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        Tower = null;
                        TDForm.ThisForm.CursorState = TDForm.CursorStates.Normal;
                        //this.Checked = false;
                    }
                }
                else if (TDForm.ThisForm.CursorState == TDForm.CursorStates.Normal)
                {
                    TDForm.ThisForm.CursorState = TDForm.CursorStates.PlaceTower;
                    TDSession.thisSession.placementTower = this.Tower;
                }
                // we are already placing a tower, but we changed which tower to place
                else if (TDForm.ThisForm.CursorState == TDForm.CursorStates.PlaceTower)
                {
                    TDSession.thisSession.placementTower = this.Tower;
                }
            }
            else
            {
                TDForm.ThisForm.CursorState = TDForm.CursorStates.Normal;
            }
        }

        private void UnCheckOtherPurchaseButtons()
        {
            UnCheckOtherPurchaseButton(TDForm.ThisForm.btnTower1);
            UnCheckOtherPurchaseButton(TDForm.ThisForm.btnTower2);
            UnCheckOtherPurchaseButton(TDForm.ThisForm.btnTower3);
            UnCheckOtherPurchaseButton(TDForm.ThisForm.btnTower4);
        }

        private void UnCheckOtherPurchaseButton(TDTowerButton other)
        {
            if (other != this &&
                other.Checked)
            {
                other.Checked = false;
            }
        }

        void TDTowerButton_MouseEnter(object sender, EventArgs e)
        {
            // if we have a tower, and we are in the delete tower state, then change cursor
            //if (TDForm.ThisForm.CursorState == TDForm.CursorStates.DeleteTower &&
            //    this.Tower != null)
            //{
            //    Cursor.Current = Cursors.No;
            //}
        }

        void TDTowerButton_MouseLeave(object sender, EventArgs e)
        {
            // go back to the default for the cursor state.
            //TDForm.ThisForm.CursorState = TDForm.ThisForm.CursorState;
        }        
    }
}
