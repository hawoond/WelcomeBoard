using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtSaftyInfo : MomModel
    {
        private string mSaftyTitle;
        private string mSaftyDesc;

        /// <summary>
        /// 안전 정보 제목
        /// </summary>
        public string SaftyTitle
        {
            get => mSaftyTitle;
            set
            {
                this.mSaftyTitle = value;
                this.OnPropertyChanged("SafryTitle");
            }
        }

        /// <summary>
        /// 안정 정보 내용
        /// </summary>
        public string SaftyDesc
        {
            get => mSaftyDesc;
            set
            {
                this.mSaftyDesc = value;
                this.OnPropertyChanged("SaftyDesc");
            }
        }

    }
}
