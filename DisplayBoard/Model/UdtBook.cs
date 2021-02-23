using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtBook : MomModel
    {
        private string mBookTitle;
        private string mBookInfo;
        private string mBookDesc;
        private string mBookImg;

        /// <summary>
        /// 책 이름
        /// </summary>
        public string BookTitle
        {
            get => mBookTitle;
            set
            {
                this.mBookTitle = value;
                this.OnPropertyChanged("BookTitle");
            }
        }

        /// <summary>
        /// 책 정보
        /// </summary>
        public string BookInfo
        {
            get => mBookInfo;
            set
            {
                this.mBookInfo = value;
                this.OnPropertyChanged("BookInfo");
            }
        }

        /// <summary>
        /// 책 소개
        /// </summary>
        public string BookDesc
        {
            get => mBookDesc;
            set
            {
                this.mBookDesc = value;
                this.OnPropertyChanged("BookDesc");
            }
        }

        /// <summary>
        /// 이미지
        /// </summary>
        public string BookImg
        {
            get => mBookImg;
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

                this.mBookImg = sb.ToString();
                this.OnPropertyChanged("BookImg");
            }
        }
    }
}
