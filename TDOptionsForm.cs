using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public partial class TDOptionsForm : Form
    {
        public TDOptionsForm()
        {
            InitializeComponent();
            LoadPriceOptions();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadPriceOptions();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePriceOptions();
        }

        private void LoadPriceOptions()
        {
            nud_BulletSpeed.Value = TDTowerCreator.CostMultiplier_BulletSpeed;
            nud_Damage.Value = TDTowerCreator.CostMultiplier_Damage;
            nud_HP.Value = TDTowerCreator.CostMultiplier_HP;
            nud_Range.Value = TDTowerCreator.CostMultiplier_Range;
            nud_RateOfFire.Value = TDTowerCreator.CostMultiplier_FireRate;
            nud_Seeking.Value = TDTowerCreator.CostMultiplier_Seeking;
            nud_SplashRadius.Value = TDTowerCreator.CostMultiplier_SplashRadius;
            nud_Slow.Value = TDTowerCreator.CostMultiplier_Slow;
            nud_Chaining.Value = TDTowerCreator.CostMultiplier_Chaining;
        }

        private void SavePriceOptions()
        {
            TDTowerCreator.CostMultiplier_BulletSpeed = nud_BulletSpeed.Value;
            TDTowerCreator.CostMultiplier_Damage = nud_Damage.Value;
            TDTowerCreator.CostMultiplier_HP = nud_HP.Value;
            TDTowerCreator.CostMultiplier_Range = nud_Range.Value;
            TDTowerCreator.CostMultiplier_FireRate = nud_RateOfFire.Value;
            TDTowerCreator.CostMultiplier_Seeking = nud_Seeking.Value;
            TDTowerCreator.CostMultiplier_SplashRadius = nud_SplashRadius.Value;
            TDTowerCreator.CostMultiplier_Slow = nud_Slow.Value;
            TDTowerCreator.CostMultiplier_Chaining = nud_Chaining.Value;
        }
    }
}
