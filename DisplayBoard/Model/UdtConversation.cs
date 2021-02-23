using IMRUtils.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayBoard.Model
{
    public class UdtConversation : MomModel
    {
        private string mConversationTitle;
        private string mTranslate;

        /// <summary>
        /// 회화  내용
        /// </summary>
        public string ConversationTitle
        {
            get => this.mConversationTitle;
            set
            {
                this.mConversationTitle = value;
                this.OnPropertyChanged("ConversationTitle");
            }
        }

        /// <summary>
        /// 회화 해석
        /// </summary>
        public string Translate
        {
            get => this.mTranslate;
            set
            {
                this.mTranslate = value;
                this.OnPropertyChanged("Translate");
            }
        }
    }
}
