using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL_Oil_Labs_Control.CompositeCommands;
using Prism.Commands;
using System.Security;
using CCL_Oil_Labs_Control.Model;
using System.Windows;
using CCL_Oil_Labs_Control.Utils;
namespace CCL_Oil_Labs_Control.ViewModels
{
    public class AddNewUsrMenuViewModel : BindableBase 
    {

        private string _userName = null;
        public string userName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private SecureString _password = null;
        public SecureString password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private SecureString _confirmPassword= null;
        public SecureString confirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }

        private GlobalNavigateCommand _globalNavigateCommand;
        public GlobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand saveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(save, () => !string.IsNullOrWhiteSpace(userName) 
            && password != null && password.Length!=0 && confirmPassword != null &&confirmPassword.Length!=0))
            .ObservesProperty(() => userName).ObservesProperty(() => password)
            .ObservesProperty(() => confirmPassword);

        private void save()
        {
            if (!Utils.Utils.SecureStringEqual(password, confirmPassword))
            {
                MessageBox.Show("Your Passwords don't match, please confirm your password!");
                return;
            }
            else
            {
                new User(userName, password).Register();
            }
        }
        public AddNewUsrMenuViewModel(GlobalNavigateCommand globalNavigateCommand)
        {
            this.globalNavigateCommand = globalNavigateCommand;
        }
    }
}
