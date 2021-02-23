using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Common
{
    public static class Constants
    {
        public static string SCHOOL_NM = "기본고등학교";
        public static int INTERVAL = 6;

        public enum SCREEN_INDEX
        {
            PROMOTION_MOVIE,
            WEATHER,
            CONVERSATION,
            BOOK,
            JOB,
            CELEBRATION,
            WELCOME_MESSAGE,
            TEACHERS_DAY,
            SAFTY_INFO,
            FOOD_MENU
        }

        /// <summary>
        /// 날씨 코드
        /// </summary>
        public static class WEATHER_CODE
        {
            public const string CLEAR = "맑음";
            public const string PARTLY_CLOUDY = "구름 조금";
            public const string MOSTLY_CLOUDY = "구름 많음";
            public const string CLOUDY = "흐림";
            public const string RAIN = "비";
            public const string SNOW_RAIN = "눈/비";
            public const string SNOW = "눈";
        }

        /// <summary>
        /// 미세먼지 코드
        /// </summary>
        public static class DUST_CODE
        {
            public const string GOOD = "좋음";
            public const string NORMAL = "보통";
            public const string BAD = "나쁨";
            public const string VERYBAD = "매우 나쁨";
        }

        public enum CelebrationCode
        {
            NONE,
            BIRTH_DAY,
            START_GAME,
            END_GAME         //타노스                     
        }

        /// <summary>
        /// 스크린 유저컨트롤 이름
        /// </summary>
        public static class SCREEN_CODE
        {
            public const string PROMOTION_MOVIE = "ucPromotionMovie";
            public const string WEATHER = "ucWeather";
            public const string CONVERSATION = "ucConversation";
            public const string BOOK = "ucBook";
            public const string JOB = "ucJob";
            public const string CELEBRATION = "ucCelebration";
            public const string WELCOME_MESSAGE = "ucWelcomeMessage";
            public const string TEACHERS_DAY = "ucTeachersDay";
            public const string SAFTY_INFO = "ucSaftyInfo";
            public const string FOOD_MENU = "ucFoodMenu";
        }

        public static class FILE_KEY
        {
            public const string PROMOTION_MOVIE = "UDTPROMOTIONMOVIE";
            public const string WEATHER = "UDTWEATHER";
            public const string CONVERSATION = "UDTCONVERSATION";
            public const string BOOK = "UDTBOOK";
            public const string JOB = "UDTJOB";
            public const string CELEBRATION = "UDTCELEBRATION";
            public const string WELCOME_MESSAGE = "UDTWELCOMEMESSAGE";
            public const string TEACHERS_DAY = "UDTTEACHERSDAY";
            public const string SAFTY_INFO = "UDTSAFTYINFO";
            public const string FOOD_MENU = "UDTFOODMENU";
            public const string SCREEN_FLOW = "UDTSCREENFLOW";
            public const string CONFIG = "UDTCONFIG";
        }

        public static class JSON_KEY
        {
            public static class BOOK
            {
                public const string KEY = "BOOK_LIST";

                public const string TITLE = "TITLE";
                public const string IMAGE = "IMAGE";
                public const string DESC = "DESC";
                public const string AUTH = "AUTH";

            }
            public static class CELEBRATION
            {
                public const string KEY = "CELEBRATION_LIST";

                public const string GRADE = "GRADE";
                public const string CLASS = "CLASS";
                public const string NAME = "NAME";
            }

            public static class CONVERSATION
            {
                public const string KEY = "CONVERSATION_LIST";

                public const string TITLE = "TITLE";
                public const string TRANS = "TRANSLATE";
            }

            public static class FOOD_MENU
            {
                public const string KEY = "MENU_LIST";

                public const string DAY_DESC = "DAY_DESC";
                public const string NIGHT_DESC = "NIGHT_DESC";
                public const string MENU_DATE = "MENU_DATE";
            }

            public static class JOB
            {
                public const string KEY = "JOB_LIST";

                public const string TITLE = "TITLE";
                public const string INFO = "INFO";
                public const string IMAGE = "IMAGE";
            }

            public static class PROMOTIONMOVIE
            {
                public const string KEY = "MOVIE_LIST";

                public const string FILEPATH = "FILEPATH";
            }

            public static class SAFTY_INFO
            {
                public const string KEY = "SAFTY_LIST";

                public const string TITLE = "TITLE";
                public const string DESC = "DESC";
            }

            public static class TEACHERS_DAY
            {
                public const string KEY = "MESSAGE";

                public const string DESC = "DESC";
            }

            public static class WEATHER
            {
                public const string KEY = "WEATHER_LIST";

                public const string DESC = "DESC";
                public const string STATE = "STATE";
                public const string TEMP = "TEMP";
                public const string SENS_TEMP = "SENS_TEMP";
                public const string FINE_DUST = "FINE_DUST";
                public const string ULTRA_FINE_PARTICLE = "ULTRA_FINE_PARTICLE";
                public const string POP = "POP";
            }

            public static class WELCOME
            {
                public const string KEY = "WELC_MESSAGE_LIST";

                public const string DESC = "DESC";
            }

            public static class SCREEN_FLOW
            {
                public const string KEY = "SCREEN_FLOW_LIST";

                public const string PRMO_SEQ = "PROMOTION_MOVIE";
                public const string WETH_SEQ = "WEATHER";
                public const string CONV_SEQ = "CONVERSATION";
                public const string BOOK_SEQ = "BOOK";
                public const string JOB_SEQ = "JOB";
                public const string CELE_SEQ = "CELEBRATION";
                public const string SAFE_SEQ = "SAFTY_INFO";
                public const string MENU_SEQ = "FOOD_MENU";
                public const string TCDY_SEQ = "TEACHERS_DAY";
                public const string WELC_SEQ = "WELCOME_MESSAGE";
            }

            public static class CONFIG
            {
                public const string KEY = "CONFIG";

                public const string SCH_NM = "SCH_NM";
                public const string SCR_INTERVAL = "SCR_INTERVAL";
            }
        }

        public static string GetJsonKey(string sFileKey)
        {
            string sResult = string.Empty;

            switch (sFileKey)
            {
                case FILE_KEY.BOOK:
                {
                    sResult = JSON_KEY.BOOK.KEY;
                    break;
                }
                case FILE_KEY.CELEBRATION:
                {
                    sResult = JSON_KEY.CELEBRATION.KEY;
                    break;
                }
                case FILE_KEY.CONVERSATION:
                {
                    sResult = JSON_KEY.CONVERSATION.KEY;
                    break;
                }
                case FILE_KEY.FOOD_MENU:
                {
                    sResult = JSON_KEY.FOOD_MENU.KEY;
                    break;
                }
                case FILE_KEY.JOB:
                {
                    sResult = JSON_KEY.JOB.KEY;
                    break;
                }
                case FILE_KEY.PROMOTION_MOVIE:
                {
                    sResult = JSON_KEY.PROMOTIONMOVIE.KEY;
                    break;
                }
                case FILE_KEY.SAFTY_INFO:
                {
                    sResult = JSON_KEY.SAFTY_INFO.KEY;
                    break;
                }
                case FILE_KEY.TEACHERS_DAY:
                {
                    sResult = JSON_KEY.TEACHERS_DAY.KEY;
                    break;
                }
                case FILE_KEY.WEATHER:
                {
                    sResult = JSON_KEY.WEATHER.KEY;
                    break;
                }
                case FILE_KEY.WELCOME_MESSAGE:
                {
                    sResult = JSON_KEY.WELCOME.KEY;
                    break;
                }
                case FILE_KEY.SCREEN_FLOW:
                {
                    sResult = JSON_KEY.SCREEN_FLOW.KEY;
                    break;
                }
                case FILE_KEY.CONFIG:
                {
                    sResult = JSON_KEY.CONFIG.KEY;
                    break;
                }
                default:
                {
                    break;
                }

            }


            return sResult;
        }

        public class ScreenPath
        {
            public const string TCDY_SEQ = "/View/ucTeachersDay.xaml";
            public const string BOOK_SEQ = "/View/ucBook.xaml";
            public const string CELE_SEQ= "/View/ucCelebration.xaml";
            public const string CONV_SEQ = "/View/ucConversation.xaml";
            public const string MENU_SEQ= "/View/ucFoodMenu.xaml";
            public const string JOB_SEQ = "/View/ucJob.xaml";
            public const string SAFE_SEQ = "/View/ucSaftyInfo.xaml";
            public const string WETH_SEQ = "/View/ucWeather.xaml";
            public const string WELC_SEQ = "/View/ucWelcomeMessage.xaml";
            public const string PROM_SEQ = "/View/ucPromotionMovie.xaml";
        }
    }
}
