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

namespace CCL_Oil_Labs_Control
{
    /// <summary>
    /// Interaction logic for EntryMenu.xaml
    /// </summary>
    public partial class EntryMenu : Window
    {
        public EntryMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switch to MainMenu when EntryMenuButtonMainMenu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryMenuButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            new CCL_Oil_Labs_Control.Menus.MainMenu().Show();
        }

        /// <summary>
        /// Closes program when EntryMenuButtonClose is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryMenuButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
