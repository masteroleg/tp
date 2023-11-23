using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TraceavitProDesktop.backApi.barScannerDevice
{
    public class InitDeviceCommandHandler : IRequestHandler<InitDeviceCommand, bool>
    {
        public InitDeviceCommandHandler()
        {
        }

        public async Task<bool> Handle(InitDeviceCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
