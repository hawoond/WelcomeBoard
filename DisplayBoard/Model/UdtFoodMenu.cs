using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtFoodMenu : MomModel
    {
        private string mMenuDesc;

        public string MenuDesc
        {
            get
            {
                return mMenuDesc;
            }
            set
            {
                this.mMenuDesc = value;
                this.OnPropertyChanged("MenuDesc");
            }
        }
    }
}
