using System;
using System.Threading;
using System.Threading.Tasks;
using Logictime.Protobuf;
using MediatR;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.backApi.login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
{
    private readonly IApiService apiService;
    private readonly DataBag bag;

    public LoginCommandHandler(IApiService apiService,DataBag bag)
    {
        this.apiService = apiService;
        this.bag = bag;
    }

    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var apiRequest = new AuthRequest { RFID = request.RFID };
            var authResponse = await apiService.Authenticate(apiRequest);
            if (authResponse.ResultCode != 200)
            {
                bag.User = null;
                return (LoginCommandResult.AccessDenied);
            }

            bag.User = authResponse.User;
            return LoginCommandResult.Success;
        }
        catch (Exception e)
        {
            //todo довести до ума
            return LoginCommandResult.NetworkError;
        }
    }
}