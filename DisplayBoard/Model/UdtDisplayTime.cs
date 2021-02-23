using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtDisplayTime : MomModel
    {
        private DateTime mStartTime;
        private DateTime mEndTime;

        public DateTime StartTime
        {
            get => mStartTime;
            set
            {
                this.mStartTime = value;
                this.OnPropertyChanged("StartTime");
            }
        }
        
        public DateTime EndTime
        {
            get => mEndTime;
            set
            {
                this.mEndTime = value;
                this.OnPropertyChanged("EndTime");
            }
        }
    }
}
