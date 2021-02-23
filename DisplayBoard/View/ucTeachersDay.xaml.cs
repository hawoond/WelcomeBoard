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
    /// ucTeachersDay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucTeachersDay : CommonScreen
    {
        public ucTeachersDay()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.TEACHERS_DAY;
            BindingData = Common.Common.TeachersDayData;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrTeachersDay = Common.Common.GetJsonData(Common.Constants.FILE_KEY.TEACHERS_DAY);
            BindingData.MomModelCollection.Clear();

            // 데이터 넣기
            UdtTeachersDay udtTeachersDay;
            for (int i = 0; i < arrTeachersDay.Count; i++)
            {
                udtTeachersDay = new UdtTeachersDay();
                udtTeachersDay.Message = arrTeachersDay[i][Common.Constants.JSON_KEY.TEACHERS_DAY.DESC];
                BindingData.MomModelCollection.Add(udtTeachersDay);
            }

            this.DataContext = BindingData.MomModelCollection[0];
        }
    }
}
