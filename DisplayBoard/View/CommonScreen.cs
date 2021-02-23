using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DisplayBoard.View
{
    public class CommonScreen : UserControl
    {
        public Common.Constants.SCREEN_INDEX TAG;
        public MomModel BindingData = new MomModel();

        public virtual bool SetData(MomModel model)
        {
            bool isSuccess = false;

            try
            {
                this.BindingData = model;
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
