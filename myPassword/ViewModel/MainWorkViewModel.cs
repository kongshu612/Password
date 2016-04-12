using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;

namespace myPassword
{
    class MainWorkViewModel : INotifyPropertyChanged
    {
        #region Members
        private ObservableCollection<CredentialInfo> _credentialInfos;
        private string _userName;
        private string _pwd;
        private string _providerInfo;
        private string _DetailInfo;
        private string _keyWords;
        private Boolean _editable;
        private DataAccess DBInstance;
        private string _status;
        private int _sysUserID;
        private int _selectedID;
        private CredentialInfo _selectedCredential;
        #endregion

        #region Properties
        public string UserName
        {
            get
            { return _userName; }
            set
            {
                _userName = value;
            }
        }

        public string Pwd
        {
            get
            { return _pwd; }
            set
            {
                _pwd = value;
            }
        }

        public string ProviderInfo
        {
            get
            { return _providerInfo; }
            set
            {
                _providerInfo = value;
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
            }
        }

        public ObservableCollection<CredentialInfo> CredentialInfos
        {
            get
            { return _credentialInfos; }
        }

        public CredentialInfo SelectedCredential
        {
            get { return _selectedCredential; }
            set
            {
                _selectedCredential = value;
                NotifyPropertyChanged("SelectedCredential");
                if (_selectedCredential != null)
                {
                    RefleshSelectedID();
                    RefleshCurrentItem();
                }
            }
        }

        public int SelectedID
        {
            get
            {
                return _selectedID;
            }
            set
            {
                _selectedID = value;
            }
        }

        public Boolean Editable
        { 
            get { return _editable; }
            set { _editable = value; }
        }

        public string KeyWords
        {
            get
            {
                return _keyWords;
            }
            set
            {
                _keyWords = value;
            }
        }

        #endregion

        #region Commands
        void SaveCommandExecute(object parameter)
        {
            MainWork mw = parameter as MainWork;
            //UserName = mw.txt_UserName.Text.Trim();
            //Pwd = mw.txt_Pwd.Text.Trim();
            //ProviderInfo = mw.txt_ProviderInfo.Text.Trim();
            //DetailInfo = mw.txt_DetailInfo.Text.Trim();
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
            CredentialInfo selectedItem = lcv.CurrentItem as CredentialInfo;
            if(_status=="Add")
            {
                
                DBInstance.AddNewRecord(selectedItem.UserName, selectedItem.Pwd, selectedItem.ProviderInfo, selectedItem.DetailInfo, _sysUserID);
                //CredentialInfo newRecord = new CredentialInfo(UserName, Pwd, ProviderInfo, DetailInfo);
                //_credentialInfos.Add(newRecord);
            }
            if(_status=="Modify")
            {
                DBInstance.UpdateRecord(_selectedID, selectedItem);
            }
            Editable = !Editable;
            mw.lvCredentialInfo.IsEnabled = true;
        }
        Boolean SaveCommandCanExecute()
        {
            return Editable;
        }
        public ICommand SaveCommand
        {
            get
            {
                return new myCommand(SaveCommandExecute, SaveCommandCanExecute);
            }
        }

        void CancelCommandExecute(Object parameter)
        { Editable = !Editable; _status = null; }
        Boolean CancelCommandCanExecute()
        { return Editable; }
        public ICommand CancelCommand
        { get { return new myCommand(CancelCommandExecute, CancelCommandCanExecute); } }

        void DeleteCommandExecute(Object parameter)
        {  
            _status = null;
            if(MessageBox.Show("确定删除该记录","警告",MessageBoxButton.OKCancel,MessageBoxImage.Warning)==MessageBoxResult.OK)
            {
                DBInstance.DeleteRecord(SelectedID);
                MainWork mw = parameter as MainWork;
                ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
                lcv.Remove(SelectedCredential);
            }
            
        }
        Boolean DeleteCommandCanExecute()
        { return !Editable && (SelectedCredential!=null); }
        public ICommand DeleteCommand
        { get { return new myCommand(DeleteCommandExecute, DeleteCommandCanExecute); } }

        void ModifyCommandExecute(Object parameter)
        {
            Editable = !Editable;
            MainWork mw = parameter as MainWork;
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
            SelectedCredential = lcv.CurrentItem as CredentialInfo;
            _selectedID = DBInstance.GetCredentialIndex(SelectedCredential, _sysUserID);
            _status = "Modify";
            mw.lvCredentialInfo.IsEnabled = false;
        }
        Boolean ModifyCommandCanExecute()
        { return !Editable && (SelectedCredential != null); }
        public ICommand ModifyCommand
        { get { return new myCommand(ModifyCommandExecute, ModifyCommandCanExecute); } }

        void AddCommandExecute(Object parameter)
        {
            MainWork mw = parameter as MainWork;
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
            CredentialInfo newRecord = new CredentialInfo();
            lcv.AddNewItem(newRecord);
            lcv.CommitNew();
            SelectedCredential = newRecord;
            _status = "Add";
            Editable = !Editable;
            mw.lvCredentialInfo.IsEnabled = false;
        }
        Boolean AddCommandCanExecute()
        { return !Editable; }
        public ICommand AddCommand
        { get { return new myCommand(AddCommandExecute, AddCommandCanExecute); } }

        public class FilterClass
        {
            public string keywords;

            public Boolean Filterkeywords(object obj)
            {
                CredentialInfo cre = obj as CredentialInfo;
                if (!string.IsNullOrEmpty(cre.ProviderInfo) && cre.ProviderInfo.Contains(keywords) || !string.IsNullOrEmpty(cre.DetailInfo) && cre.DetailInfo.Contains(keywords))
                    return true;
                return false;
            }
        }

        void SearchCommandExecute(Object parameter)
        {
            MainWork mw = parameter as MainWork;
            string searchKeyWords = mw.txt_Keywords.Text.Trim();
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
            FilterClass filter = new FilterClass();
            filter.keywords = searchKeyWords;
            lcv.Filter = new Predicate<object>(filter.Filterkeywords);

        }
        Boolean SearchCommandCanExecute()
        { return !Editable; }
        public ICommand SearchCommand
        { get { return new myCommand(SearchCommandExecute, SearchCommandCanExecute); } }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructor
        public MainWorkViewModel(string sysUserName)
        {
            DBInstance = new DataAccess();
            //_credentialInfos = new List<CredentialInfo>();
            //CredentialInfo c1 = new CredentialInfo();
            //c1.UserName = "u1";
            //c1.Pwd = "p1";
            //c1.ProviderInfo = "pi1";
            //c1.DetailInfo = "di1";
            //CredentialInfo c2 = new CredentialInfo();
            //c2.UserName = "u2";
            //c2.Pwd = "p2";
            //c2.ProviderInfo = "pi2";
            //c2.DetailInfo = "di2";
            //_credentialInfos.Add(c1);
            //_credentialInfos.Add(c2);
            _credentialInfos = DBInstance.LoadCredentialInfos(sysUserName);
            _sysUserID = DBInstance.GetSystemUserID(sysUserName);
            _editable = false;
        }
        #endregion
        private void RefleshSelectedID()
        {
            SelectedID = DBInstance.GetCredentialIndex(SelectedCredential, _sysUserID);
        }

        private void RefleshCurrentItem()
        {
            MainWork mw=null;
            for(int i=0;i<Application.Current.Windows.Count;i++)
            {
                mw = Application.Current.Windows[i] as MainWork;
                if (mw != null)
                    break;
            }
            ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(mw.lvCredentialInfo.ItemsSource);
            lcv.MoveCurrentTo(SelectedCredential);
        }


    }
}
