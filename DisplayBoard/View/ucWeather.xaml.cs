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
    /// ucWeather.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucWeather : CommonScreen
    {
        public ucWeather()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.WEATHER;
            BindingData = Common.Common.WeatherData;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrWeather = Common.Common.GetJsonData(Common.Constants.FILE_KEY.WEATHER);
            BindingData.MomModelCollection.Clear();

            // 데이터 넣기
            UdtWeather udtWeather;
            for (int i = 0; i < arrWeather.Count; i++)
            {
                udtWeather = new UdtWeather();
                string[] weahterDesc = arrWeather[i][Common.Constants.JSON_KEY.WEATHER.DESC].Split('★');
                udtWeather.WeatherDesc_temp = weahterDesc[0];
                udtWeather.WeatherDesc_state = weahterDesc[1];
                udtWeather.WeatherState = SetWeatherIcon(arrWeather[i][Common.Constants.JSON_KEY.WEATHER.STATE]);
                udtWeather.UltrafineParticle= arrWeather[i][Common.Constants.JSON_KEY.WEATHER.ULTRA_FINE_PARTICLE];
                udtWeather.UltrafineParticle_icon = SetFineDustIcon(udtWeather.UltrafineParticle);
                udtWeather.Temperature = arrWeather[i][Common.Constants.JSON_KEY.WEATHER.TEMP];
                udtWeather.SensibleTemp = arrWeather[i][Common.Constants.JSON_KEY.WEATHER.SENS_TEMP];
                udtWeather.Pop = arrWeather[i][Common.Constants.JSON_KEY.WEATHER.POP];
                udtWeather.FineDust = arrWeather[i][Common.Constants.JSON_KEY.WEATHER.FINE_DUST];
                udtWeather.FineDust_icon = SetFineDustIcon(udtWeather.FineDust);
                BindingData.MomModelCollection.Add(udtWeather);
            }
            this.DataContext = BindingData.MomModelCollection[0];
            //lbTest.ItemsSource = BindingData.MomModelCollection;
        }

        /// <summary>
        /// 날씨 아이콘 세팅
        /// </summary>
        /// <param name="sWeatherCode"></param>
        /// <returns></returns>
        private string SetWeatherIcon(string sWeatherCode)
        {
            string sReturn = "";

            switch (sWeatherCode)
            {
                case Common.Constants.WEATHER_CODE.CLEAR:
                    {
                        sReturn = "/Resources/weather_imagesource_icon1.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.CLOUDY:
                    {
                        sReturn = "/Resources/weather_imagesource_icon2.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.MOSTLY_CLOUDY:
                    {
                        sReturn = "/Resources/weather_imagesource_icon4.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.PARTLY_CLOUDY:
                    {
                        sReturn = "/Resources/weather_imagesource_icon3.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.RAIN:
                    {
                        sReturn = "/Resources/weather_imagesource_icon6.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.SNOW:
                    {
                        sReturn = "/Resources/weather_imagesource_icon7.png";
                        break;
                    }
                case Common.Constants.WEATHER_CODE.SNOW_RAIN:
                    {
                        sReturn = "/Resources/weather_imagesource_icon11.png";
                        break;
                    }
                default:
                    {
                        sReturn = "/Resources/weather_imagesource_icon1.png";
                        break;
                    }
            }

            return sReturn;
        }

        /// <summary>
        /// 미세먼지 아이콘 세팅
        /// </summary>
        /// <param name="sFineDust"></param>
        /// <returns></returns>
        private string SetFineDustIcon(string sFineDust)
        {
            string sReturn = "";
            
            switch (sFineDust.Trim())
            {
                case Common.Constants.DUST_CODE.GOOD:
                    {
                        sReturn = "/Resources/weather_imagesource_dusticon1.png";
                        break;
                    }
                case Common.Constants.DUST_CODE.NORMAL:
                    {
                        sReturn = "/Resources/weather_imagesource_dusticon2.png";
                        break;
                    }
                case Common.Constants.DUST_CODE.BAD:
                    {
                        sReturn = "/Resources/weather_imagesource_dusticon3.png";
                        break;
                    }
                case Common.Constants.DUST_CODE.VERYBAD:
                    {
                        sReturn = "/Resources/weather_imagesource_dusticon4.png";
                        break;
                    }
            }

            return sReturn;
        }

        /// <summary>
        /// 초미세먼지 아이콘 세팅
        /// </summary>
        /// <param name="sUltraFineParticle"></param>
        /// <returns></returns>
        private string SetUltraFineParticleIcon(string sUltraFineParticle)
        {
            int nFineDust = int.Parse(sUltraFineParticle);
            string sReturn = "";

            if (nFineDust >= 0 && nFineDust <= 15)
            {
                sReturn = "/Resources/weather_imagesource_dusticon1.png";
            }
            else if (nFineDust >= 16 && nFineDust <= 50)
            {
                sReturn = "/Resources/weather_imagesource_dusticon2.png";
            }
            else if (nFineDust >= 51 && nFineDust <= 100)
            {
                sReturn = "/Resources/weather_imagesource_dusticon3.png";
            }
            else
            {
                sReturn = "/Resources/weather_imagesource_dusticon4.png";
            }

            return sReturn;
        }
    }
}
