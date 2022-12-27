using BRMDesktopUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        public ShellViewModel( SalesViewModel salesVM,
            IEventAggregator events)
        {
            _events = events;
            _salesVM = salesVM;

            _events.Subscribe(this);


            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {         
            return ActivateItemAsync(_salesVM);
        }
    }
}
