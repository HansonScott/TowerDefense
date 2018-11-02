using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TowerDefense
{
    public enum TDEffectTypes
    {
        WaveDelay, // hold enemy back at the beginning.
        Slow, // speed reduction
        Poison, // hp damage on update
        Stun, // speed = 0, fire rate paused
        Retreat, // speed backwards (need to work with pathing backwards though)
    }

    public class TDEffect: Timer
    {
        public enum TDTimerState
        {
            NotStartedYet,
            Running,
            Paused,
            Finished,
        }

        private TDTimerState _State = TDTimerState.NotStartedYet;
        private TimeSpan _Duration;
        private DateTime ResumeWhen;
        private DateTime PauseWhen;
        private DateTime ChangeSpeedWhen;

        public TDEffectTypes Effect;
        public decimal Power;

        public bool HasBeenApplied = false;

        public TimeSpan Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                this._Duration = value;
                if (value.TotalMilliseconds > 0)
                {
                    // NOTE: this resets the entire duration!
                    base.Interval = value.TotalMilliseconds;
                }
            }
        }
        public TimeSpan DurationRemaining
        {
            get
            {
                TimeSpan results = new TimeSpan();

                if (PauseWhen == new DateTime()) // if have not paused yet
                {
                    results = this.Duration - (DateTime.Now - ChangeSpeedWhen); // resumeWhen = startWhen if not paused yet
                }
                else // have paused already
                {
                    // get the more recent - either a pause or a speed change
                    DateTime recentChange = ResumeWhen;
                    if (ChangeSpeedWhen > ResumeWhen)
                    {
                        recentChange = ChangeSpeedWhen;
                    }

                    if (TDSession.thisSession.Paused)
                    {
                        // we are currently paused, then the remaining time is what is left after the accumulated running duration
                        results = this.Duration - (PauseWhen - recentChange);// the resumeWhen was the previous resume, or start.
                    }
                    else // we are currently running
                    {
                        results = this.Duration - (DateTime.Now - recentChange);
                    }
                }

                return results;
            }
        }

        public TDTimerState State
        {
            get { return _State; }
            set
            {
                HandleStateChange(_State, value);
                _State = value;
            }
        }

        public TDEffect(TDEffectTypes e, decimal power, TimeSpan duration, bool StartImmediately)
        {
            base.AutoReset = false;
            base.Elapsed += TDTimer_Elapsed;

            this.Effect = e;
            this.Power = power;
            this.Duration = duration;

            if (StartImmediately)
            {
                base.Start();
                Resume();
            }
        }

        void TDTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // the timer was running, and the duration elapsed.
            if (this.State == TDTimerState.Running)
            {
                this.State = TDTimerState.Finished;
            }
        }

        new public void Start()
        {
            //base.Start(); // called in the resume function
            Resume();
        }
        public void Pause()
        {
            if (this.State == TDTimerState.Running)
            {
                this.State = TDTimerState.Paused;
            }
        }
        public void Resume()
        {
            if (this.State == TDTimerState.NotStartedYet)
            {
                base.Start();
                if (ResumeWhen == new DateTime())
                {
                    ResumeWhen = DateTime.Now;
                }

                this.State = TDTimerState.Running;
            }
            else if (this.State == TDTimerState.Paused)
            {
                this.State = TDTimerState.Running;
            }
            this.ChangeSpeedWhen = DateTime.Now;
        }

        private void HandleStateChange(TDTimerState oldState, TDTimerState newState)
        {
            // if same state, ignore
            if (oldState == newState) { return; }

            if (oldState == TDTimerState.Finished) { return; } // never switch away from finished.

            // otherwise do something based on the new state
            switch (newState)
            {
                case TDTimerState.Finished:
                    // timer has finished                
                    break;
                case TDTimerState.Paused:
                    // user has paused the game, so pause this timer
                    PauseWhen = DateTime.Now;
                    //base.Enabled = false;
                    break;

                case TDTimerState.Running:
                    if (oldState == TDTimerState.NotStartedYet)
                    {
                        // starting for first time
                    }
                    else if (oldState == TDTimerState.Paused)
                    {
                        // set the remaining duration because the timer starts over
                        this.Duration = new TimeSpan(0,0,0,0,(int)Math.Max(0, DurationRemaining.TotalMilliseconds));
                    }

                    // and set the resumeWhen time for future state changes
                    ResumeWhen = DateTime.Now;
                    
                    break;
                case TDTimerState.NotStartedYet: // should never get here
                default:
                    break;
            }
        }

        internal void AdjustDuration(double OldSpeedFactor, double NewSpeedFactor)
        {
            if (State == TDEffect.TDTimerState.Finished || 
                DurationRemaining.TotalMilliseconds < 0) { return; }

            Duration = TimeSpan.FromTicks((long)(DurationRemaining.Ticks * (OldSpeedFactor / NewSpeedFactor)));
            ChangeSpeedWhen = DateTime.Now;
        }
    }
}
