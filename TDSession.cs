using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    public class TDSession
    {
        public static int StartingGold = 300;
        public static double SpeedFactor = 0.1; // normal
        public static TDSession thisSession;

        static bool ShouldContinue = true;

        private int _gold;
        public int gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                TDForm.ThisForm.SetLabelText(TDForm.ThisForm.lblGold, value.ToString());

                // reset purchasable buttons
                TDForm.ThisForm.ResetPurchaseButtons();
            }
        }
        public TDLevel CurrentLevel;

        private SessionSpeed _Speed;
        private bool _Paused = true;
        public bool Paused
        {
            get { return _Paused; }
            set
            {
                bool oldValue = this._Paused;
                if (value == true && oldValue == false) // pause
                {
                    _Paused = value;

                    // pause all effects
                    if (this.CurrentLevel != null)
                    {
                        this.CurrentLevel.PauseAllEffects();
                    }
                }
                else if (value == false && oldValue == true) // unpause
                {
                    _Paused = value;

                    // resume all effects
                    this.CurrentLevel.ResumeAllEffects();
                }
                else
                {
                    // same old and new values, do nothing?
                }
            }
        }
        public SessionSpeed Speed
        {
            get { return _Speed; }
            set
            {
                // store the old value for comparison
                double oldVal = TDSession.SpeedFactor;

                // capture and translate the new value
                _Speed = value;
                TDSession.SpeedFactor = ((int)value / 100.0);

                // reset the visuals for this speed
                TDForm.ThisForm.ResetSpeedButtonFont();

                // make sure we have a current level to edit
                if (this.CurrentLevel != null)
                {
                    // adjust duration of all effects according to the new speed factor
                    this.CurrentLevel.AdjustEffectDurations(oldVal, TDSession.SpeedFactor);
                }
            }
        }
        public enum SessionSpeed
        {
            Normal = 10,
            Fast = 30,
            SuperFast = 100,
        }

        public TDSession()
        {
            thisSession = null;
            gold = StartingGold;
            TDForm.ThisForm.btnNewTower.Enabled = true;
            CurrentLevel = new TDLevel(1);
            Paused = true;
            thisSession = this;
        }

        public void Play()
        {
            DateTime LastFrame = DateTime.Now;
            ShouldContinue = true;

            while (ShouldContinue && CurrentLevel != null)
            {
                // update
                if (!Paused)
                {
                    // go through the level's objects and update them all.
                    CurrentLevel.Update();
                }

                // delay looping for frame rate control
                int delayMS = (int)Math.Max(0, ((1000 / TDForm.MaxFPS) - (DateTime.Now - LastFrame).TotalMilliseconds));

                if (delayMS > 0)
                {
                    Thread.Sleep(delayMS);
                }

                LastFrame = DateTime.Now;
            }
        }

        internal void AdvanceLevel()
        {
            gold = TDSession.StartingGold;
            Paused = true;
            if (TDResources.Maps.Length > CurrentLevel.Level)
            {
                CurrentLevel = new TDLevel(CurrentLevel.Level + 1);
            }
        }

        internal void End()
        {
            Paused = true;
            ShouldContinue = false;

            this.CurrentLevel = null;
        }
    }
}
