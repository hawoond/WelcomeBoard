using DisplayBoard.Model;
using IMRUtils.WPF;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Common
{
    public class Common
    {
        public static UdtPromotionMovie PromotionMovieData;
        public static UdtWeather WeatherData;
        public static UdtConversation ConversationData;
        public static UdtBook BookData;
        public static UdtJob JobData;
        public static UdtCelebration CelebrationData;
        public static UdtWelcomeMessage WelcomeMessageData;
        public static UdtTeachersDay TeachersDayData;
        public static UdtSaftyInfo SaftyInfoData;
        public static UdtFoodMenu FoodMenuData;

        public static IMRUtils.Utils utils;

        public static Dictionary<string, MomModel> ALL_DATA_COLLECTION;

        /// <summary>
        /// 싱글턴 객체
        /// </summary>
        private static Common instance;
        public static Common Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Common();
                }
                return instance;
            }
        }

        public Common()
        {
            utils = new IMRUtils.Utils();
            ALL_DATA_COLLECTION = new Dictionary<string, MomModel>();

            if (PromotionMovieData == null)
            {
                PromotionMovieData = new UdtPromotionMovie();
                ALL_DATA_COLLECTION.Add("PromotionMovie", PromotionMovieData);
            }
            if (WeatherData == null)
            {
                WeatherData = new UdtWeather();
                ALL_DATA_COLLECTION.Add("Weather", WeatherData);
            }
            if (ConversationData == null)
            {
                ConversationData = new UdtConversation();
                ALL_DATA_COLLECTION.Add("Conversation", ConversationData);
            }
            if (BookData == null)
            {
                BookData = new UdtBook();
                ALL_DATA_COLLECTION.Add("Book", BookData);
            }
            if (JobData == null)
            {
                JobData = new UdtJob();
                ALL_DATA_COLLECTION.Add("Job", JobData);
            }
            if (CelebrationData == null)
            {
                CelebrationData = new UdtCelebration();
                ALL_DATA_COLLECTION.Add("Celebration", CelebrationData);
            }
            if (WelcomeMessageData == null)
            {
                WelcomeMessageData = new UdtWelcomeMessage();
                ALL_DATA_COLLECTION.Add("WelcomeMessage", WelcomeMessageData);
            }
            if (TeachersDayData == null)
            {
                TeachersDayData = new UdtTeachersDay();
                ALL_DATA_COLLECTION.Add("TeachersDay", TeachersDayData);
            }
            if (SaftyInfoData == null)
            {
                SaftyInfoData = new UdtSaftyInfo();
                ALL_DATA_COLLECTION.Add("SaftyInfo", SaftyInfoData);
            }
            if (FoodMenuData == null)
            {
                FoodMenuData = new UdtFoodMenu();
                ALL_DATA_COLLECTION.Add("FoodMenu", FoodMenuData);
            }
        }

        /// <summary>
        /// 공유폴더에 있는 파일 가져오기 함수
        /// </summary>
        public void FileIO()
        {
            // 공유 폴더 내부의 파일리스트 가져오기(key : FileName, value : FilePath)
            Dictionary<string, string> dicFileList = utils.GetFileList(Properties.Resources.SharedFolder);

            foreach (Constants.SCREEN_INDEX FileNames in Enum.GetValues(typeof(Constants.SCREEN_INDEX)))
            {
                string sEnumName = FileNames.ToString();
                string sReadResult = string.Empty;

                sReadResult = System.IO.File.ReadAllText(dicFileList[sEnumName]);

                DataSet dsResult = IMRUtils.TypeParser.XmlToDataSet(sReadResult);

                foreach (var fieldName in ALL_DATA_COLLECTION[sEnumName].GetType().GetFields())
                {
                    // 없는 key 예외처리 필요

                    // 데이터 저장
                    ALL_DATA_COLLECTION[sEnumName].GetType().GetField(fieldName.ToString()).SetValue(fieldName.ToString(), dsResult.Tables[0].Rows[0][fieldName.ToString()].ToString());
                }

                //(ALL_DATA_COLLECTION[sEnumName].GetType())ALL_DATA_COLLECTION[sEnumName] = dsResult.Tables[0].Rows[0][""].ToString();
            }

        }

        /// <summary>
        /// 자동 시작 등록(시작프로그램)
        /// </summary>
        public void AutoStart()
        {
            string sAppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(sAppName, Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName);
        }

        /// <summary>
        /// 업데이트 파일 체크
        /// </summary>
        /// <returns></returns>
        public bool UpdateFileCheck()
        {
            bool isSuccess = false;

            return isSuccess;
        }

        /// <summary>
        /// 업데이트 함수
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            bool isSuccess = false;


            return isSuccess;
        }

        /// <summary>
        /// 업데이트 중 파일 복사 함수
        /// </summary>
        /// <param name="eStartState">시작 상태</param>
        /// <returns></returns>
        public bool FileCopy(int eStartState)
        {
            bool isSuccess = false;


            return isSuccess;
        }

        /// <summary>
        /// 업데이트 중 프로세스 시작 함수
        /// </summary>
        /// <param name="sProcessName">시작 할 프로세스 이름</param>
        /// <returns></returns>
        public bool StartProcess(string sProcessName)
        {
            bool isSuccess = false;


            return isSuccess;
        }

        /// <summary>
        /// 0 : 생일, 1 : 입학, 2 : 졸업
        /// </summary>
        public static string CELEBRATION_STATE = "0";

        /// <summary>
        /// JsonData 가져오기
        /// </summary>
        /// <param name="sUdtName">Common.Constants.FILE_KEY</param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> GetJsonData(string sUdtName)
        {
            IMRUtils.Utils utils = new IMRUtils.Utils();

            // JSON 파싱
            Dictionary<string, string> dicFileList = utils.GetFileList(Properties.Settings.Default.PATH_JSON);
            string sPath = string.Empty;
            try
            {
                sPath = dicFileList[sUdtName];
            }
            catch (Exception ex)
            {
                return null;
            }
            // 파일 읽어오기
            Dictionary<string, string> dicResult = IMRUtils.TypeParser.JsonToDictionary(System.IO.File.ReadAllText(sPath));

            // 축하 코드 구분
            if (sUdtName.Equals(Constants.FILE_KEY.CELEBRATION))
            {
                CELEBRATION_STATE = dicResult["STATE"];
            }

            // 최종 파싱
            List<Dictionary<string, string>> arrBookList = IMRUtils.TypeParser.JsonArrayToDictionary(dicResult[Constants.GetJsonKey(sUdtName)]);

            return arrBookList;
        }


        /// <summary>
        /// 스크린 순서 가져오기
        /// </summary>
        /// <returns></returns>
        public static List<string> GetScreenFlow()
        {

            List<string> arrResult = new List<string>();
            List<Dictionary<string, string>> arrScreenFlow = new List<Dictionary<string, string>>();

            arrScreenFlow = GetJsonData(Constants.FILE_KEY.SCREEN_FLOW);

            if (null == arrScreenFlow)
            {
                return null;
            }

            //int i = 0;
            //foreach (var item in arrScreenFlow[0])
            //{
            //    item.Key
            //}

            var items = from pair in arrScreenFlow[0]
                        orderby pair.Value ascending
                        select pair;

            foreach (KeyValuePair<string, string> pair in items)
            {
                if (!string.Empty.Equals(pair.Value))
                {
                    arrResult.Add(pair.Key);
                }
            }

            return arrResult;
        }

        public static string GetScreenPath(string sName)
        {
            // 결과 변수
            string sResult = string.Empty;

            // 가져올 클래스
            Constants.ScreenPath screenPath = new Constants.ScreenPath();

            Type tp = screenPath.GetType();
            FieldInfo[] flds = tp.GetFields(BindingFlags.Instance |
                                            BindingFlags.Static |
                                            BindingFlags.Public |
                                            BindingFlags.NonPublic);
            foreach (var f in flds)
            {
                object point = f.GetValue(screenPath);
                if (point is string)
                {
                    if (sName.Equals(f.Name))
                    {
                        sResult = point.ToString();
                    }
                }
            }

            return sResult;
        }
    }
}
