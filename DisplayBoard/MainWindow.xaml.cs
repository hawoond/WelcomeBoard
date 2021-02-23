using DisplayBoard.View;
using DisplayBoard.ViewModel;
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
using System.Windows.Threading;
using System.Management;

namespace DisplayBoard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer dtUltraTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModel.Instance;
            Init();
        }

        private void Init()
        {
            ShareFolderPermission(@"C:\jireh","Z");
            UltraTick();
            //FakeData();
            SetFlow();

            dtUltraTimer.Interval = TimeSpan.FromTicks(80000000);
            dtUltraTimer.Tick += DtUltraTimer_Tick;
            dtUltraTimer.Start();

            timer.Interval = TimeSpan.FromTicks(60000000);
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void ShareFolderPermission(string FolderPath, string ShareName)
        {
            try
            {
                ManagementClass managementClass = new ManagementClass("Win32_Share");
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
                ManagementBaseObject outParams;
                inParams["Description"] = "";
                inParams["Name"] = ShareName;
                inParams["Path"] = FolderPath;
                inParams["Type"] = 0x0;

                outParams = managementClass.InvokeMethod("Create", inParams, null);

                if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
                    Console.WriteLine("Folder might be already in share or unable to share the directory");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtUltraTimer_Tick(object sender, EventArgs e)
        {
            UltraTick();
        }

        public void UltraTick()
        {
            List<Dictionary<string, string>> arrDicResult = Common.Common.GetJsonData(Common.Constants.FILE_KEY.CONFIG);
            if (null == arrDicResult)
            {
                return;
            }
            for (int i = 0; i < arrDicResult.Count; i++)
            {
                Common.Constants.SCHOOL_NM = arrDicResult[i][Common.Constants.JSON_KEY.CONFIG.SCH_NM];
                Common.Constants.INTERVAL = int.Parse(arrDicResult[i][Common.Constants.JSON_KEY.CONFIG.SCR_INTERVAL]);
            }

            timer.Interval = TimeSpan.FromTicks(Common.Constants.INTERVAL * 10000000);

        }

        List<Uri> arrFakeScreen = new List<Uri>();

        private void SetFlow()
        {
            List<string> arrFlow = Common.Common.GetScreenFlow();
            arrFakeScreen = new List<Uri>();
            if (null == arrFlow)
            {
                return;
            }

            arrFakeScreen.Clear();

            for (int i = 0; i < arrFlow.Count; i++)
            {
                string sPath = Common.Common.GetScreenPath(arrFlow[i]);
                if (!sPath.Equals(string.Empty))
                {
                    arrFakeScreen.Add(new Uri(Common.Common.GetScreenPath(arrFlow[i]), UriKind.Relative));
                }
            }


        }

        int mIndex;
        private void Timer_Tick(object sender, EventArgs e)
        {
            SetFlow();
            if (arrFakeScreen.Count == 0)
            {
                return;
            }

            if (mIndex >= arrFakeScreen.Count)
            {
                fMainFrame.Source = arrFakeScreen[mIndex % arrFakeScreen.Count];
            }
            else
            {
                fMainFrame.Source = arrFakeScreen[mIndex];
            }

            if (("/" + fMainFrame.Source.ToString()).Equals(Common.Constants.ScreenPath.PROM_SEQ))
            {
                timer.Stop();
            }
    
            mIndex++;
        }
    }
}
