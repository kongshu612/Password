using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace myPassword
{
    public class DataAccess
    {
        #region Single Instance private members
        private static DataAccess _instance=null;
        public static DataAccess Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance=new DataAccess();
                }
                return _instance;
            }
        }
        #endregion

        #region public Properties
        public MySqlIteDb DBInstance
        { get; set; }


        #endregion


        #region public interface
        public Boolean CheckSystemUser(string userName, string pwd,Boolean onlyUserName=true)
        {        
            foreach(var eachUser in DBInstance.TabSystemUser)
            {
                if (onlyUserName && eachUser.SysUserName == userName)
                    return true;
                if (!onlyUserName && eachUser.SysUserName == userName && eachUser.SysPassword == pwd)
                    return true;
            }
            return false;
        }

        public int GetSystemUserID(string userName)
        {
            foreach(var each in DBInstance.TabSystemUser)
            {
                if (each.SysUserName == userName)
                    return each.ID;
            }
            return -1;
        }

        public Boolean AddNewSystemUser(string userName, string pwd)
        {
            if(!CheckSystemUser(userName,pwd,false))
            {
                TabSystemUser newUser = new TabSystemUser();
                newUser.SysUserName = userName;
                newUser.SysPassword = pwd;
                DBInstance.TabSystemUser.InsertOnSubmit(newUser);
                DBInstance.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public ObservableCollection<CredentialInfo> LoadCredentialInfos(string userName)
        {
            ObservableCollection<CredentialInfo> credentialValues = new ObservableCollection<CredentialInfo>();
            foreach(var each in DBInstance.TabCredentialInfos)
            {
                if(each.TabSystemUser.SysUserName==userName)
                {
                    credentialValues.Add(new CredentialInfo(each.UserName,each.Password,each.ProviderName,each.DetailInfo));
                }
            }
            return credentialValues;
        }

        public ObservableCollection<CredentialInfo> LoadCredentialInfos(int userID)
        {
            ObservableCollection<CredentialInfo> credentialValues = new ObservableCollection<CredentialInfo>();
            foreach (var each in DBInstance.TabCredentialInfos)
            {
                if (each.TabSystemUser.ID == userID)
                {
                    credentialValues.Add(new CredentialInfo(each.UserName, each.Password, each.ProviderName, each.DetailInfo));
                }
            }
            return credentialValues;
        }

        public Boolean AddNewRecord(string userName, string pwd, string providerInfo, string DetailInfo,int sysUserID)
        {
            TabCredentialInfos newCredential = new TabCredentialInfos();
            newCredential.UserName = userName;
            newCredential.Password = pwd;
            newCredential.ProviderName = providerInfo;
            newCredential.DetailInfo = DetailInfo;
            newCredential.SystemUserID = sysUserID;            
            DBInstance.TabCredentialInfos.InsertOnSubmit(newCredential);
            DBInstance.SubmitChanges();
            return true;
        }

        public Boolean UpdateRecord(int CredenID, CredentialInfo targetCreden)
        {
            foreach(TabCredentialInfos each in DBInstance.TabCredentialInfos)
            {
                if(each.ID==CredenID)
                {
                    each.UserName = targetCreden.UserName;
                    each.Password = targetCreden.Pwd;
                    each.ProviderName = targetCreden.ProviderInfo;
                    each.DetailInfo = targetCreden.DetailInfo;
                    DBInstance.SubmitChanges();
                    return true;
                }
            }

            return false;
        }

        public Boolean DeleteRecord(int CredenID)
        {
            foreach(TabCredentialInfos each in DBInstance.TabCredentialInfos)
            {
                if(each.ID==CredenID)
                {
                    DBInstance.TabCredentialInfos.DeleteOnSubmit(each);
                    DBInstance.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public int GetCredentialIndex(CredentialInfo targetCreden, int sysUserID)
        {
            string userName = targetCreden.UserName;
            string pwd = targetCreden.Pwd;
            string providerInfo = targetCreden.ProviderInfo;
            string DetailInfo = targetCreden.DetailInfo;
            foreach(TabCredentialInfos each in DBInstance.TabCredentialInfos)
            {
                if(each.UserName==userName && each.Password==pwd && each.ProviderName==providerInfo && each.DetailInfo==DetailInfo && each.SystemUserID==sysUserID)
                {
                    return each.ID;
                }
            }
            return -1;
        }

        #endregion

        #region Constructor
        public DataAccess()
        {
            System.Data.IDbConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["myPassword.Properties.Settings.SQLiteConnStr"].ConnectionString);
            DBInstance = new MySqlIteDb(conn);
        }
        #endregion
    }
}
