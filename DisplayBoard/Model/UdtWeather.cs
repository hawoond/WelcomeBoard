using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtWeather : MomModel
    {
        private string mWeatherDesc_temp;
        private string mWeatherDesc_state;
        private string mWeatherState;
        private string mTemperature;
        private string mSensibleTemp;
        private string mFineDust;
        private string mFineDust_icon;
        private string mUltrafineParticle;
        private string mUltrafineParticle_icon;
        private string mPop;

        /// <summary>
        /// n도 할때 n
        /// </summary>
        public string WeatherDesc_temp
        {
            get => mWeatherDesc_temp;
            set
            {
                this.mWeatherDesc_temp = value;
                this.OnPropertyChanged("WeatherDesc_temp");
            }
        }

        /// <summary>
        /// 높아요 낮아요
        /// </summary>
        public string WeatherDesc_state
        {
            get => mWeatherDesc_state;
            set
            {
                this.mWeatherDesc_state = value;
                this.OnPropertyChanged("WeatherDesc_state");
            }
        }

        /// <summary>
        /// 날씨 상태 아이콘임
        /// </summary>
        public string WeatherState
        {
            get => mWeatherState;
            set
            {
                this.mWeatherState = value;
                this.OnPropertyChanged("WeatherState");
            }
        }

        /// <summary>
        /// 온도
        /// </summary>
        public string Temperature
        {
            get => mTemperature;
            set
            {
                this.mTemperature = value;
                this.OnPropertyChanged("Temperature");
            }
        }

        /// <summary>
        /// 체감온도
        /// </summary>
        public string SensibleTemp
        {
            get => mSensibleTemp;
            set
            {
                this.mSensibleTemp = value;
                this.OnPropertyChanged("SensibleTemp");
            }
        }

        /// <summary>
        /// 미세먼지
        /// </summary>
        public string FineDust
        {
            get => mFineDust;
            set
            {
                this.mFineDust = value;
                this.OnPropertyChanged("FineDust");
            }
        }

        /// <summary>
        /// 미세먼지 아이콘
        /// </summary>
        public string FineDust_icon
        {
            get => mFineDust_icon;
            set
            {
                this.mFineDust_icon = value;
                this.OnPropertyChanged("FineDust_icon");
            }
        }

        /// <summary>
        /// 초미세먼지
        /// </summary>
        public string UltrafineParticle
        {
            get => mUltrafineParticle;
            set
            {
                this.mUltrafineParticle = value;
                this.OnPropertyChanged("UltrafineParticle");
            }
        }

        /// <summary>
        /// 초미세먼지 아이콘
        /// </summary>
        public string UltrafineParticle_icon
        {
            get => mUltrafineParticle_icon;
            set
            {
                this.mUltrafineParticle_icon = value;
                this.OnPropertyChanged("UltrafineParticle_icon");
            }
        }

        /// <summary>
        /// 강수확률
        /// </summary>
        public string Pop
        {
            get => mPop;
            set
            {
                this.mPop = value;
                this.OnPropertyChanged("Pop");
            }
        }


    }
}
