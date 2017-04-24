using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Security;
using Prism.Regions;
using System.Windows;
using CCL_Oil_Labs_Control.CompositeCommands;
using CCL_Oil_Labs_Control.Model;
using CCL_Oil_Labs_Control.Events;
namespace CCL_Oil_Labs_Control.ViewModels
{
    public class EntryMenuViewModel : BindableBase , IConfirmNavigationRequest
    {

        private User currentUser;


        private IApplicationCommands _fillAndNavigateCommand;
        public IApplicationCommands fillAndNavigateCommand
        {
            get { return _fillAndNavigateCommand; }
            set { SetProperty(ref _fillAndNavigateCommand, value); }
        }
        IEventAggregator eventAggregator;
        private string _userName = null;
        public string userName
        {
            get { return _userName; }
            set
            { SetProperty(ref _userName, value); }
        }
        private  SecureString _password = null;
        public  SecureString password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand loginCommand { get; private set; }
        public DelegateCommand closeCommand { get; private set; }
        public EntryMenuViewModel (CloseCommand closeCommand, IApplicationCommands fillAndNavigateCommand, IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            loginCommand = new DelegateCommand(fillUserData, ()=>(!string.IsNullOrWhiteSpace(_userName) && !((_password!=null&&_password.Length==0)))).ObservesProperty(()=>userName).ObservesProperty(()=>password);
            this.closeCommand = new DelegateCommand(closeProgram, () => true);
            closeCommand.closeCommand.RegisterCommand(this.closeCommand);
            this.fillAndNavigateCommand = fillAndNavigateCommand;
            this.fillAndNavigateCommand.fillDataAndNavigateCommand.RegisterCommand(loginCommand);
            var navigateCommand = this.fillAndNavigateCommand.fillDataAndNavigateCommand.RegisteredCommands[0];
            this.fillAndNavigateCommand.fillDataAndNavigateCommand.UnregisterCommand(navigateCommand);
            this.fillAndNavigateCommand.fillDataAndNavigateCommand.RegisterCommand(navigateCommand);

        }
        private void fillUserData ()
        {
            currentUser = new User(userName, password);
        }


        private void closeProgram()
        {
            Application.Current.Shutdown();
        }
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (currentUser.login())
            {
                continuationCallback(true);
                eventAggregator.GetEvent<UpdatedEvent>().Publish(currentUser);
                currentUser = null;
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password");
                continuationCallback(false);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {           
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
