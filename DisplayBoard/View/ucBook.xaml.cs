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
    /// ucBook.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucBook : CommonScreen
    {
        public ucBook()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.BOOK;
            BindingData.MomModelCollection = Common.Common.BookData.MomModelCollection;
            //SetData(Common.Common.BookData); 
            //BindingData.MomModelCollection.

            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrBookList = Common.Common.GetJsonData(Common.Constants.FILE_KEY.BOOK);

            // 데이터 넣기
            UdtBook udtBook;
            BindingData.MomModelCollection.Clear();
            for (int i = 0; i < arrBookList.Count; i++)
            {
                udtBook = new UdtBook();
                udtBook.BookTitle  = arrBookList[i][Common.Constants.JSON_KEY.BOOK.TITLE];
                udtBook.BookInfo = arrBookList[i][Common.Constants.JSON_KEY.BOOK.AUTH];
                udtBook.BookDesc = arrBookList[i][Common.Constants.JSON_KEY.BOOK.DESC];
                udtBook.BookImg = arrBookList[i][Common.Constants.JSON_KEY.BOOK.IMAGE];
                BindingData.MomModelCollection.Add(udtBook);
            }

            lbTest.ItemsSource = BindingData.MomModelCollection;
        }


        public override bool SetData(IMRUtils.WPF.MomModel model)
        {
            base.SetData(model);
            return true;
        }

    }
}
