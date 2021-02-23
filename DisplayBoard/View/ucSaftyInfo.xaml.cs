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
    /// ucSaftyInfo.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucSaftyInfo : CommonScreen
    {
        public ucSaftyInfo()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.SAFTY_INFO;
            BindingData = Common.Common.SaftyInfoData;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrSaftyInfo = Common.Common.GetJsonData(Common.Constants.FILE_KEY.SAFTY_INFO);
            BindingData.MomModelCollection.Clear();

            // 데이터 넣기
            UdtSaftyInfo udtSaftyInfo;
            for (int i = 0; i < arrSaftyInfo.Count; i++)
            {
                udtSaftyInfo = new UdtSaftyInfo();
                udtSaftyInfo.SaftyTitle = arrSaftyInfo[i][Common.Constants.JSON_KEY.SAFTY_INFO.TITLE];
                udtSaftyInfo.SaftyDesc = arrSaftyInfo[i][Common.Constants.JSON_KEY.SAFTY_INFO.DESC];
                BindingData.MomModelCollection.Add(udtSaftyInfo);
            }

            this.DataContext = BindingData.MomModelCollection[0];

            //lbTest.ItemsSource = BindingData.MomModelCollection;
        }
    }
}
