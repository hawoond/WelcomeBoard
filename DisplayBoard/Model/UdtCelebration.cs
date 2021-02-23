using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtCelebration : MomModel 
    {
        private int mState;
        private List<UdtStudentInfo> mArrStudent;

        /// <summary>
        /// 상태
        /// true : 입학, false : 졸업
        /// </summary>
        public int State
        {
            get => this.mState;
            set
            {
                this.mState = value;
                this.OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// 학생 정보 리스트
        /// </summary>
        public List<UdtStudentInfo> ArrStudent
        {
            get
            {
                if(this.mArrStudent == null)
                {
                    mArrStudent = new List<UdtStudentInfo>();
                }
                return this.mArrStudent;
            }
            set
            {
                this.mArrStudent = value;
                this.OnPropertyChanged("ArrStudent");
            }
        }

    }
}
