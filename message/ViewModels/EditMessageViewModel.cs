using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using message.Data;
using message.Events;

namespace message.ViewModels
{
    class EditMessageViewModel : BindableBase
    {
        private Message _message;
        public Message EditMessage
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand UpdateCommand { get; set; }

        public EditMessageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => EditMessage);

            eventAggregator.GetEvent<EditMessageCommand>().Subscribe(SetMessageToEdit);
        }

        private void SetMessageToEdit(Message editMessage)
        {
            EditMessage = editMessage;
        }

        private bool CanExecute()
        {
            throw new NotImplementedException();
        }

        private void Execute()
        {
            throw new NotImplementedException();

            //_eventAggregator.GetEvent<UpdatedEvent>().Publish(LastUpdated.ToString());
        }
    }
}
