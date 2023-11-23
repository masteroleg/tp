using System.Text.Json;
using Grpc.Net.Client;
using Logictime.Protobuf;
using Logictime.Protobuf.Contract;
using ProtoBuf.Grpc.Client;

namespace BackApiTest
{
    public class ApiTests
    {
        private IApiService api;

        [SetUp]
        public void Setup()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            GrpcClientFactory.AllowUnencryptedHttp2 = false;
            var channel = GrpcChannel.ForAddress("http://78.137.12.2:5289");
            //var channel = GrpcChannel.ForAddress("http://127.0.0.1:10500");

            api = channel.CreateGrpcService<IApiService>();
            channel.ConnectAsync();
        }


        [Test]
        public async Task Ping()
        {
            var response = await api.Ping();
            string json = JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerOptions.Default)
            {
                WriteIndented = true
            });
            Assert.Pass(json);
        }


        [TestCase("Operator")]
        [TestCase("Master")]
        [TestCase("Inactive")]
        [TestCase("Inactive2")]
        public async Task Authenticate(string rfid)
        {
            var request  = new AuthRequest() { RFID = rfid };
            var response = await api.Authenticate(request);
            if (response != null)
            {
                string json = JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerOptions.Default)
                {
                    WriteIndented = true
                });
                Assert.Pass(json);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(100)]
        public async Task JoinLine(int line)
        {
            var request  = new JoinLineRequest() { LineId = line, StationId = 101, UserNumber = "Operator" };
            var response = await api.JoinLine(request);
            if (response != null)
            {
                string json = JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerOptions.Default)
                {
                    WriteIndented = true
                });
                Assert.Pass(json);
            }
        }

        [TestCase(1)]
        public async Task JobList(int line)
        {
            var response = await api.JobList(new IntValue(line));
            if (response != null)
            {
                string json = JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerOptions.Default)
                {
                    WriteIndented = true
                });
                Assert.Pass(json);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}