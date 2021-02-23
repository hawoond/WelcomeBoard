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
    /// ucConversation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucConversation : CommonScreen
    {
        public ucConversation()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.CONVERSATION;
            BindingData = Common.Common.ConversationData;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrConversationList = Common.Common.GetJsonData(Common.Constants.FILE_KEY.CONVERSATION);

            BindingData.MomModelCollection.Clear();
            // 데이터 넣기
            UdtConversation udtConversation;
            for (int i = 0; i < arrConversationList.Count; i++)
            {
                udtConversation = new UdtConversation();
                udtConversation.ConversationTitle = arrConversationList[i][Common.Constants.JSON_KEY.CONVERSATION.TITLE];
                udtConversation.Translate= arrConversationList[i][Common.Constants.JSON_KEY.CONVERSATION.TRANS];
                BindingData.MomModelCollection.Add(udtConversation);
            }

            this.DataContext = BindingData.MomModelCollection[0];

            //lbTest.ItemsSource = BindingData.MomModelCollection;
        }
    }
}
