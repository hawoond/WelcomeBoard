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
    /// ucFoodMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucFoodMenu : CommonScreen
    {
        List<string> displayFoodMenu = new List<string>();

        public ucFoodMenu()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.FOOD_MENU;
            
            InitData();
        }

        private void InitData()
        {
            BindingData = Common.Common.FoodMenuData;
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrFoodMenu = Common.Common.GetJsonData(Common.Constants.FILE_KEY.FOOD_MENU);

            int nNowTime = int.Parse(DateTime.Now.ToString("HHmm"));

            BindingData.MomModelCollection.Clear();
            // 데이터 넣기
            UdtFoodMenu udtFoodMenu;
            for (int i = 0; i < arrFoodMenu.Count; i++)
            {
                udtFoodMenu = new UdtFoodMenu();
                if (nNowTime > 1300)
                {
                    lbTitle.Content = "저녁 식사";
                    udtFoodMenu.MenuDesc = arrFoodMenu[i][Common.Constants.JSON_KEY.FOOD_MENU.NIGHT_DESC];
                }
                else
                {
                    lbTitle.Content = "점심 식사";
                    udtFoodMenu.MenuDesc = arrFoodMenu[i][Common.Constants.JSON_KEY.FOOD_MENU.DAY_DESC];
                }

                BindingData.MomModelCollection.Add(udtFoodMenu);
            }
            this.DataContext = BindingData.MomModelCollection[0];
        }
    }
}
