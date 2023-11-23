using MediatR;

namespace TraceavitProDesktop.backApi.login;

public class LoginCommand: IRequest<LoginCommandResult>
{
    public string RFID { get; set; } = string.Empty;

    public LoginCommand() { }
    public LoginCommand(string rfid) => RFID = rfid;
}