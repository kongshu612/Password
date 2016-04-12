using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace myPassword
{
    class RegisterWindowViewModel
    {
        #region Members
        string _sysUserName;
        string _sysPwd;
        DataAccess DBInstance;
        #endregion

        #region Properties
        public String SysUserName
        {
            get { return _sysUserName; }
            set { _sysUserName = value; }
        }
        public String SysPwd
        {

            get { return _sysPwd; }
            set { _sysPwd = value; }
        }
        #endregion

        #region Constructor
        public RegisterWindowViewModel()
        {
            DBInstance = new DataAccess();
        }
        #endregion

        #region Commands
        void RegisterNewUserExecute(Object parameter)
        {
            RegisterWindow RW_Win = parameter as RegisterWindow;
            if(RW_Win !=null)
            {
                SysUserName = RW_Win.txt_UserName.Text.Trim();
                SysPwd = RW_Win.txt_Password.Text.Trim();
                if(DBInstance.AddNewSystemUser(SysUserName,SysPwd))
                {
                    MainWindow MW_Win = RW_Win.Owner as MainWindow;
                    MW_Win.Show();
                    RW_Win.Close();
                }
                else
                {
                    MessageBox.Show("无法添加该用户名到系统，请更换用户名");
                }
            }
        }
        Boolean RegisterNewUserCanExecute()
        { return true; }
        public ICommand RegisterNewUser
        { get { return new myCommand(RegisterNewUserExecute, RegisterNewUserCanExecute); } }
        #endregion


    }
}
