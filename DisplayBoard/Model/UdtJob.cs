using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtJob : MomModel
    {
        private string mJobTitle;
        private string mJobInfo;
        private string mJobImage;

        /// <summary>
        /// 직업 이름
        /// </summary>
        public string JobTitle
        {
            get => this.mJobTitle;
            set
            {
                this.mJobTitle = value;
                this.OnPropertyChanged("JobTitle");
            }
        }

        /// <summary>
        /// 직업 정보
        /// </summary>
        public string JobInfo
        {
            get => this.mJobInfo;
            set
            {
                this.mJobInfo = value;
                this.OnPropertyChanged("JobInfo");
            }
        }

        /// <summary>
        /// 직업 이미지
        /// </summary>
        public string JobImage
        {
            get => this.mJobImage;
            set
            {
                string[] tempVal = value.Split('\\');

                tempVal[2] = "C:";
                StringBuilder sb = new StringBuilder();
                for (int i = 2; i < tempVal.Count(); i++)
                {
                    sb.Append(tempVal[i]);
                    if (i != (tempVal.Count() - 1))
                    {
                        sb.Append("\\");
                    }
                }

                this.mJobImage = sb.ToString();
                this.OnPropertyChanged("JobImage");
            }
        }
    }
}
