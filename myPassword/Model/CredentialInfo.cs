using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

namespace myPassword
{
    public class CredentialInfo:INotifyPropertyChanged
    {
        #region private members
        private string _userName;
        private string _pwd;
        private string _providerInfo;
        private string _DetailInfo;
        #endregion

        #region public properties

        public string UserName
        {
            get
            { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Pwd
        {
            get
            { return _pwd; }
            set
            {
                _pwd = value;
                OnPropertyChanged("Pwd");
            }
        }

        public string ProviderInfo
        {
            get
            { return _providerInfo; }
            set
            {
                _providerInfo = value;
                OnPropertyChanged("ProviderInfo");
            }
        }

        public string DetailInfo
        {
            get
            {
                return _DetailInfo;
            }
            set
            {
                _DetailInfo = value;
                OnPropertyChanged("DetailInfo");
            }
        }
        #endregion

        #region Constructor
        public CredentialInfo()
        {
        }
        public CredentialInfo(string cUserName, string cPwd, string cProviderInfo, string cDetailInfo)
        {
            _userName=cUserName;
            _pwd=cPwd;
            _providerInfo=cProviderInfo;
            _DetailInfo=cDetailInfo;
        }
        #endregion


        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
