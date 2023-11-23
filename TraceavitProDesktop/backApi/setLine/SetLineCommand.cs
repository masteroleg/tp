using MediatR;
using TraceavitProDesktop.services;

namespace TraceavitProDesktop.backApi.setLine
{
    public class SetLineCommand : IRequest<SetLineResult>
    {
        public string BarCode { get; set; }
        public SetLineCommand() { }
        public SetLineCommand(string barCode) => BarCode=barCode;
    }
}
