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
    /// ucWelcomeMessage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucWelcomeMessage : CommonScreen
    {
        public ucWelcomeMessage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.WELCOME_MESSAGE;
            BindingData = Common.Common.WelcomeMessageData;
            lbSchoolNM.Content = Common.Constants.SCHOOL_NM;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrWelcomeMessage = Common.Common.GetJsonData(Common.Constants.FILE_KEY.WELCOME_MESSAGE);
            BindingData.MomModelCollection.Clear();

            // 데이터 넣기
            UdtWelcomeMessage udtWelcomeMessage;
            for (int i = 0; i < arrWelcomeMessage.Count; i++)
            {
                udtWelcomeMessage = new UdtWelcomeMessage();
                udtWelcomeMessage.Message = arrWelcomeMessage[i][Common.Constants.JSON_KEY.WELCOME.DESC];
                BindingData.MomModelCollection.Add(udtWelcomeMessage);
            }

            this.DataContext = BindingData.MomModelCollection[0];

            //lbTest.ItemsSource = BindingData.MomModelCollection;
        }
    }
}
