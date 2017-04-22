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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close this window when MainMenuButtonClose is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Switch to CodesAddingMenu when MainMenuButtonAddCodes is clicked and hide this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuButtonAddCodes_Click(object sender, RoutedEventArgs e)
        {
            new CodesAddingMenu().Show();
            Hide();
        }
    }
}
