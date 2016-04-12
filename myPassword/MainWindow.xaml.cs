using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace myPassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mwvm;
        public MainWindow()
        {
            InitializeComponent();
            CheckDataBase();
        }

        private void CheckDataBase()
        {
            var dbInitialPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Creden_DB.db");
            if(!File.Exists(@"c:\programdata\PasswordManager\Creden_DB.db"))
            {
                Directory.CreateDirectory(@"c:\programdata\PasswordManager");
                File.Copy(dbInitialPath, @"c:\programdata\PasswordManager\Creden_DB.db");
            }
        }
    }
}
