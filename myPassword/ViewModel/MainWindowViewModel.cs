using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace myPassword
{
    class MainWindowViewModel
    {
        #region private members
        private DataAccess DataInstance = DataAccess.Instance;
        private string _systemUserName;
        private string _systemPwd;
        #endregion

        #region public Properties
        public string SystemUserName
        { 
            get
            {
                return _systemUserName;
            }
            set
            {
                _systemUserName = value;
            }        
        }
        public string SystemPwd
        {
            get
            {
                return _systemPwd;
            }
            set
            {
                _systemPwd = value;
            }
        }
        #endregion

        #region Commands
        void OkCommandExecute(object parameter)
        {
            MainWindow mw = parameter as MainWindow;
            SystemPwd = mw.txt_Pwd.Password.Trim();
            if(DataInstance.CheckSystemUser(SystemUserName, SystemPwd))
            {
                MainWork mainWorkWindow = new MainWork();
                MainWorkViewModel mwvm = new MainWorkViewModel(SystemUserName);
                mainWorkWindow.DataContext = mwvm;
                mainWorkWindow.Owner = mw;
                mw.Hide();
                mainWorkWindow.Show();
            }
            else
            {
                MessageBox.Show("用户名或者密码错误，请注意大小写");
            }
        }
        Boolean OkCommandCanExecute()
        {
            return !string.IsNullOrEmpty(SystemUserName);
        }
        public ICommand OkCommand
        {
            get
            {
                return new myCommand(OkCommandExecute, OkCommandCanExecute);
            }
        }

        void CancelCommandExecute(object parameter)
        {
            Application.Current.Shutdown();
        }
        Boolean CancelCommandCanExecute()
        {
            return true;
        }
        public ICommand CancelCommand
        {
            get
            {
                return new myCommand(CancelCommandExecute, CancelCommandCanExecute);
            }
        }

        void RegisterCommandExecute(object parameter)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Owner = Application.Current.MainWindow;
            Application.Current.MainWindow.Hide();
            rw.Show();
        }
        Boolean RegisterCommandCanExecute()
        {
            return true;
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new myCommand(RegisterCommandExecute, RegisterCommandCanExecute);
            }
        }

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            
        }
        #endregion


    }
}
