using System.Threading;
using MediatR;
using System;
using System.Threading.Tasks;
using Logictime.Protobuf;

namespace TraceavitProDesktop.backApi.ping
{
    public class PingCommandHandler : IRequestHandler<PingCommand,DateTime>
    {
        private readonly IApiService _apiService;

        public PingCommandHandler(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<DateTime> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pingResponse = await _apiService.Ping();
                return pingResponse.ServerTime;
            }
            catch (Exception e)
            {
            }

            return DateTime.MinValue;
        }
    }
}
