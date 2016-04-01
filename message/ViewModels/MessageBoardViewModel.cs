using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Unity;
using Prism.Regions;
using message.Data;
using message.Events;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace message.ViewModels
{
    class MessageBoardViewModel : BindableBase
    {
        #region Properties

        private IEnumerable<Message> _allmessages;
        public IEnumerable<Message> AllMessages {
            get { return _allmessages; }
            set { SetProperty(ref _allmessages, value); }
        }

        private Message _selectedItem;
        public Message SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if( _selectedItem == value ) { return; }
                _selectedItem = value;
                NavigateCommand.Execute();
            }
        }

        #endregion
        
        private readonly IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;
        public DelegateCommand NavigateCommand { get; set; }

        public MessageBoardViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand(Navigate);

            MessageDBDataContext db = new MessageDBDataContext();                 
            IQueryable<Message> topTenMessages = (from mg in db.Messages orderby mg.timestamp descending select mg).Take(10);
            AllMessages = topTenMessages.ToList();
        }

        private void Navigate()
        {
            _regionManager.RequestNavigate("ContentRegion", "EditMessage");

            _eventAggregator.GetEvent<EditMessageCommand>().Publish(SelectedItem);
        }
    }
}
