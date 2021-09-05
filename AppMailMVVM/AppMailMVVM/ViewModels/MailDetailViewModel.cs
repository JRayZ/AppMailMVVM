using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AppMailMVVM.Models;

namespace AppMailMVVM.ViewModels
{
    class MailDetailViewModel
    {
        mail _mail;
        public mail Mail
        {
            get
            { return _mail; }
        }

        public MailDetailViewModel(mail mail)
        {

        }
    }
}
