using MediatR;
using System;

namespace TraceavitProDesktop.backApi.ping
{
    public class PingCommand : IRequest<DateTime>
    {
    }
}
