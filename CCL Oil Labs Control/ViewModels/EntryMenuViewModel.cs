using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Security;
using System.Windows;
using CCL_Oil_Labs_Control.CompositeCommands;
using CCL_Oil_Labs_Control.Model;
using CCL_Oil_Labs_Control.Events;
namespace CCL_Oil_Labs_Control.ViewModels
{
    public class EntryMenuViewModel : BindableBase
    {
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
        public EntryMenuViewModel (IApplicationCommands m_fillAndNavigateCommand, IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            loginCommand = new DelegateCommand(fillUserData, canExecute).ObservesProperty(()=>userName).ObservesProperty(()=>password);
            fillAndNavigateCommand = m_fillAndNavigateCommand;
            fillAndNavigateCommand.fillDataAndNavigateCommand.RegisterCommand(loginCommand);
        }
        private void fillUserData ()
        {
            {
                User user = new User(_userName, _password);
                eventAggregator.GetEvent<UpdatedEvent>().Publish(user);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        private bool canExecute ()
        {
            return !string.IsNullOrWhiteSpace(_userName) && password != null;
        }
    }
}
