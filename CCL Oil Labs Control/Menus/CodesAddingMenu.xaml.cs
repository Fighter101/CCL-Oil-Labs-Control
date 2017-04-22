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
    /// Interaction logic for CodesAddingMenu.xaml
    /// </summary>
    public partial class CodesAddingMenu : Window
    {
        public CodesAddingMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close this windows when CodesAddMenuButtonClose is clicked and show MainMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodesAddMenuButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new MainMenu().Show();
        }

        /// <summary>
        /// Switch to AddNewUsrMenu when CodesAddMenuButtonNewUsr is clicked and hide this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodesAddMenuButtonNewUsr_Click(object sender, RoutedEventArgs e)
        {
            new AddNewUsrMenu().Show();
            Hide();
        }
    }
}
