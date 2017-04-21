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
    /// Interaction logic for EntryMenu.xaml
    /// </summary>
    public partial class EntryMenu : UserControl
    {
        public EntryMenuViewModel viewModel;
        public EntryMenu(EntryMenuViewModel _viewModel)
        {
            InitializeComponent();
            viewModel = _viewModel;
        }

        private void EntryMenuPassBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            //For security reasons Binding is not allowed here

            viewModel.password = (sender as PasswordBox).SecurePassword;
        }
    }
}
