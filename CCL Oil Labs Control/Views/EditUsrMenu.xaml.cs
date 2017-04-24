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
    /// Interaction logic for EditUsrMenu.xaml
    /// </summary>
    public partial class EditUsrMenu : UserControl
    {
        public EditUsrMenuViewModel viewModel { get; set; }
        public EditUsrMenu(EditUsrMenuViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.viewModel.oldPassword = (sender as PasswordBox).SecurePassword;
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            this.viewModel.newPassword = (sender as PasswordBox).SecurePassword;
        }

        private void PasswordBox_PasswordChanged_2(object sender, RoutedEventArgs e)
        {
            this.viewModel.confirmNewPassword = (sender as PasswordBox).SecurePassword;
        }
    }
}
