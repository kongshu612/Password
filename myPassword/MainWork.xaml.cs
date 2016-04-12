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
using System.Windows.Shapes;

namespace myPassword
{
    /// <summary>
    /// Interaction logic for MainWork.xaml
    /// </summary>
    public partial class MainWork : Window
    {
        public MainWork()
        {
            InitializeComponent();

        }

        private void MainWork_OnClosed(object sender, EventArgs e)
        {
            MainWindow MW_Win = this.Owner as MainWindow;
            MW_Win.Show();
            this.Close();
        }

    }
}
