using DisplayBoard.View;
using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.ViewModel
{
    public class MainViewModel
    {
        /// <summary>
        /// 현재 띄워진 화면 인덱스
        /// </summary>
        public Common.Constants.SCREEN_INDEX CurrentScreen;

        public CommonScreen ScreenControl;

        /// <summary>
        /// 싱글턴 객체
        /// </summary>
        private static MainViewModel instance;
        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainViewModel();
                }
                return instance;
            }
        }
        public MainViewModel()
        {
            Init();
        }
        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            Common.Common common = Common.Common.Instance;
        }

        private void InitScreenData(MomViewModel ScreenData)
        {

        }

        /// <summary>
        /// 현재 화면으로 저장
        /// </summary>
        /// <param name="ScreenCode"></param>
        private void InitScreen(string ScreenCode)
        {
            Assembly creator = Assembly.GetExecutingAssembly();
            object obj = creator.CreateInstance("DisplayBoard.View."+ScreenCode);

            ScreenControl = obj as CommonScreen;

            #region 안되면 이거 쓰기
            //switch (eScreen)
            //{
            //    case Common.Constants.ScreenIndex.Book:
            //    {
            //        ScreenControl = new ucBook();
            //        break;
            //    }
            //    case Common.Constants.ScreenIndex.Celebration:
            //    {
            //        ScreenControl = new ucCelebration();
            //        break;
            //    }
            //    case Common.Constants.ScreenIndex.Conversation:
            //    {
            //        ScreenControl = new ucConversation();
            //        break;
            //    }
            //    case Common.Constants.ScreenIndex.FoodMenu:
            //    {
            //        ScreenControl = new ucFoodMenu();
            //        break;
            //    }
            //    default :
            //    {

            //        break;
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// 스크린별 시간 세팅
        /// </summary>
        /// <param name="TimerInterval"></param>
        public void ScreenTimer(Common.Constants.SCREEN_INDEX eScreen)
        {

        }

        /// <summary>
        /// 스크린 별 데이터 가져오기
        /// </summary>
        /// <param name="ScreenKind"></param>
        public void GetData(Common.Constants.SCREEN_INDEX eScreen)
        {

        }

        /// <summary>
        /// 현재 스크린 저장
        /// </summary>
        /// <param name="eScreen"></param>
        private void SetScreen(Common.Constants.SCREEN_INDEX eScreen)
        {
            CurrentScreen = eScreen;
        }

    }
}
