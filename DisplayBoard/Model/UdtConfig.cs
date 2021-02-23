using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtConfig : MomModel
    {
        private List<Common.Constants.SCREEN_INDEX> mScreenFlow;
        private string mSchoolName;
        private int mScreenInterval;
        private string mCurrentDate;
        private Dictionary<Common.Constants.SCREEN_INDEX, UdtDisplayTime> mArrDisplayTime;

        public List<Common.Constants.SCREEN_INDEX> ScreenFlow
        {
            get => mScreenFlow;
            set
            {
                this.mScreenFlow = value;
                this.OnPropertyChanged("ScreenFlow");
            }
        }
        public string SchoolName
        {
            get => mSchoolName;
            set
            {
                this.mSchoolName = value;
                this.OnPropertyChanged("SchoolName");
            }
        }
        public int ScreenInterval
        {
            get => mScreenInterval;
            set
            {
                this.mScreenInterval = value;
                this.OnPropertyChanged("ScreenInterval");
            }
        }
        public string CurrentDate
        {
            get => mCurrentDate;
            set
            {
                this.mCurrentDate = value;
                this.OnPropertyChanged("CurrentDate");
            }
        }
        public Dictionary<Common.Constants.SCREEN_INDEX, UdtDisplayTime> ArrDisplayTime
        {
            get => mArrDisplayTime;
            set
            {
                this.mArrDisplayTime = value;
                this.OnPropertyChanged("ArrDisplayTime");
            }
        }

    }
}
