using System.Threading;
using MediatR;
using System;
using System.Threading.Tasks;
using TraceavitProDesktop.models;
using TraceavitProDesktop.services;
using Logictime.Protobuf;

namespace TraceavitProDesktop.backApi.setLine
{
    public class SetLineCommandHandler : IRequestHandler<SetLineCommand,SetLineResult>
    {
        private readonly DataBag bag;
        private readonly IApiService apiService;

        public SetLineCommandHandler(DataBag bag,IApiService apiService)
        {
            this.bag = bag;
            this.apiService = apiService;
        }


        /// Alexey Tretyak, [09.10.2023 18:29]
        /// 1 => 100, // no active JobsList on the line -> request JobList 
        /// 7 => 75,  // Active JobProcessHeader on the Line -> check station status
        /// _ => 0    // no Jo
        /// 
        /// это линии
        /// 
        /// 101 => 100, // no active session on the station -> delegate to JobProcessHeader 
        /// 103 => 50,  // active session on the station and on the same line -> Request JobData
        /// 104 => 25,  // active session on the station but on the diff line -> check station status
        /// _ => 0      // no Jo
        public async Task<SetLineResult> Handle(SetLineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bag.Settings.LineBarCode = Convert.ToInt32(request.BarCode);

                var apiRequest = new JoinLineRequest()
                {
                    LineId = bag.Settings.LineBarCode,
                    StationId = bag.Settings.StationId,
                    UserNumber = bag.User?.Number!,
                };

                var response = (await apiService.JoinLine(apiRequest)).Value;
                switch (response)
                {
                    case 0:
                        bag.LineState = SetLineResult.NoJob;
                        break;
                    case 25:
                        bag.LineState = SetLineResult.CheckStationStatus;
                        break;
                    case 50:
                        bag.LineState = SetLineResult.NeedRestore;
                        break;
                    case 100:
                        bag.LineState = SetLineResult.RequestJobData;
                        break;
                }
                return SetLineResult.Success;
            }
            catch (Exception e)
            {
                bag.Exception = e;
                return SetLineResult.Exception;
            }
        }
    }
}
