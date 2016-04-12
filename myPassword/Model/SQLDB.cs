// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from mySQLiteDB on 2016-04-03 23:01:08Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
namespace myPassword
{
	using System;
	using System.ComponentModel;
	using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
	using System.Diagnostics;
	
	
	public partial class MySqlIteDb : DataContext
	{
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
		
		
		public MySqlIteDb(string connectionString) : 
				base(connectionString)
		{
			this.OnCreated();
		}
		
		public MySqlIteDb(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public MySqlIteDb(IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			this.OnCreated();
		}
		
		public Table<TabCredentialInfos> TabCredentialInfos
		{
			get
			{
				return this.GetTable<TabCredentialInfos>();
			}
		}
		
		public Table<TabSystemUser> TabSystemUser
		{
			get
			{
				return this.GetTable<TabSystemUser>();
			}
		}
	}
	
	#region Start MONO_STRICT
#if MONO_STRICT

	public partial class MySqlIteDb
	{
		
		public MySqlIteDb(IDbConnection connection) : 
				base(connection)
		{
			this.OnCreated();
		}
	}
	#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT
	
	public partial class MySqlIteDb
	{
		
		public MySqlIteDb(IDbConnection connection) : 
				base(connection, new DbLinq.Sqlite.SqliteVendor())
		{
			this.OnCreated();
		}
		
		public MySqlIteDb(IDbConnection connection, IVendor sqlDialect) : 
				base(connection, sqlDialect)
		{
			this.OnCreated();
		}
		
		public MySqlIteDb(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
				base(connection, mappingSource, sqlDialect)
		{
			this.OnCreated();
		}
	}
	#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
	#endregion
	
	[Table(Name="main.Tab_CredentialInfos")]
	public partial class TabCredentialInfos : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private string _detailInfo;
		
		private int _id;
		
		private string _password;
		
		private string _providerName;
		
		private int _systemUserID;
		
		private string _userName;
		
		private EntityRef<TabSystemUser> _tabSystemUser = new EntityRef<TabSystemUser>();
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnDetailInfoChanged();
		
		partial void OnDetailInfoChanging(string value);
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnPasswordChanged();
		
		partial void OnPasswordChanging(string value);
		
		partial void OnProviderNameChanged();
		
		partial void OnProviderNameChanging(string value);
		
		partial void OnSystemUserIDChanged();
		
		partial void OnSystemUserIDChanging(int value);
		
		partial void OnUserNameChanged();
		
		partial void OnUserNameChanging(string value);
		#endregion
		
		
		public TabCredentialInfos()
		{
			this.OnCreated();
		}
		
		[Column(Storage="_detailInfo", Name="DetailInfo", DbType="NVARCHAR(10000)", AutoSync=AutoSync.Never)]
		[DebuggerNonUserCode()]
		public string DetailInfo
		{
			get
			{
				return this._detailInfo;
			}
			set
			{
				if (((_detailInfo == value) 
							== false))
				{
					this.OnDetailInfoChanging(value);
					this.SendPropertyChanging();
					this._detailInfo = value;
					this.SendPropertyChanged("DetailInfo");
					this.OnDetailInfoChanged();
				}
			}
		}
		
		[Column(Storage="_id", Name="ID", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_password", Name="Password", DbType="NVARCHAR(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				if (((_password == value) 
							== false))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_providerName", Name="ProviderName", DbType="NVARCHAR(1000)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string ProviderName
		{
			get
			{
				return this._providerName;
			}
			set
			{
				if (((_providerName == value) 
							== false))
				{
					this.OnProviderNameChanging(value);
					this.SendPropertyChanging();
					this._providerName = value;
					this.SendPropertyChanged("ProviderName");
					this.OnProviderNameChanged();
				}
			}
		}
		
		[Column(Storage="_systemUserID", Name="SystemUserID", DbType="INT", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int SystemUserID
		{
			get
			{
				return this._systemUserID;
			}
			set
			{
				if ((_systemUserID != value))
				{
					if (_tabSystemUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSystemUserIDChanging(value);
					this.SendPropertyChanging();
					this._systemUserID = value;
					this.SendPropertyChanged("SystemUserID");
					this.OnSystemUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_userName", Name="UserName", DbType="NVARCHAR(100)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string UserName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if (((_userName == value) 
							== false))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		#region Parents
		[Association(Storage="_tabSystemUser", OtherKey="ID", ThisKey="SystemUserID", Name="fk_Tab_CredentialInfos_0", IsForeignKey=true)]
		[DebuggerNonUserCode()]
		public TabSystemUser TabSystemUser
		{
			get
			{
				return this._tabSystemUser.Entity;
			}
			set
			{
				if (((this._tabSystemUser.Entity == value) 
							== false))
				{
					if ((this._tabSystemUser.Entity != null))
					{
						TabSystemUser previousTabSystemUser = this._tabSystemUser.Entity;
						this._tabSystemUser.Entity = null;
						previousTabSystemUser.TabCredentialInFOs.Remove(this);
					}
					this._tabSystemUser.Entity = value;
					if ((value != null))
					{
						value.TabCredentialInFOs.Add(this);
						_systemUserID = value.ID;
					}
					else
					{
						_systemUserID = default(int);
					}
				}
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="main.Tab_SystemUser")]
	public partial class TabSystemUser : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
		
		private int _id;
		
		private string _sysPassword;
		
		private string _sysUserName;
		
		private EntitySet<TabCredentialInfos> _tabCredentialInFoS;
		
		#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(int value);
		
		partial void OnSysPasswordChanged();
		
		partial void OnSysPasswordChanging(string value);
		
		partial void OnSysUserNameChanged();
		
		partial void OnSysUserNameChanging(string value);
		#endregion
		
		
		public TabSystemUser()
		{
			_tabCredentialInFoS = new EntitySet<TabCredentialInfos>(new Action<TabCredentialInfos>(this.TabCredentialInFOs_Attach), new Action<TabCredentialInfos>(this.TabCredentialInFOs_Detach));
			this.OnCreated();
		}
		
		[Column(Storage="_id", Name="ID", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((_id != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_sysPassword", Name="SysPassword", DbType="NVARCHAR(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string SysPassword
		{
			get
			{
				return this._sysPassword;
			}
			set
			{
				if (((_sysPassword == value) 
							== false))
				{
					this.OnSysPasswordChanging(value);
					this.SendPropertyChanging();
					this._sysPassword = value;
					this.SendPropertyChanged("SysPassword");
					this.OnSysPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_sysUserName", Name="SysUserName", DbType="NVARCHAR(50)", AutoSync=AutoSync.Never, CanBeNull=false)]
		[DebuggerNonUserCode()]
		public string SysUserName
		{
			get
			{
				return this._sysUserName;
			}
			set
			{
				if (((_sysUserName == value) 
							== false))
				{
					this.OnSysUserNameChanging(value);
					this.SendPropertyChanging();
					this._sysUserName = value;
					this.SendPropertyChanged("SysUserName");
					this.OnSysUserNameChanged();
				}
			}
		}
		
		#region Children
		[Association(Storage="_tabCredentialInFoS", OtherKey="SystemUserID", ThisKey="ID", Name="fk_Tab_CredentialInfos_0")]
		[DebuggerNonUserCode()]
		public EntitySet<TabCredentialInfos> TabCredentialInFOs
		{
			get
			{
				return this._tabCredentialInFoS;
			}
			set
			{
				this._tabCredentialInFoS = value;
			}
		}
		#endregion
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
			if ((h != null))
			{
				h(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
			if ((h != null))
			{
				h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		#region Attachment handlers
		private void TabCredentialInFOs_Attach(TabCredentialInfos entity)
		{
			this.SendPropertyChanging();
			entity.TabSystemUser = this;
		}
		
		private void TabCredentialInFOs_Detach(TabCredentialInfos entity)
		{
			this.SendPropertyChanging();
			entity.TabSystemUser = null;
		}
		#endregion
	}
}
