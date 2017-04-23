using Prism.Mvvm;
using CCL_Oil_Labs_Control.CompositeCommands;
using CCL_Oil_Labs_Control.Events;
using Prism.Events;
using CCL_Oil_Labs_Control.Model;
using Prism.Regions;
using System;
using System.Windows;
using Prism.Commands;

namespace CCL_Oil_Labs_Control.ViewModels
{
    class MainMenuViewModel : BindableBase
    {

        
        private IGLobalNavigateCommand _globalNavigateCommand;
        public IGLobalNavigateCommand globalNavigateCommand
        {
            get { return _globalNavigateCommand; }
            set { SetProperty(ref _globalNavigateCommand, value); }
        }
        private AddingCodesNavigateCommand _addingCodesNavigationCommand;
        public AddingCodesNavigateCommand addingCodesNavigationCommand
        {
            get { return _addingCodesNavigationCommand; }
            set { SetProperty(ref _addingCodesNavigationCommand, value); }
        }

        private IEventAggregator _eventAggregator;
        public IEventAggregator eventAggregator
        {
            get { return _eventAggregator; }
            set { SetProperty(ref _eventAggregator, value); }
        }
        private User _currentUser;
        public User currentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }
        private bool _authorizationLevel;
        public bool authorizationLevel
        {
            get { return _authorizationLevel; }
            set { SetProperty(ref _authorizationLevel, value); }
        }

        private CloseCommand _closeCommand;
        public CloseCommand closeCommand
        {
            get { return _closeCommand; }
            set { SetProperty(ref _closeCommand, value); }
        }
        public DelegateCommand conditionalCommand;
        public MainMenuViewModel(CloseCommand closeCommand,AddingCodesNavigateCommand addingCodesNavigationCommand,IGLobalNavigateCommand globalCommand,IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            this.closeCommand = closeCommand;
            globalNavigateCommand = globalCommand;
            this.addingCodesNavigationCommand = addingCodesNavigationCommand;
            eventAggregator.GetEvent<UpdatedEvent>().Subscribe(a => authorizationLevel = a.AuthorizationLevel=="Admin",ThreadOption.PublisherThread,true);
            conditionalCommand = new DelegateCommand(() => { }).ObservesCanExecute(() => authorizationLevel);
            addingCodesNavigationCommand.addingCodesNavigateCommand.RegisterCommand(conditionalCommand);
        }
    }
}
