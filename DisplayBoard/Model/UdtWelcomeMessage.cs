using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtWelcomeMessage : MomModel
    {
        private string mMessage;

        public string Message
        {
            get => mMessage;
            set
            {
                this.mMessage = value;
                this.OnPropertyChanged("Message");
            }
        }
    }
}
