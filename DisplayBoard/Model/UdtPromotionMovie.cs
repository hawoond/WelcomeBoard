using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtPromotionMovie : MomModel
    {
        private string mFilePath;

        /// <summary>
        /// 영상 파일 경로
        /// </summary>
        public string FilePath
        {
            get => this.mFilePath;
            set
            {
                string[] tempVal = value.Split('\\');

                tempVal[2] = "C:";
                StringBuilder sb = new StringBuilder();
                for (int i=2; i<tempVal.Count(); i++)
                {
                    sb.Append(tempVal[i]);
                    if(i != (tempVal.Count() - 1))
                    {
                        sb.Append("\\");
                    }
                }

                this.mFilePath = sb.ToString();
                this.OnPropertyChanged("FilePath");
            }
        }
    }
}
