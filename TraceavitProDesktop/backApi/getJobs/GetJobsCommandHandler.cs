using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraceavitProDesktop.models;
using TraceavitProDesktop.services;
using Logictime.Protobuf.Contract;
using Logictime.Protobuf;
using Serilog;
using System.Text.Json;
using MapsterMapper;

namespace TraceavitProDesktop.backApi.getJobs
{
    public class GetJobsCommandHandler : IRequestHandler<GetJobsCommand,GetJobsResult>
    {
        private readonly DataBag bag;
        private readonly IApiService apiService;
        private readonly IMapper mapper;

        public GetJobsCommandHandler(DataBag bag,IApiService apiService,IMapper mapper)
        {
            this.bag = bag;
            this.apiService = apiService;
            this.mapper = mapper;
        }

        public async Task<GetJobsResult> Handle(GetJobsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await apiService.JobList(new IntValue(bag.Settings.LineBarCode));
                bag.JobsList = response.Jobs ?? new List<JobData>();

                foreach (var jobData in bag.JobsList)
                {
                    var m = mapper.Map<JobDataView>(jobData);
                    m.ArticleRef.ArticleProductImage = Array.Empty<byte>();
                    string json = JsonSerializer.Serialize(m, new JsonSerializerOptions(JsonSerializerOptions.Default)
                    {
                        WriteIndented = true
                    });
                    Log.Information(json);
                }
                return GetJobsResult.Success;
            }
            catch (Exception e)
            {
                bag.Exception = e;
                return GetJobsResult.Exception;
            }
        }
    }
}
