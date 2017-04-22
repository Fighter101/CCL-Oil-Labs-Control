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

namespace CCL_Oil_Labs_Control.Menus
{
    /// <summary>
    /// Interaction logic for AddNewUsrMenu.xaml
    /// </summary>
    public partial class AddNewUsrMenu : Window
    {
        public AddNewUsrMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close this windows when AddNewUsrMenuButtonClose is clicked and show CodesAddingMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewUsrMenuButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new CodesAddingMenu().Show();
        }
    }
}
