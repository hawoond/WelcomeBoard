using DisplayBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DisplayBoard.View
{
    /// <summary>
    /// ucCelebration.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucCelebration : CommonScreen
    {
        public ucCelebration()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.CELEBRATION;
            BindingData = Common.Common.CelebrationData;

            lbYear.Content = DateTime.Now.Year.ToString();
            lbSchoolNM.Content = Common.Constants.SCHOOL_NM;

            ((UdtCelebration)BindingData).ArrStudent = new List<UdtStudentInfo>();

            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrBookList = Common.Common.GetJsonData(Common.Constants.FILE_KEY.CELEBRATION);

            // 축하 상태 코드
            ((UdtCelebration)BindingData).State = int.Parse(Common.Common.CELEBRATION_STATE);

            if (((UdtCelebration)BindingData).State == (int)Common.Constants.CelebrationCode.BIRTH_DAY)
            {
                // 보여줄 화면 선택
                gridGraduation.Visibility = Visibility.Collapsed;
                gridBirthday.Visibility = Visibility.Visible;

                // 데이터 넣기
                UdtStudentInfo udtStudentInfo;
                for (int i = 0; i < arrBookList.Count; i++)
                {
                    udtStudentInfo = new UdtStudentInfo();
                    udtStudentInfo.Name = arrBookList[i][Common.Constants.JSON_KEY.CELEBRATION.NAME];
                    udtStudentInfo.Grade = arrBookList[i][Common.Constants.JSON_KEY.CELEBRATION.GRADE];
                    udtStudentInfo.Class = arrBookList[i][Common.Constants.JSON_KEY.CELEBRATION.CLASS];
                    ((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);
                }
            }
            else if(((UdtCelebration)BindingData).State == (int)Common.Constants.CelebrationCode.START_GAME)       //입학
            {
                // 보여줄 화면 선택
                gridGraduation.Visibility = Visibility.Visible;
                gridBirthday.Visibility = Visibility.Collapsed;

                // 메시지 입력
                lbMessage.Content = Properties.Resources.AdmissionMessage;
            }
            else if(((UdtCelebration)BindingData).State == (int)Common.Constants.CelebrationCode.END_GAME)       //졸업
            {
                // 보여줄 화면 선택
                gridGraduation.Visibility = Visibility.Visible;
                gridBirthday.Visibility = Visibility.Collapsed;

                // 메시지 입력
                lbMessage.Content = Properties.Resources.GraduatedMessage;
            }

            #region 가데이터
            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "1";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라라";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "2";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라마";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);

            //udtStudentInfo = new UdtStudentInfo();

            //udtStudentInfo.Grade = "3";
            //udtStudentInfo.Class = "1";
            //udtStudentInfo.Name = "라라다";
            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);


            //((UdtCelebration)BindingData).ArrStudent.Add(udtStudentInfo);
            #endregion

            lbBirthday.ItemsSource = ((UdtCelebration)BindingData).ArrStudent;
        }
    }
}
