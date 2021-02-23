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
    /// ucJob.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucJob : CommonScreen
    {
        public ucJob()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            TAG = Common.Constants.SCREEN_INDEX.JOB;
            BindingData = Common.Common.JobData;
            InitData();
        }

        private void InitData()
        {
            // Json 데이터 가져오기
            List<Dictionary<string, string>> arrJob = Common.Common.GetJsonData(Common.Constants.FILE_KEY.JOB);

            BindingData.MomModelCollection.Clear();
            // 데이터 넣기
            UdtJob udtJob;
            for (int i = 0; i < arrJob.Count; i++)
            {
                udtJob = new UdtJob();
                udtJob.JobTitle = arrJob[i][Common.Constants.JSON_KEY.JOB.TITLE];
                udtJob.JobInfo = arrJob[i][Common.Constants.JSON_KEY.JOB.INFO];

                if(null == arrJob[i][Common.Constants.JSON_KEY.JOB.IMAGE])
                {
                    udtJob.JobImage = "";
                }
                else
                {
                    udtJob.JobImage = arrJob[i][Common.Constants.JSON_KEY.JOB.IMAGE];
                }
                BindingData.MomModelCollection.Add(udtJob);
            }

            this.DataContext = BindingData.MomModelCollection[0];

            if(((UdtJob)BindingData.MomModelCollection[0]).JobImage == "")
            {
                imgJob.Source = new BitmapImage(new Uri("/Resources/job_imagesource_imagepreparing.png"));
            }

            //lbTest.ItemsSource = BindingData.MomModelCollection;
        }
    }
}
