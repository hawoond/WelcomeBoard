using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtStudentInfo : MomModel
    {
        private string mName;
        private string mGrade;
        private string mClass;

        /// <summary>
        /// 학생 이름
        /// </summary>
        public string Name
        {
            get => this.mName;
            set
            {
                this.mName = value;
                this.OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// 학년
        /// </summary>
        public string Grade
        {
            get => this.mGrade;
            set
            {
                this.mGrade = value;
                this.OnPropertyChanged("Grade");
            }
        }

        /// <summary>
        /// 반
        /// </summary>
        public string Class
        {
            get => this.mClass;
            set
            {
                this.mClass = value;
                this.OnPropertyChanged("Class");
            }
        }
    }
}
