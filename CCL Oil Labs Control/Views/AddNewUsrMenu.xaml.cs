using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CCL_Oil_Labs_Control.ViewModels;
namespace CCL_Oil_Labs_Control.Views
{
    /// <summary>
    /// Interaction logic for AddNewUsrMenu.xaml
    /// </summary>
    public partial class AddNewUsrMenu : UserControl
    {

        public AddNewUsrMenuViewModel viewModel { get; set; }
        public AddNewUsrMenu(AddNewUsrMenuViewModel viewModel )
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.password = (sender as PasswordBox).SecurePassword;
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            viewModel.confirmPassword = (sender as PasswordBox).SecurePassword;
        }
    }
}
