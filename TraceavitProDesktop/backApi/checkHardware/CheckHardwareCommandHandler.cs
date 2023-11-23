using System.Threading;
using MediatR;
using System.Threading.Tasks;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.backApi.checkHardware
{
    public class CheckHardwareCommandHandler : IRequestHandler<CheckHardwareCommand,bool>
    {
        private readonly DataBag bag;

        public CheckHardwareCommandHandler(DataBag bag)
        {
			this.bag = bag;
        }

        public async Task<bool> Handle(CheckHardwareCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
