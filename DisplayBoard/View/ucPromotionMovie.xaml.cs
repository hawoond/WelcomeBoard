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
    /// ucPromotionMovie.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucPromotionMovie : CommonScreen
    {
        int nMovieCount = 0;
       

        public ucPromotionMovie()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.PROMOTION_MOVIE;
            BindingData = Common.Common.PromotionMovieData;

            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrPromotionMovie = Common.Common.GetJsonData(Common.Constants.FILE_KEY.PROMOTION_MOVIE);
            BindingData.MomModelCollection.Clear();

            // 데이터 넣기
            UdtPromotionMovie udtPromotionMovie;
            for (int i = 0; i < arrPromotionMovie.Count; i++)
            {
                udtPromotionMovie = new UdtPromotionMovie();
                udtPromotionMovie.FilePath= arrPromotionMovie[i][Common.Constants.JSON_KEY.PROMOTIONMOVIE.FILEPATH];
                BindingData.MomModelCollection.Add(udtPromotionMovie);
            }

            if (BindingData.MomModelCollection.Count().Equals(0))
            {
                MainWindow.timer.Start();
            }
            else
            {
                meMovie.Source = new Uri(((UdtPromotionMovie)BindingData.MomModelCollection[nMovieCount]).FilePath, UriKind.Absolute);
            }

        }

        private void MeMovie_MediaEnded(object sender, RoutedEventArgs e)
        {
            nMovieCount++;
            if(BindingData.MomModelCollection.Count > nMovieCount)
            {
                meMovie.Source = new Uri(((UdtPromotionMovie)BindingData.MomModelCollection[nMovieCount]).FilePath, UriKind.Absolute);
            }
            else
            {
                MainWindow.timer.Start();
            }
        }
    }
}
